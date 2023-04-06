using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CalcTask.WebAPI.Controllers
{
    [ApiController]
    [Route("v1/calc")]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationService _calculationService;
        private readonly IMessagesProvider _messagesProvider;
        private readonly Serilog.ILogger _logger;

        public CalculationController(ICalculationService calculationService, IMessagesProvider messagesProvider, Serilog.ILogger logger)
        {
            _calculationService = calculationService;
            _messagesProvider = messagesProvider;
            _logger = logger;
        }

        [Route("add")]
        [HttpGet]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Add([FromQuery, Required] double value, [FromQuery, Required] double addend)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                double result = _calculationService.Add(value, addend);
                return Ok(result);
            }
            catch (OverflowException)
            {
                return BadRequest(_messagesProvider.GetInvalidResultErrorMessage());
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, ex.GetType().ToString());
                return Problem(_messagesProvider.GetInternalServerErrorMessage());
            }
        }

        [Route("divide")]
        [HttpGet]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Divide([FromQuery, Required] double value, [FromQuery, Required] double divisor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                double result = _calculationService.Divide(value, divisor);
                return Ok(result);
            }
            catch (OverflowException)
            {
                return BadRequest(_messagesProvider.GetInvalidResultErrorMessage());
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, ex.GetType().ToString());
                return Problem(_messagesProvider.GetInternalServerErrorMessage());
            }
        }

        [Route("multiply")]
        [HttpGet]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Multiply([FromQuery, Required] double value, [FromQuery, Required] double multiplier)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                double result = _calculationService.Multiply(value, multiplier);
                return Ok(result);
            }
            catch (OverflowException)
            {
                return BadRequest(_messagesProvider.GetInvalidResultErrorMessage());
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, ex.GetType().ToString());
                return Problem(_messagesProvider.GetInternalServerErrorMessage());
            }
        }

        [Route("root")]
        [HttpGet]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult NthRoot([FromQuery, Required] double value, [FromQuery, Required] double root)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                double result = _calculationService.NthRoot(value, root);
                return Ok(result);
            }
            catch (OverflowException)
            {
                return BadRequest(_messagesProvider.GetInvalidResultErrorMessage());
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, ex.GetType().ToString());
                return Problem(_messagesProvider.GetInternalServerErrorMessage());
            }
        }

        [Route("power")]
        [HttpGet]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Power([FromQuery, Required] double value, [FromQuery, Required] double power)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                double result = _calculationService.Pow(value, power);
                return Ok(result);
            }
            catch (OverflowException)
            {
                return BadRequest(_messagesProvider.GetInvalidResultErrorMessage());
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, ex.GetType().ToString());
                return Problem(_messagesProvider.GetInternalServerErrorMessage());
            }
        }

        [Route("substract")]
        [HttpGet]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Substract([FromQuery, Required] double value, [FromQuery, Required] double substrahend)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                double result = _calculationService.Substract(value, substrahend);
                return Ok(result);
            }
            catch (OverflowException)
            {
                return BadRequest(_messagesProvider.GetInvalidResultErrorMessage());
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, ex.GetType().ToString());
                return Problem(_messagesProvider.GetInternalServerErrorMessage());
            }
        }
    }
}
