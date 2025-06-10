namespace InventSoftwareAPI.Models
{
    public class EquipamentoEletronico
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

        public int QuantidadeEstoque { get; set; }

        public DateTime DataInclusao { get; set; }

        public bool TemEstoque => QuantidadeEstoque > 0;
    }
}
