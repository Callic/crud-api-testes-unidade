using Bravi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Application.Services.Interfaces
{
    public interface IContatoService : IDisposable
    {
        Task<Contato> ObterPorId(int id);
        Task<IEnumerable<Contato>> ObterTodos();
        Task<Contato> Adicionar(Contato contato);
        Task<bool> Atualizar(Contato contato);
        Task<bool> Remover(int id);
        Task<Contato> ObterPorIdNoTracking(int id);
        Task<IEnumerable<Contato>> ObterPorPessoaId(int pessoaId);
    }
}
