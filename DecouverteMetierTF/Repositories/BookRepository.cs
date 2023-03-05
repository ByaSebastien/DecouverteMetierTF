using DecouverteMetierTF.Models;
using System.Data;

namespace DecouverteMetierTF.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(IDbConnection connection) : base(connection, "Book", "Id")
        {
        }

        protected override Book Convert(IDataRecord dataRecord)
        {
            return new Book
            {
                Id = (int)dataRecord["Id"],
                Title = (string)dataRecord["Title"],
                Author = (string)dataRecord["Author"],
                Description = dataRecord["Description"] == DBNull.Value ? null : (string)dataRecord["Description"],
                CategoryId = (int)dataRecord["CategoryId"]
            };
        }
        public override void Add(Book b)
        {
            using(IDbCommand command = _Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO BOOK(Title,Author,Description,CategoryId) " +
                                      "Values(@title,@author,@description,@categoryId)";
                GenerateParameter(command, "@title", b.Title);
                GenerateParameter(command, "@author", b.Author);
                GenerateParameter(command, "@description", b.Description);
                GenerateParameter(command, "@categoryId", b.CategoryId);
                _Connection.Open();
                command.ExecuteScalar();
                _Connection.Close();
            }
        }

        public override bool Update(Book b)
        {
            using(IDbCommand command = _Connection.CreateCommand())
            {
                command.CommandText = "UPDATE BOOK " +
                                      "SET [TITLE] = @title, " +
                                          "[AUTHOR] = @author, " +
                                          "[DESCRIPTION] = @description, " +
                                          "[CATEGORYID] = @categoryId " +
                                      "WHERE [ID] = @id";
                GenerateParameter(command, "@title", b.Title);
                GenerateParameter(command, "@author", b.Author);
                GenerateParameter(command, "@description", b.Description);
                GenerateParameter(command, "@categoryId", b.CategoryId);
                GenerateParameter(command, "@id", b.Id);
                _Connection.Open();
                bool isSucceed = command.ExecuteNonQuery() == 1;
                _Connection.Close();
                return isSucceed;
            }
        }
        public void AddFavorite(int userId,int bookId)
        {
            using (IDbCommand command = _Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO UserFavorite(UserId,BookId) " +
                                      "Values(@userId,@bookId)";
                GenerateParameter(command, "@userId", userId);
                GenerateParameter(command, "@bookId", bookId);
                _Connection.Open();
                command.ExecuteScalar();
                _Connection.Close();
            }
        }
        public bool DeleteFavorite(int userId,int bookId)
        {
            using (IDbCommand command = _Connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM UserFavorite " +
                                      "WHERE UserId = @userId AND BookId = @bookID";
                GenerateParameter(command, "@userId", userId);
                GenerateParameter(command, "@bookId", bookId);
                _Connection.Open();
                bool isSucceed = command.ExecuteNonQuery() == 1;
                _Connection.Close();
                return isSucceed;
            }
        }
        public IEnumerable<Book> GetAllFavorite(int userId)
        {
            using (IDbCommand command = _Connection.CreateCommand())
            {
                ICollection<Book> books = new List<Book>();
                command.CommandText = "SELECT b.Id,b.Title,b.Author,b.Description,b.CategoryId " +
                                      "FROM Book b join userFavorite u on u.BookId = b.Id " +
                                      "WHERE u.UserId = @userId";
                GenerateParameter(command, "@userId", userId);
                _Connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(Convert(reader));
                    }
                }
                _Connection.Close();
                return books;
            }
        }
        public IEnumerable<Book> GetByCategory(int categoryId)
        {
            using (IDbCommand command = _Connection.CreateCommand())
            {
                ICollection<Book> books = new List<Book>();
                command.CommandText = "SELECT * " +
                                      "FROM Book " +
                                      "WHERE CategoryId = @categoryId";
                GenerateParameter(command, "@categoryId", categoryId);
                _Connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(Convert(reader));
                    }
                }
                _Connection.Close();
                return books;
            }
        }
    }
}
