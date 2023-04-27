using ExamProgram.Data.DbContext;
using ExamProgram.Data.IRepository;
using Npgsql;
using System.Threading.Tasks;

namespace ExamProgram.Data.Repository
{
    public class GenericRepository : IGenericRepositoriy
    {
        private readonly ExamProgrmDbContext _dbContext;
        private readonly NpgsqlCommand _command;

        public GenericRepository()
        {
            _dbContext = new ExamProgrmDbContext();
            _command = new NpgsqlCommand();
        }

        public async Task<int> CreateAsync(string query)
        {
            _command.CommandText = query;
            _command.Connection = _dbContext.Connection();
            return await _command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteAsync(string query)
        {
            _command.CommandText = query;
            _command.Connection = _dbContext.Connection();
            return await _command.ExecuteNonQueryAsync();
        }

        public async Task<NpgsqlDataReader> GetAllAsync(string query)
        {
            _command.CommandText = query;
            _command.Connection = _dbContext.Connection();
            return await _command.ExecuteReaderAsync();
        }

        public async Task<NpgsqlDataReader> GetAsync(string query)
        {
            _command.CommandText = query;
            _command.Connection = _dbContext.Connection();
            return await _command.ExecuteReaderAsync();
        }

        public async Task<int> UpdateAsync(string query)
        {
            _command.CommandText = query;
            _command.Connection = _dbContext.Connection();
            return await _command.ExecuteNonQueryAsync();
        }

        public async Task CloseAsync()
        {
           await _dbContext.Connection().CloseAsync();
        }
    }
}
