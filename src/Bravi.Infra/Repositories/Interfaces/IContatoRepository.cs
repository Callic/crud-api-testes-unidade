using Bravi.Domain.Interfaces;
using Bravi.Domain.Models;

namespace Bravi.Infra.Repositories.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<IEnumerable<Contato>> ObterTodos();
        Task<Contato> ObterPorId(int id);
        Task<Contato> ObterPorIdNoTracking(int id);
        Task<IEnumerable<Contato>> ObterPorPessoaId(int pessoaId);
        Task<Contato> Adicionar(Contato entidade);
        void Atualizar(Contato entidade);
        void Excluir(int id);
    }
}
