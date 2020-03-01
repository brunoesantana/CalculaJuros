using CalculaJuros.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace CalculaJuros.Domain
{
    public class Projeto : EntityBase
    {
        [Required]
        public string Url { get; set; }
    }
}