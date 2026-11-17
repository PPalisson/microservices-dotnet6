// CalculatorController.cs: recebe numeros pela URL e executa operacoes matematicas.
// Ok(resultado.ToString()) responde 200 com o resultado convertido para texto.
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers {

    // Rota base /Calculator; os caminhos abaixo sao acrescentados a ela.
    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase {

        private readonly ILogger<CalculatorController> _logger;


        public CalculatorController(ILogger<CalculatorController> logger) {
            _logger = logger;
        }

        // GET /Calculator/sum/2/3: retorna a soma, 5.
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid input");
        }

        // GET /Calculator/multiply/2/3: retorna o produto, 6.
        [HttpGet("multiply/{forNumber}/{fiveNumber}")]
        public IActionResult Get2(string forNumber, string fiveNumber) {

            if (IsNumeric(forNumber) && IsNumeric(fiveNumber))
                {
                var multiply = ConvertToDecimal(forNumber) * ConvertToDecimal(fiveNumber);

                return Ok(multiply.ToString());

            }
            return BadRequest("invalid input");
        }

        // ATENCAO: o nome Addition sugere soma, mas o codigo divide (/).
        // GET /Calculator/Addition/6/2 retorna 3. Divisor zero ainda nao e tratado.
        [HttpGet("Addition/{firstNumber}/{secondNumber}")]
        public IActionResult Get3(string firstNumber, string secondNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
                var addition = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(addition.ToString());
            }
            return BadRequest("invalid input");
        }

        // ATENCAO: % calcula resto da divisao, nao porcentagem.
        // GET /Calculator/Percentage/10/3 retorna 1. Segundo valor zero nao e tratado.
        [HttpGet("Percentage/{firstNumber}/{secondNumber}")]
        public IActionResult get4(string firstNumber, string secondNumber) {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {

                var percentage = ConvertToDecimal(firstNumber) % ConvertToDecimal(secondNumber);

                return Ok(percentage.ToString());
            }
            return BadRequest("input invalido");

        }

        // GET /Calculator/saquareRoot/9 retorna a raiz quadrada, 3.
        // saquareRoot e a grafia atual da rota. Valores negativos nao sao rejeitados aqui.
        [HttpGet("saquareRoot/{firstNumber}")]
        public IActionResult get5(string firstNumber) {

            if (IsNumeric(firstNumber) ) {

                var saquareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));

                return Ok(saquareRoot.ToString());
            }
            return BadRequest("input invalido");

        }









        // Valida como double com cultura invariavel (ponto decimal).
        // A conversao abaixo usa decimal e outra cultura; a validacao pode discordar dela.
        private bool IsNumeric(string strNumber) {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }

        // Converte usando a cultura da maquina. Se falhar, devolve 0 e oculta a falha.
        // Melhoria futura: validar e converter com o mesmo tipo numerico e a mesma cultura.
        private decimal ConvertToDecimal(string strNumber) {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue)) {

                return decimalValue;
            }
            return 0;
        }

    }
}
