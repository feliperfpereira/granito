using Calculo.Repo;
using Calculo.Models;
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

    private readonly ICalculoRepo _calculoRepo;

    public UnitTest()
    {
        //var mockRepo = new Mock<IConfiguration>();
        //mockRepo.SetupGet(x => x[It.Is<string>(s => s == "TaxaJuros")]).Returns("0.01");

        //_calculoRepo = new CalculoRepo(mockRepo.Object);
        _calculoRepo = new CalculoRepo();

    }


    [Fact]
    public async Task CalculaJuros_Endpoint_DeveRetornarValorCalculado()
    {
        // Arrange
        CalculoDados calculo = new CalculoDados();
        calculo.meses = 5;
        calculo.valorinicial = 100m;

        // Act
        var result = await _calculoRepo.CalculaJuros(calculo);

        // Assert
        Assert.NotNull(result);
        //Assert.IsType<OkObjectResult>(result);
        Assert.Equal("105.10", result);
    }
}