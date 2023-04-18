using System.ComponentModel.DataAnnotations;

namespace Calculo.Models
{
    public class CalculoDados
    {
        [Required]
        public decimal valorinicial { get; set; }

        [Required]
        public int meses { get; set; }


    }
}