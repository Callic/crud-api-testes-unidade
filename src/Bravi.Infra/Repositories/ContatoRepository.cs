using Bravi.Domain.Models;
using Bravi.Infra.Context;
using Bravi.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Infra.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BraviDbContext _context;
        public ContatoRepository(BraviDbContext context)
        {
            _context = context;
        }

        public async Task<Contato> Adicionar(Contato entidade)
        {
            _context.Add(entidade);
            return entidade;
        }

        public void Atualizar(Contato entidade)
        {
            _context.Update(entidade);
        }


        public void Excluir(int id)
        {
            _context.Remove(new Contato { Id = id});
        }

        public async Task<Contato> ObterPorId(int id)
        {
            return await _context.Contatos.FindAsync(id);
        }

        public async Task<IEnumerable<Contato>> ObterTodos()
        {
            return await _context.Contatos.ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Contato> ObterPorIdNoTracking(int id)
        {
            return await _context.Contatos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Contato>> ObterPorPessoaId(int pessoaId)
        {
            return await _context.Contatos.Where(c => c.PessoaId == pessoaId).ToListAsync();
        }
    }
}
