using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Data;
using Todos.Models;

namespace Todos.Services
{
    public class TodoService : ITodoService
    {
        private readonly IDbProvider dbProvider;

        public TodoService(IDbProvider dbProvider)
        {
            this.dbProvider = dbProvider;
        }

        public void DeleteTodo(int id)
        {
            dbProvider.DeleteTodo(id);
        }

        public IEnumerable<Todo> GetTodos()
        {
            return dbProvider.GetTodos();
        }

        public bool SaveTodo(Todo todo)
        {
            return dbProvider.SaveTodo(todo);
        }
    }
}
