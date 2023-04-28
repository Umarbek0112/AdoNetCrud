using System;

namespace ExamProgram.Data.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepositoriy repositoriy {get; }
    }
}
