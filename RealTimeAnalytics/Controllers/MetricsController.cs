using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RealTimeAnalytics.Controllers;

[ApiController]
[Route("api/metrics")]
public class MetricsController : ControllerBase
{
    // MediatR is used to decouple API layer from business logic
    // Instead of handling logic here, we send a "command" to a handler
    private readonly IMediator _mediator;

    public MetricsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Receives a metric from client (Angular / Postman / device)
    /// and forwards it into the CQRS pipeline
    /// </summary>
    [HttpPost("ingest")]
    public async Task<IActionResult> Ingest([FromBody] IngestMetricCommand command)
    {
        // Validate request body
        if (command == null)
            return BadRequest("Command cannot be null");

        // Send command to MediatR pipeline
        // This will call IngestMetricHandler automatically
        await _mediator.Send(command);

        // Return HTTP 202 Accepted because processing is asynchronous
        // (event is stored in EventStore + processed later)
        return Accepted(new
        {
            message = "Metric accepted into event pipeline",
            command.DeviceId,
            command.MetricName
        });
    }
}