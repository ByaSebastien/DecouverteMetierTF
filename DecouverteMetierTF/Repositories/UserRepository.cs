using DecouverteMetierTF.Models;
using System.Data;

namespace DecouverteMetierTF.Repositories
{
    public class UserRepository
    {
        private IDbConnection _connection;
        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        protected User Convert(IDataRecord dataRecord)
        {
            return new User
            {
                Id = (int)dataRecord["Id"],
                Username = (string)dataRecord["Username"],
                Email = (string)dataRecord["Email"],
                Password = (string)dataRecord["Password"],
            };
        }
        protected void GenerateParameter(IDbCommand command, string name, object data)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = data ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }
        public void Register(UserRegisterDTO u)
        {
            using (IDbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "Insert into [User](Username,Email,Password) " +
                                      "Values (@username,@email,@password)";
                GenerateParameter(command, "@username", u.Username);
                GenerateParameter(command, "@email", u.Email);
                GenerateParameter(command, "@password", u.Password);
                _connection.Open();
                command.ExecuteScalar();
                _connection.Close();
            }
        }
        public User Login(string login, string password)
        {
            using (IDbCommand command = _connection.CreateCommand())
            {
                User user;
                command.CommandText = "select * " +
                                      "from [user] " +
                                      "where username like(@login) OR email like(@login)";
                GenerateParameter(command, "@login", login);
                _connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        user = Convert(reader);
                    else
                        throw new ArgumentNullException($"User Inexistant");
                }
                _connection.Close();
                if (password == user.Password)
                    return user;
                throw new UnauthorizedAccessException("Password invalid");
            }
        }
    }
}
