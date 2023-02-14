using Bravi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Infra.Repositories.Mapping
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.HasMany(p => p.Contatos)
                .WithOne(p => p.Pessoa);
        }
    }
}
