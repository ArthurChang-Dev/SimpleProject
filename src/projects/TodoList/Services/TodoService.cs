using TodoList.DataAccess;
using TodoList.Dtos;

namespace TodoList.Services
{
    public interface ITodoService
    {
        public TodoResult GetTodos();
    }

    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public TodoResult GetTodos()
        {
            var todos = _todoRepository.GetTodos();
            return new TodoResult { Todos = todos };
        }
    }
}
