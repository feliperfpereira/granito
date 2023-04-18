using Calculo.Models;

namespace Calculo.Repo
{
    public interface ICalculoRepo
    {
        Task<string> CalculaJuros(CalculoDados dados);
        Task<string?> GetJuros();

    }
}