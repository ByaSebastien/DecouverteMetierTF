using DecouverteMetierTF.Models;
using System.Data;

namespace DecouverteMetierTF.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(IDbConnection connection) : base(connection, "Category", "Id")
        {
        }

        protected override Category Convert(IDataRecord dataRecord)
        {
            return new Category
            {
                Id = (int)dataRecord["Id"],
                Name = (string)dataRecord["Name"]
            };
        }

        public override void Add(Category c)
        {
            using (IDbCommand command = _Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Category(name) " +
                                      "Values(@name)";
                GenerateParameter(command, "@name", c.Name);
                _Connection.Open();
                command.ExecuteScalar();
                _Connection.Close();
            }
        }

        public override bool Update(Category c)
        {
            using (IDbCommand command = _Connection.CreateCommand())
            {
                command.CommandText = "UPDATE Category " +
                                      "SET [Name] = @name " +
                                      "WHERE [ID] = @id";
                GenerateParameter(command, "@name", c.Name);
                GenerateParameter(command, "@id", c.Id);
                _Connection.Open();
                bool isSucceed = command.ExecuteNonQuery() == 1;
                _Connection.Close();
                return isSucceed;
            }
        }

    }
}
