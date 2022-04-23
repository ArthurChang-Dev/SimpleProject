using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Dtos;
using TodoList.Services;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<TodoResult> Get()
        {
            return new TodoResult { Todos = MockTodoList() };
        }

        private List<Todo> MockTodoList()
        {
            return new List<Todo>
            {
                new Todo{Id = 1, Title = "Fix the issue of the FE." },
                new Todo{Id = 2, Title = "Connect FE with BE. "},
                new Todo{Id = 3, Title = "Create DB for todo list. "},
                new Todo{Id = 4, Title = "Connect BE with DB. "},
                new Todo{Id = 5, Title = "For test. "},
            };
        }

        [HttpGet]
        [Route("test")]
        public TodoResult Test()
        {
            return _todoService.GetTodos();
        }
    }
}
