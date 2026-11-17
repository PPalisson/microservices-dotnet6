using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger) {
            _logger = logger;
        }
        
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid input");
        }

        private int ConvertToDecimal(string strNumber) {
            throw new NotImplementedException();
        }

        private bool IsNumeric(string strNumber) {
            throw new NotImplementedException();
        }
    }

}
