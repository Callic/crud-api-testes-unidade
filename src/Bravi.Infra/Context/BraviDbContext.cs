using Bravi.Domain.Models;
using Bravi.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Infra.Context
{
    public class BraviDbContext : DbContext
    {
        public BraviDbContext([NotNullAttribute] DbContextOptions<BraviDbContext> opt): base(opt) { }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Contato> Contatos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BraviDbContext).Assembly);
        }
    }
}
