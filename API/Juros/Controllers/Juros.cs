using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Globalization;

namespace Juros.Controllers;


[ApiController]
[Route("[controller]")]
public class JurosController : ControllerBase
{

    private readonly IConfiguration _config;

    public JurosController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet()]
    public async Task<IActionResult> Juros()
    {
        // Obtém o valor do juros da configuração
        string txJuros = 0.01.ToString();
        return Ok(txJuros);
    }


}
