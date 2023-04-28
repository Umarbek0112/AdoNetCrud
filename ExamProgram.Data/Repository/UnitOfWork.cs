

using ExamProgram.Data.IRepository;

namespace ExamProgram.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepositoriy repositoriy { get; }

        public UnitOfWork()
        {
            repositoriy = new GenericRepository();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
