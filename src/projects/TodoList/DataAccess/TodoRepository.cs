using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TodoList.Dtos;

namespace TodoList.DataAccess
{
    public interface ITodoRepository
    {
        public Task<List<Todo>> GetTodos();
        public Task<Todo> GetTodoById(int id);
        public Task SaveTodo(Todo todo);
        public Task UpdateTodo(int id, Todo? todo = null);
    }

    public class TodoRepository : ITodoRepository
    {
        private readonly string cs = @"Server=ARTHUR;Database=Development;User Id=developer;Password=sql#developer;Trusted_Connection=True";

        private const string SqlGetTodoList = @"SELECT [ID], [Title], [DateCreated], [DateModified] FROM dbo.Todos " + 
            @"Where Deleted=1 ";


        //Search with parameters example

        //const string sql = @"
        //UPDATE Sales.SalesOrderHeader
        //SET STATUS = @status
        //WHERE SalesOrderID = @salesOrderId";

        //var param = new { status, salesOrderId };
        //using var conn = _db.GetAdventureWorksConnection();

        //return await conn.ExecuteAsync(sql, param)

        public async Task<List<Todo>> GetTodos()
        {
            List<Todo> result;
            using (var connect = new SqlConnection(cs))
            {
                connect.Open();
                System.Console.WriteLine(connect.ExecuteScalar<string>("SELECT @@VERSION"));
                result = (await connect.QueryAsync<Todo>(SqlGetTodoList).ConfigureAwait(false)).AsList();
            }
            return result;
        }

        public async Task<Todo> GetTodoById(int id)
        {
            Todo result;
            using (var connect = new SqlConnection(cs))
            {
                connect.Open();
                var sqlQueryTodo = SqlGetTodoList + $"AND ID = @id ";
                var parameter = new { id = id };
                result = await connect.QueryFirstAsync<Todo>(sqlQueryTodo, parameter).ConfigureAwait(false);
            }
            return result;
        }

        public async Task SaveTodo(Todo todo)
        {
            const string sql = @"INSERT INTO dbo.Todos(Title, DateCreated)
            VALUES(@title, @dateCreated)";
            var parameters = new { title = todo.Title, dateCreated = DateTime.UtcNow };
            using (var connect = new SqlConnection(cs))
            {
                connect.Open();
                await connect.ExecuteAsync(sql, parameters);
            }
        }

        public async Task UpdateTodo(int id, Todo? todo = null)
        {
            if(null == todo)
            {
                todo = await GetTodoById(id);
            }
            todo.Deleted = true;
            const string sql = @"UPDATE Development.dbo.Todos " +
                @"SET Title = @title, DateModified = @dateModified, Deleted=@deleted " +
                @"WHERE Id = @id";
            var parameters = new { 
                title = todo.Title, 
                dateModified = DateTime.UtcNow, 
                deleted = todo.Deleted, 
                id = id
            };
            using (var connect = new SqlConnection(cs))
            {
                connect.Open();
                await connect.ExecuteAsync(sql, parameters);
            }
        }
    }
}
