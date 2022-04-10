using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Avaliacao.Domain.RH;
using Avaliacao.Core.Data;

namespace Avaliacao.Data
{ 
    public class AvaliacaoContext : DbContext, IUnitOfWork
    {
       
        public AvaliacaoContext(DbContextOptions<AvaliacaoContext> options)
            : base(options)
        {
            
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Escala> Escalas { get; set; }



        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            return sucesso;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //Inclui os mapeamentos do mesmo assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AvaliacaoContext).Assembly);
                       
            base.OnModelCreating(modelBuilder);
        }
    }
}
