using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Todos.Models;
using Todos.Services;

namespace Todos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration configuration;
        private readonly ITodoService todoService;
        public IEnumerable<Todo> Todos;
        
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, ITodoService todoService)
        {
            _logger = logger;
            this.configuration = configuration;
            this.todoService = todoService;

        }

        public void OnGet()
        {
            Todos = todoService.GetTodos();
        }

        public void OnPost(int Id)
        {

            todoService.DeleteTodo(Id);

            Todos = todoService.GetTodos();
        }
    }
}
