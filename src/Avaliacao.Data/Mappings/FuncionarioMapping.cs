using Avaliacao.Domain.RH;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avaliacao.Data.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {

        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(250)");

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(250)");

            builder.Property(e => e.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("char(11)");
            
            builder.Property(e => e.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("char(11)");

            builder.Property(e => e.Habilitacao)
                .HasColumnName("Habilitado");

            builder.Property(e => e.Categoria)
                .HasColumnName("Categoria")
                .HasColumnType("char(1)");


            builder.Property(e => e.Salario)
                .HasColumnName("Salario")
                .HasColumnType("money")
                .IsRequired();
            
            builder.Property(e => e.CargoId)
                .HasColumnName("Cargoid")
                .IsRequired();

            builder
            .HasOne(e => e.Cargo)
            .WithMany()
            .HasForeignKey(p => p.CargoId)
            .IsRequired(true);

            builder.Property(e => e.Categoria)
                .HasColumnName("Categoria")
                .HasColumnType("char(1)");

            builder.OwnsOne(p => p.LinguaEstrangeira, e =>
            {
                e.Property(pe => pe.Ingles)
                    .HasColumnName("Ingles");
                e.Property(pe => pe.Espanhol)
                    .HasColumnName("Espanhol");
                e.Property(pe => pe.Frances)
                    .HasColumnName("Frances");
            });

            builder.OwnsOne(p => p.Endereco, e =>
            {
                e.Property(pe => pe.Logradouro)
                    .HasColumnName("Logradouro")
                    .HasColumnType("varchar(50)");

                e.Property(pe => pe.Numero)
                    .HasColumnName("Numero")
                    .HasColumnType("varchar(10)");

                e.Property(pe => pe.Complemento)
                    .HasColumnName("Complemento")
                    .HasColumnType("varchar(100)");

                e.Property(pe => pe.Bairro)
                    .HasColumnName("Bairro")
                    .HasColumnType("varchar(50)");

                e.Property(pe => pe.Cep)
                    .HasColumnName("Cep")
                    .HasColumnType("char(10)");


                e.Property(pe => pe.Cidade)
                    .HasColumnName("Cidade")
                    .HasColumnType("varchar(80)");

                e.Property(pe => pe.Estado)
                    .HasColumnName("Estado")
                    .HasColumnType("char(2)");
            });




            // 1 : N => Funcionario : Escalas
            builder.HasMany(c => c.EscalaSemanal)
                .WithOne(c => c.Funcionario)
                .HasForeignKey(c => c.FuncionarioId);

           
            builder.ToTable("Funcionario");

            builder.Ignore(c => c.ValidationResult);

        }

    }
}
