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
    }

    [HttpGet("showmethecode")]
    public IActionResult ShowMeTheCode()
    {
        // Obtém a URL do GitHub da configuração
        string urlGitHub = "GitHub: https://github.com/feliperfpereira/granito\nDocker: https://hub.docker.com/repository/docker/feliperfpereira/api";

        // Retorna a URL do GitHub como resposta
        return Ok(urlGitHub);
    }
}
