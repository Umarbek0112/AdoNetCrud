using ExamProgram.Data.DbContext;
using ExamProgram.Data.IRepository;
using Npgsql;
using System.Threading.Tasks;

namespace ExamProgram.Data.Repository
{
    public class GenericRepository : IGenericRepositoriy
    {
        public async Task<int> CreateAsync(string query)
        {
            ExamProgrmDbContext _dbContext = new ExamProgrmDbContext();
            NpgsqlCommand _command = new NpgsqlCommand();
            _command.CommandText = query;
            _command.Connection = _dbContext.Connection();
            return await _command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteAsync(string query)
        {
            ExamProgrmDbContext _dbContext = new ExamProgrmDbContext();
            NpgsqlCommand _command = new NpgsqlCommand();
            _command.CommandText = query;
            _command.Connection = _dbContext.Connection();
            return await _command.ExecuteNonQueryAsync();
        }

        public async Task<NpgsqlDataReader> GetAllAsync(string query)
        {
            ExamProgrmDbContext _dbContext = new ExamProgrmDbContext();
            NpgsqlCommand _command = new NpgsqlCommand();
            _command.CommandText = query;
            _command.Connection = _dbContext.Connection();
            return await _command.ExecuteReaderAsync();
        }

        public async Task<NpgsqlDataReader> GetAsync(string query)
        {
            ExamProgrmDbContext _dbContext = new ExamProgrmDbContext();
            NpgsqlCommand _command = new NpgsqlCommand();
            _command.CommandText = query;
            _command.Connection = _dbContext.Connection();
            return await _command.ExecuteReaderAsync();
        }

        public async Task<int> UpdateAsync(string query)
        {
            ExamProgrmDbContext _dbContext = new ExamProgrmDbContext();
            NpgsqlCommand _command = new NpgsqlCommand();
            _command.CommandText = query;
            _command.Connection = _dbContext.Connection();
            return await _command.ExecuteNonQueryAsync();
        }

        public async Task CloseAsync()
        {
            ExamProgrmDbContext _dbContext = new ExamProgrmDbContext();
            await _dbContext.Connection().CloseAsync();
        }
    }
}
