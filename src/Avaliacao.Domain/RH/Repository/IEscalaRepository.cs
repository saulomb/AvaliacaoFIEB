using Avaliacao.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avaliacao.Domain.RH.Repository
{
    public interface IEscalaRepository : IRepository<Escala>
    {

        Task<IEnumerable<Escala>> ObterPorFuncionario(int funcionarioId);
        Task<Escala> ObterPorId(int Id);
        void Adicionar(Escala escala);
        void Atualizar(Escala escala);
        void Remover(Escala escala);



    }
}
