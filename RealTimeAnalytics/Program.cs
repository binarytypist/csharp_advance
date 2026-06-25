using EventStore.Client;
using InfluxDB.Client;
using MediatR;
using RealTimeAnalytics;

var builder = WebApplication.CreateBuilder(args);

#region CORE SERVICES

// Register MVC controllers for API endpoints
builder.Services.AddControllers();

// Enables OpenAPI/Swagger metadata generation
builder.Services.AddEndpointsApiExplorer();

// Adds Swagger generation for API documentation
builder.Services.AddSwaggerGen();

#endregion

#region CORS (Angular + SignalR MUST SUPPORT CREDENTIALS)

builder.Services.AddCors(options =>
{
    options.AddPolicy("Angular", policy =>
    {
        // Allow Angular frontend to call backend
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

#endregion

#region MEDIATR (CQRS)

// Registers MediatR handlers from current assembly
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

#endregion

#region SIGNALR

// Enables real-time communication hub support
builder.Services.AddSignalR();

#endregion

#region KAFKA

// Kafka producer service (publishing events)
builder.Services.AddSingleton<KafkaEventPublisher>();

// Kafka consumer background service
builder.Services.AddHostedService<KafkaConsumerService>();

#endregion

#region EVENTSTOREDB

// Register EventStoreDB client as singleton
builder.Services.AddSingleton(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    var connectionString = config["EventStore:ConnectionString"];

    if (string.IsNullOrWhiteSpace(connectionString))
        throw new InvalidOperationException("EventStore:ConnectionString missing");

    var settings = EventStoreClientSettings.Create(connectionString);

    return new EventStoreClient(settings);
});

// Abstraction for writing events into EventStoreDB
builder.Services.AddScoped<IEventStore, EventStoreDb>();

#endregion

#region INFLUXDB

// Register InfluxDB client as singleton
builder.Services.AddSingleton(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    var url = config["Influx:Url"];
    var token = config["Influx:Token"];

    if (string.IsNullOrWhiteSpace(url))
        throw new InvalidOperationException("Influx:Url missing");

    if (string.IsNullOrWhiteSpace(token))
        throw new InvalidOperationException("Influx:Token missing");

    return InfluxDBClientFactory.Create(url, token.ToCharArray());
});

// Abstraction for writing metrics into InfluxDB
builder.Services.AddSingleton<IInfluxWriter, InfluxWriter>();

#endregion

#region BACKGROUND WORKER

// Background service that processes events and streams data
builder.Services.AddHostedService<EventProcessor>();

#endregion

var app = builder.Build();

#region PIPELINE (IMPORTANT ORDER)

// Enable Swagger UI in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enables routing system (required for controllers + SignalR)
app.UseRouting();

// Enables CORS policy for Angular frontend
app.UseCors("Angular");

// Enables authorization middleware
app.UseAuthorization();

// Maps API controller endpoints
app.MapControllers();

// Maps SignalR hub endpoint
app.MapHub<MetricsHub>("/hub/metrics");

#endregion

app.Run();

//         ┌──────────────────────────┐
//         │        Clients           │
//         │ (Dashboards / Apps)      │
//         └──────────┬───────────────┘
//                    │ SignalR (real-time push)
//                    ▼
//       ┌────────────────────────────┐
//       │   API Gateway / BFF        │
//       │ (ASP.NET Core + MediatR)   │
//       └───────┬──────────┬─────────┘
//               │          │
//       Commands│          │Queries
//               ▼          ▼
//  ┌────────────────┐   ┌──────────────────┐
//  │ Command Side   │   │ Query Side       │
//  │ (CQRS)         │   │ (Read Models)    │
//  └──────┬─────────┘   └──────┬───────────┘
//         │                    │
//         ▼                    ▼
//┌──────────────────┐   ┌───────────────────┐
//│ EventStoreDB     │   │ InfluxDB          │
//│ (Event Sourcing) │   │ Time-series data  │
//└──────┬───────────┘   └──────┬────────────┘
//       │                       │
//       ▼                       ▼
//┌────────────────────────────────────┐
//│ Event Processor / Projection Layer │
//│ (Background Services / Workers)    │
//└──────────────┬─────────────────────┘
//               ▼
//       ┌──────────────────────┐
//       │ SignalR Hub          │
//       │ Real-time updates    │
//       └──────────────────────┘

//               ▼
//       ┌──────────────────────┐
//       │ Grafana              │
//       │ Dashboards (Influx)  │
//       └──────────────────────┘

// Where each technology fits

//Kafka / RabbitMQ
// event bus
// decoupling
// high throughput buffer

//EventStoreDB

//✔ source of truth
//✔ event history
//✔ replay system

//InfluxDB

//✔ time-series analytics
//✔ dashboards (Grafana)

//Elasticsearch

//✔ logs
//✔ traces
//✔ full-text search
//✔ debugging distributed system

//OpenTelemetry

//✔ distributed tracing
//✔ correlation between services
//✔ performance insight

//🧠 6. Clean separation of concerns
//Layer	Responsibility
//API (ASP.NET)	accept commands
//CQRS (MediatR)	business logic
//EventStoreDB	truth storage
//Kafka	event streaming backbone
//Analytics svc	metrics storage
//Alerting svc	decisions
//Elasticsearch	logs/traces
//OpenTelemetry	observability
//⚙️ 7. What your CURRENT system becomes

//Right now you built:

//Monolith real-time pipeline

//After refactor:

//Distributed observability platform
//🔥 8. Recommended evolution path (IMPORTANT)

//Don’t jump everything at once. Do it step-by-step:

//Phase 1 (you are here)

//✔ ASP.NET Core
//✔ CQRS
//✔ EventStore
//✔ InfluxDB
//✔ SignalR

//Phase 2 (add buffer)

//👉 Add Kafka

//EventStore → Kafka → Worker
//Phase 3 (split services)
//ingestion-service
//analytics-service
//alerting-service
//Phase 4 (observability layer)
//OpenTelemetry
//Elasticsearch
//distributed tracing
//Phase 5 (production scale)
//Kubernetes
//autoscaling consumers
//retry queues
//dead-letter queues
//🧠 9. Key insight (very important)

//You are building:

//🚀 “Datadog / Prometheus / Grafana - style system”

//Not just an API.

//👍 If you want next step

//I can now help you with:

//🔥 real folder structure for 3 services
//🔥 Kafka event contracts (shared kernel)
//🔥 OpenTelemetry setup in ASP.NET Core
//🔥 Elasticsearch logging pipeline
//🔥 full docker-compose (Kafka + ES + Influx + EventStore)

//Just tell me 👍

//Memory full

//6.Clean separation of concerns
//Layer	Responsibility
//API (ASP.NET)	accept commands
//CQRS (MediatR)	business logic
//EventStoreDB	truth storage
//Kafka	event streaming backbone
//Analytics svc	metrics storage
//Alerting svc	decisions
//Elasticsearch	logs/traces
//OpenTelemetry	observability