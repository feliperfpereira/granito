using Calculo.Models;
using System.Net.Http;
using System.Threading.Tasks;
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


namespace Calculo.Repo
{
    public class CalculoRepo : ICalculoRepo
    {
        public CalculoRepo()
        {

        }


        public async Task<string> CalculaJuros(CalculoDados dados)
        {
            // Obtém o valor do juros da configuração
            string txJuros = await GetJuros();
            decimal juros = decimal.Parse(txJuros, CultureInfo.InvariantCulture);

            // Calcula o valor final com juros compostos
            decimal valorfinal = dados.valorinicial * (decimal)Math.Pow((double)(1 + juros), dados.meses);

            // Trunca o resultado em duas casas decimais
            valorfinal = Math.Truncate(valorfinal * 100) / 100;

            // Retorna o valor final como resposta
            return valorfinal.ToString("F2", CultureInfo.InvariantCulture);
        }

        public async Task<string?> GetJuros()
        {
            using (var client = new HttpClient())
            {
                //var response = await client.GetAsync("http://host.docker.internal:5001/Juros");
                var response = await client.GetAsync("http://ip172-18-0-5-cgv9p2ae69v000941i80-5001.direct.labs.play-with-docker.com/Juros");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
        }

    }
}