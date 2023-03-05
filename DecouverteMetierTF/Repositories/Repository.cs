using System.Data;

namespace DecouverteMetierTF.Repositories
{
    public abstract class Repository<TEntity> where TEntity : class
    {
        protected IDbConnection _Connection;
        public string TableName { get; init; }
        public string ColumnIdName { get; init; }

        public Repository(IDbConnection connection, string tableName, string columnIdName)
        {
            _Connection = connection;
            TableName = tableName;
            ColumnIdName = columnIdName;
        }

        protected void GenerateParameter(IDbCommand command, string name, object data)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = data ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }

        protected abstract TEntity Convert(IDataRecord dataRecord);


        #region CRUD
        public abstract void Add(TEntity entity);

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (IDbCommand command = _Connection.CreateCommand())
            {
                ICollection<TEntity> entities = new List<TEntity>();
                command.CommandText = $"SELECT * FROM {TableName}";
                _Connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entities.Add(Convert(reader));
                    }
                }
                _Connection.Close();
                return entities;
            }
        }

        public virtual TEntity GetById(int id)
        {
            using (IDbCommand command = _Connection.CreateCommand())
            {
                TEntity entity;
                command.CommandText = $"SELECT * FROM {TableName} WHERE {ColumnIdName} = @Id";
                _Connection.Open();
                GenerateParameter(command, "id", id);
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        entity = Convert(reader);
                    else
                        throw new ArgumentNullException($"{TableName} Inexistant");
                }
                _Connection.Close();
                return entity;
            }
        }

        public abstract bool Update(TEntity entity);

        public virtual bool Delete(int id)
        {
            using (IDbCommand command = _Connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM {TableName} WHERE {ColumnIdName} = @Id";
                GenerateParameter(command, "@Id", id);
                _Connection.Open();
                bool isSucceed = command.ExecuteNonQuery() == 1;
                _Connection.Close();
                return isSucceed;
            }
        }
        #endregion
    }
}
