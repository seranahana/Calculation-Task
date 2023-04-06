using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CalcTask.WebAPI.Controllers
{
    [ApiController]
    [Route("v1/calc")]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationService _calculationService;
        private readonly Serilog.ILogger _logger;

        public CalculationController(ICalculationService calculationService, Serilog.ILogger logger)
        {
            _calculationService = calculationService;
            _logger = logger;
        }

        [Route("add")]
        [HttpGet]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public IActionResult Add([FromQuery, Required] double value, [FromQuery, Required] double addend)
        {
            double result = _calculationService.Add(value, addend);
            return Ok(result);
        }

        [Route("divide")]
        [HttpGet]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public IActionResult Divide([FromQuery, Required] double value, [FromQuery, Required] double divisor)
        {
            double result = _calculationService.Divide(value, divisor);
            return Ok(result);
        }

        [Route("multiply")]
        [HttpGet]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public IActionResult Multiply([FromQuery, Required] double value, [FromQuery, Required] double multiplier)
        {
            double result = _calculationService.Multiply(value, multiplier);
            return Ok(result);
        }

        [Route("root")]
        [HttpGet]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public IActionResult NthRoot([FromQuery, Required] double value, [FromQuery, Required] double root)
        {
            double result = _calculationService.NthRoot(value, root);
            return Ok(result);
        }

        [Route("power")]
        [HttpGet]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public IActionResult Power([FromQuery, Required] double value, [FromQuery, Required] double power)
        {
            double result = _calculationService.Pow(value, power);
            return Ok(result);
        }

        [Route("substract")]
        [HttpGet]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public IActionResult Substract([FromQuery, Required] double value, [FromQuery, Required] double substrahend)
        {
            double result = _calculationService.Substract(value, substrahend);
            return Ok(result);
        }
    }
}
