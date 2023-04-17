using Calculo.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Moq;


namespace Tests;

public class UnitTest
{

    private readonly CalculoController _calculoController;

    public UnitTest()
    {
        var mockRepo = new Mock<IConfiguration>();
        mockRepo.SetupGet(x => x[It.Is<string>(s => s == "TaxaJuros")]).Returns("0.01");

        _calculoController = new CalculoController(mockRepo.Object);

    }


    [Fact]
    public async Task CalculaJuros_Endpoint_DeveRetornarValorCalculado()
    {
        // Arrange
        var valorInicial = 100m;
        var meses = 5;

        // Act
        var result = await _calculoController.CalculaJuros(valorInicial, meses) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
        Assert.Equal("105.10", result.Value);
    }
}