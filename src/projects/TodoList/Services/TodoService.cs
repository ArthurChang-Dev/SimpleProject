using System.Threading.Tasks;
using TodoList.DataAccess;
using TodoList.Dtos;

namespace TodoList.Services
{
    public interface ITodoService
    {
        public Task<TodoResult> GetTodos();
        public Task SaveTodo(Todo todo);
    }

    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoResult> GetTodos()
        {
            var todos = await _todoRepository.GetTodos();
            return new TodoResult { Todos = todos };
        }

        public async Task SaveTodo(Todo todo)
        {
            await _todoRepository.SaveTodo(todo);
        }
    }
}
