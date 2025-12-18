using LaDivine.Data;
using LaDivine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaDivine.Controllers
{
    [ApiController]
    [Route("api/sync-rapport")]
    public class SyncController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<SyncController> _logger;

        public SyncController(AppDbContext db, ILogger<SyncController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public class SyncOp
        {
            public Guid OperationId { get; set; }
            public string Operation { get; set; } // Create / Update / Delete
            public string EntityType { get; set; }
            public object Payload { get; set; }
            public DateTime ClientTimestamp { get; set; }
        }

        [HttpPost("/batch")]
        public async Task<IActionResult> Batch([FromBody] IEnumerable<SyncOp> ops)
        {
            // Simplified skeleton: apply each op and save
            using var tx = await _db.Database.BeginTransactionAsync();
            try
            {
                foreach (var op in ops)
                {
                    _logger.LogInformation("Applying op {OpId} {Entity} {Op}", op.OperationId, op.EntityType, op.Operation);
                    // TODO: deserialize payload and apply with idempotence checks
                }

                await _db.SaveChangesAsync();
                await tx.CommitAsync();
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error applying sync batch");
                await tx.RollbackAsync();
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}