using Bravi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Bravi.Infra.Repositories.Mapping
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contatos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(150)");
            builder.Property(p => p.Tipo)
                .IsRequired()
                .HasColumnType("int");
            builder.HasOne(p => p.Pessoa)
                .WithMany(p => p.Contatos)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

                
        }
    }
}
