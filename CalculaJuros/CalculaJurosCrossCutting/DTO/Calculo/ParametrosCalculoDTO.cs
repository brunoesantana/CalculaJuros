namespace CalculaJuros.CrossCutting.DTO.Calculo
{
    public class ParametrosCalculoDTO
    {
        public decimal Valor { get; set; }
        public int Meses { get; set; }
        public double TaxaJuros { get; set; }
    }
}