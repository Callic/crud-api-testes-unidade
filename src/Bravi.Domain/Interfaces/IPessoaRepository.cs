using Bravi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Interfaces
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<IEnumerable<Pessoa>> ObterTodos();
        Task<Pessoa> ObterPorId(int id);
        Task<Pessoa> ObterPorIdNoTracking(int id);
        void Adicionar(Pessoa entidade);
        void Atualizar(Pessoa entidade);
        void Excluir(int id);
    }
}
