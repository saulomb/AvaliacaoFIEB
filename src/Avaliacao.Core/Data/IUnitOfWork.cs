using System.Threading.Tasks;

namespace Avaliacao.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}