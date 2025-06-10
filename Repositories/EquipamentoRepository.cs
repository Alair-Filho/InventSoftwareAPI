using InventSoftwareAPI.Models;
using InventSoftwareAPI.Repositories;

namespace InventSoftwareAPI.Repositories
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly List<EquipamentoEletronico> _equipamentos = new List<EquipamentoEletronico>();

        public EquipamentoRepository()
        {
            // Dados iniciais para popular a lista em memória
            _equipamentos.Add(new EquipamentoEletronico
            {
                Id = Guid.NewGuid(),
                Nome = "Notebook Dell",
                Tipo = "Notebook",
                QuantidadeEstoque = 80,
                DataInclusao = DateTime.UtcNow
            });
            _equipamentos.Add(new EquipamentoEletronico
            {
                Id = Guid.NewGuid(),
                Nome = "Mouse Logitech",
                Tipo = "Mouse",
                QuantidadeEstoque = 91,
                DataInclusao = DateTime.UtcNow
            });
            _equipamentos.Add(new EquipamentoEletronico
            {
                Id = Guid.NewGuid(),
                Nome = "PC i9",
                Tipo = "PC",
                QuantidadeEstoque = 25,
                DataInclusao = DateTime.UtcNow
            });
            _equipamentos.Add(new EquipamentoEletronico
            {
                Id = Guid.NewGuid(),
                Nome = "Monitor Oled",
                Tipo = "Monitor",
                QuantidadeEstoque = 0,
                DataInclusao = DateTime.UtcNow
            });
        }

        public List<EquipamentoEletronico> ObterTodos() => _equipamentos;

        public EquipamentoEletronico? ObterPorId(Guid id) =>
            _equipamentos.FirstOrDefault(e => e.Id == id);

        public void Adicionar(EquipamentoEletronico equipamento)
        {
            _equipamentos.Add(equipamento);
        }

        public void Atualizar(EquipamentoEletronico equipamento)
        {
            var existente = ObterPorId(equipamento.Id);
            
            if (existente != null)
            {
                existente.Nome = equipamento.Nome;
                existente.Tipo = equipamento.Tipo;
                existente.QuantidadeEstoque = equipamento.QuantidadeEstoque;
                existente.DataInclusao = equipamento.DataInclusao;
            }
        }

        public void Remover(Guid id)
        {
            var equipamento = ObterPorId(id);

            if(equipamento != null)
            {
                _equipamentos.Remove(equipamento);
            }
        }
    }
}
