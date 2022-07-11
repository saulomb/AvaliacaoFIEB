using Avaliacao.Domain.RH;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Avaliacao.Data.Mappings
{
    public class FuncionarioEscalaMapping : IEntityTypeConfiguration<Escala>
    {
        public void Configure(EntityTypeBuilder<Escala> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.HoraInicio)
                .HasColumnName("HoraInicio")
                .HasColumnType("time(7)");
            builder.Property(e => e.HoraTermino)
                .HasColumnName("HoraTermino")
                .HasColumnType("time(7)");
            builder.Property(e => e.TempoDescanso)
                .HasColumnName("TempoDescanso")
                .HasColumnType("int");

            builder.Property(c => c.FuncionarioId)
                .HasColumnName("FuncionarioId")
                .IsRequired();

            // 1 : N => Funcionario : EscalaSemanal
            builder.HasOne(c => c.Funcionario)
                .WithMany(c => c.EscalaSemanal);

            //builder.Ignore(c => c.CalculaCargaHoraria());

            builder.ToTable("FuncionarioEscala");

            builder.Ignore(c => c.ValidationResult);
        }
    }
}