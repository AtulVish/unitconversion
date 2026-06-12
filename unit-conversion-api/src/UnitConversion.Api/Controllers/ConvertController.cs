using Microsoft.AspNetCore.Mvc;
using UnitConversion.Api.Models;
using UnitConversion.Api.Services;

namespace UnitConversion.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConvertController : ControllerBase
    {
        private readonly IUnitConversionService _service;
        private readonly ILogger<ConvertController> _logger;

        public ConvertController(IUnitConversionService service, ILogger<ConvertController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET /api/convert?value=1&from=meter&to=foot
        [HttpGet]
        public ActionResult<ConvertResponse> Get([FromQuery] double value, [FromQuery] string from, [FromQuery] string to)
        {
            try
            {
                var res = _service.Convert(value, from, to);
                return Ok(res);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Bad request");
                return BadRequest(new { error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Invalid operation");
                return BadRequest(new { error = ex.Message });
            }
        }

        // POST /api/convert
        [HttpPost]
        public ActionResult<ConvertResponse> Post([FromBody] ConvertRequest request)
        {
            if (request == null) return BadRequest(new { error = "Request body required" });

            try
            {
                var res = _service.Convert(request.Value, request.FromUnit, request.ToUnit);
                return Ok(res);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
