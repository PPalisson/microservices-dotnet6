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
        public IActionResult Get(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid input");
        }

        [HttpGet("multiply/{forNumber}/{fiveNumber}")]
        public IActionResult Get2(string forNumber, string fiveNumber) {

            if (IsNumeric(forNumber) && IsNumeric(fiveNumber)) 
                {
                var multiply = ConvertToDecimal(forNumber) * ConvertToDecimal(fiveNumber);

                return Ok(multiply.ToString());

            }
            return BadRequest("invalid input");
        }

        [HttpGet("Addition/{firstNumber}/{secondNumber}")]
        public IActionResult Get3(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var addition = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(addition.ToString());
            }
            return BadRequest("invalid input");
        }

        [HttpGet("Percentage/{firstNumber}/{secondNumber}")]
        public IActionResult get4(string firstNumber, string secondNumber) {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {

                var percentage = ConvertToDecimal(firstNumber) % ConvertToDecimal(secondNumber);

                return Ok(percentage.ToString());
            }
            return BadRequest("input invalido");

        }




        private bool IsNumeric(string strNumber) {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber) {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue)) {

                return decimalValue;
            }
            return 0;
        }

    }
}
