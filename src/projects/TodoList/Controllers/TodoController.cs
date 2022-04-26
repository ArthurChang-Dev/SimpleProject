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
            return await _todoService.GetTodos();
        }

        [HttpPost]
        [Route("create")]
        public async Task Create([FromBody] Todo todo)
        {
            await _todoService.SaveTodo(todo);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task Delete(int id)
        {
            await _todoService.UpdateTodo(id);
        }
    }
}
