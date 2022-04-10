using Avaliacao.Core.Data;
using Avaliacao.Domain.RH;
using Avaliacao.Domain.RH.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Data.Repository
{
    public class CargoRepository : ICargoRepository
    {

        private readonly AvaliacaoContext _context;

        public CargoRepository(AvaliacaoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public async Task<IEnumerable<Cargo>> ObterTodos()
        {
            return await _context.Cargos.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
