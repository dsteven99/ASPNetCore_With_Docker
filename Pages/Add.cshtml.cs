using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todos.Models;
using Todos.Services;

namespace Todos.Pages
{
    public class AddModel : PageModel
    {
        private readonly ITodoService todoService;
        [BindProperty]
        public Todo Todo { get; set; }

        public IActionResult OnGet()
        {
            Todo = new Todo();
            return Page();
        }

        public AddModel(ITodoService todoService)
        {
            this.todoService = todoService;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool success = todoService.SaveTodo(Todo);

            if (!success)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
