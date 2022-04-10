using System;


namespace Avaliacao.Core.Data
{
    public interface IRepository<T> : IDisposable 
    {
        IUnitOfWork UnitOfWork { get; }
    }
}