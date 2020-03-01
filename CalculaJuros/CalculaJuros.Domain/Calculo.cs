using System.ComponentModel.DataAnnotations;
using CalculaJuros.Domain.Base;

namespace CalculaJuros.Domain
{
    public class Calculo : EntityBase
    {
        [Required]
        public decimal Value { get; set; }
    }
}