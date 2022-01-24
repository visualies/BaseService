using BaseService.Core.Repositories;
using System;

namespace BaseService.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IExampleRepository ExampleRepository { get; }
        void Commit();
    }
}
