using Bravi.Domain.Interfaces;
using Bravi.Domain.Models;
using Bravi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Bravi.Infra.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly BraviDbContext _context;
        public PessoaRepository(BraviDbContext context)
        {
           _context = context;
        }
        

        public async void Adicionar(Pessoa entidade)
        {
            await _context.AddAsync(entidade);
        }

        public void Atualizar(Pessoa entidade)
        {
           _context.Update(entidade);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Excluir(int id)
        {
            _context.Remove(new Pessoa { Id = id } );
        }

        public async Task<Pessoa> ObterPorId(int id)
        {
            return await _context.Pessoas.Include(p => p.Contatos).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pessoa> ObterPorIdNoTracking(int id)
        {
            return await _context.Pessoas.AsNoTracking().Include(p => p.Contatos).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pessoa>> ObterTodos()
        {
            return await _context.Pessoas.Include(p => p.Contatos).ToListAsync();
        }
    }
}
