using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Globalization;

namespace Calculo.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculoController : ControllerBase
{

    private readonly IConfiguration _config;

    public CalculoController(IConfiguration config)
    {
        _config = config;

    }

    [HttpGet("calculajuros")]
    public async Task<IActionResult> CalculaJuros(decimal valorinicial, int meses)
    {
        // Obtém o valor do juros da configuração
        string txJuros = _config["TaxaJuros"];
        decimal juros = decimal.Parse(txJuros, CultureInfo.InvariantCulture);

        // Calcula o valor final com juros compostos
        decimal valorfinal = valorinicial * (decimal)Math.Pow((double)(1 + juros), meses);

        // Trunca o resultado em duas casas decimais
        valorfinal = Math.Truncate(valorfinal * 100) / 100;

        // Retorna o valor final como resposta
        return Ok(valorfinal.ToString("F2", CultureInfo.InvariantCulture));

    }

    [HttpGet("showmethecode")]
    public IActionResult ShowMeTheCode()
    {
        // Obtém a URL do GitHub da configuração
        string urlGitHub = _config["UrlGitHub"];

        // Retorna a URL do GitHub como resposta
        return Ok(urlGitHub);
    }
}
