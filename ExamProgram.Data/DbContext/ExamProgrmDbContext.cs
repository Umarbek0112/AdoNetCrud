using ExamProgram.Data.Settings;
using Npgsql;
using System.Data;

namespace ExamProgram.Data.DbContext
{
    public class ExamProgrmDbContext
    {
        private NpgsqlConnection _connection;
        public NpgsqlConnection Connection()
        {
            _connection = new NpgsqlConnection(Constants.DbContextString);

            if (_connection.State == ConnectionState.Open)
                _connection.Close();

            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
                return _connection;
            }
            else
                return null;
        }
    }
}
