using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TodoList.Dtos;

namespace TodoList.DataAccess
{
    public interface ITodoRepository
    {
        public List<Todo> GetTodos();
    }

    public class TodoRepository : ITodoRepository
    {
        public List<Todo> GetTodos()
        {
            var cs = @"Server=ARTHUR;Database=Development;User Id=developer;Password=sql#developer;Trusted_Connection=True";

            List<Todo> result;
            using (var connect = new SqlConnection(cs))
            {
                connect.Open();
                System.Console.WriteLine(connect.ExecuteScalar<string>("SELECT @@VERSION"));
                result = connect.Query<Todo>("SELECT * FROM dbo.Todos").ToList();
            }
            return result;
        }
    }
}
