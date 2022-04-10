using Avaliacao.Core.Data;
using Avaliacao.Domain.RH;
using Avaliacao.Domain.RH.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Data.Repository
{
    public class EscalaRepository : IEscalaRepository
    {

        private readonly AvaliacaoContext _context;

        public EscalaRepository(AvaliacaoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public async Task<IEnumerable<Escala>> ObterPorFuncionario(int funcionarioId)
        {
            return await _context.Escalas.Where(f=> f.FuncionarioId == funcionarioId).AsNoTracking().ToListAsync();
        }


        public async Task<Escala> ObterPorId(int Id)
        {
            return await _context.Escalas.FindAsync(Id);
        }


        public void Adicionar(Escala escala)
        {
            _context.Escalas.Add(escala);
        }

        public void Atualizar(Escala escala)
        {
            _context.Escalas.Update(escala);
        }

        public void Remover(Escala escala)
        {
            _context.Escalas.Remove(escala);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
