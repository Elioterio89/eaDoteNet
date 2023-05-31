using Microsoft.AspNetCore.Mvc;

namespace RestAPIaspnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        

        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        #region gets


        [HttpGet("soma/{firstNumber}/{secondNumber}")]
        public IActionResult Soma(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var soma = ConverToDecimal(firstNumber) + ConverToDecimal(secondNumber);
                return Ok(soma.ToString());
            }

            return BadRequest("entrada invalida");
        }

        [HttpGet("subtracao/{firstNumber}/{secondNumber}")]
        public IActionResult Subtracao(string firstNumber, string secondNumber)
        { 
            if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
            {
                var subtracao = ConverToDecimal(firstNumber) - ConverToDecimal(secondNumber);
                return Ok(subtracao.ToString());
            }

            return BadRequest("entrada invalida");
        }

        [HttpGet("divisao/{firstNumber}/{secondNumber}")]
        public IActionResult Divisao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
            {
                var divisao = ConverToDecimal(firstNumber) / ConverToDecimal(secondNumber);
                return Ok(divisao.ToString());
            }

            return BadRequest("entrada invalida");
        }

        [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplicacao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
            {
                var multiplicacao = ConverToDecimal(firstNumber) * ConverToDecimal(secondNumber);
                return Ok(multiplicacao.ToString());
            }

            return BadRequest("entrada invalida");
        }

        [HttpGet("raiz/{firstNumber}/{secondNumber}")]
        public IActionResult Raiz(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
            {
                var raiz =  Math.Pow(ConverToDecimal(firstNumber), ConverToDecimal(secondNumber,true));
                return Ok(raiz.ToString());
            }

            return BadRequest("entrada invalida");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
            {
                var media = (ConverToDecimal(firstNumber)+ ConverToDecimal(secondNumber)) / 2;
                return Ok(media.ToString());
            }

            return BadRequest("entrada invalida");
        }

        #endregion


        #region metodosAux
        private double ConverToDecimal(string strNumber,bool fraciona=false)
        {
            double decimalValue;
            if(double.TryParse(strNumber,out decimalValue))
            {
                if (fraciona)
                {
                    return 1/decimalValue;
                }
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber,System.Globalization.NumberStyles.Any , System.Globalization.NumberFormatInfo.InvariantInfo ,out number);
            return isNumber;
        }

        #endregion
    }
}