using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Models;

namespace Todos.Data
{
    public interface IDbProvider
    {
        IEnumerable<Todo> GetTodos();
        bool SaveTodo(Todo todo);
        void DeleteTodo(int id);
    }
}
