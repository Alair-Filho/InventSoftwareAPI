using InventSoftwareAPI.Models;

namespace InventSoftwareAPI.Repositories
{
    public interface IEquipamentoRepository
    {
        List<EquipamentoEletronico> ObterTodos();

        EquipamentoEletronico? ObterPorId(Guid id);

        void Adicionar(EquipamentoEletronico equipamento);
        void Atualizar(EquipamentoEletronico equipamento);

        void Remover(Guid id);
    }
}
