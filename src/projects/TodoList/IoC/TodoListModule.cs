using Microsoft.Extensions.DependencyInjection;
using TodoList.DataAccess;
using TodoList.Services;

namespace TodoList.IoC
{
    public static class TodoListModule
    {
        public static void InitialiseDependencyInjections(IServiceCollection services)
        {
            SetupServices(services);
            SetupRepository(services);
        }

        private static void SetupServices(IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();
        }

        private static void SetupRepository(IServiceCollection services)
        {
            services.AddScoped<ITodoRepository, TodoRepository>();
        }
    }
}
