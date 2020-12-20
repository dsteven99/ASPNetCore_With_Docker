using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Models;

namespace Todos.Services
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetTodos();
        bool SaveTodo(Todo todo);
        void DeleteTodo(int id);
    }
}
