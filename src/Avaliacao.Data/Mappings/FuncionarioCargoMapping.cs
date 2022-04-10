using Avaliacao.Domain.RH;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Avaliacao.Data.Mappings
{
    public class FuncionarioCargoMapping : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(40)");


            builder.ToTable("FuncionarioCargo");
        }
    }
}