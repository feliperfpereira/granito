using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Calculo.Repo;
using Calculo.Models;

namespace Calculo.Controllers;


[ApiController]
[Route("[controller]")]
public class CalculoController : ControllerBase
{

    private readonly ICalculoRepo _calculoRepo;

    public CalculoController(ICalculoRepo calculoRepo)
    {
        _calculoRepo = calculoRepo;
    }

    [HttpGet("calculajuros")]
    public async Task<IActionResult> CalculaJuros(decimal valorinicial, int meses)
    {
        CalculoDados calculo = new CalculoDados();
        calculo.meses = meses;
        calculo.valorinicial = valorinicial;
        var final = await _calculoRepo.CalculaJuros(calculo);
        return Ok(final);
        // // Obtém o valor do juros da configuração
        // string txJuros = _config["TaxaJuros"];
        // decimal juros = decimal.Parse(txJuros, CultureInfo.InvariantCulture);

        // // Calcula o valor final com juros compostos
        // decimal valorfinal = valorinicial * (decimal)Math.Pow((double)(1 + juros), meses);

        // // Trunca o resultado em duas casas decimais
        // valorfinal = Math.Truncate(valorfinal * 100) / 100;

        // // Retorna o valor final como resposta
        // return Ok(valorfinal.ToString("F2", CultureInfo.InvariantCulture));

    }

    [HttpGet("showmethecode")]
    public IActionResult ShowMeTheCode()
    {
        // Obtém a URL do GitHub da configuração
        string urlGitHub = ";";

        // Retorna a URL do GitHub como resposta
        return Ok(urlGitHub);
    }
}
