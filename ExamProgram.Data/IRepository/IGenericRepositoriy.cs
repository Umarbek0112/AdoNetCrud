using Npgsql;
using System.Threading.Tasks;

namespace ExamProgram.Data.IRepository
{
    public interface IGenericRepositoriy
    {
        public Task<NpgsqlDataReader> GetAsync(string query);
        public Task<NpgsqlDataReader> GetAllAsync(string query);
        public Task<int> CreateAsync(string query);
        public Task<int> UpdateAsync(string query);
        public Task<int> DeleteAsync(string query);
        public Task CloseAsync();

    }
}