using Bravi.Domain.Interfaces;
using Bravi.Domain.Models;
using Bravi.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BraviDbContext _braviDbContext;

        public UnitOfWork(BraviDbContext braviDbContext)
        {
            this._braviDbContext = braviDbContext;
        }
        IPessoaRepository IUnitOfWork.PessoaRepository => new PessoaRepository(_braviDbContext);

        public async Task<bool> Commit()
        {
            return await _braviDbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _braviDbContext.Dispose();
        }
    }
}
