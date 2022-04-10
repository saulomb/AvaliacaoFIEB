using Avaliacao.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avaliacao.Domain.RH.Repository
{
    public interface ICargoRepository : IRepository<Cargo>
    {

        Task<IEnumerable<Cargo>> ObterTodos();


    }
}
