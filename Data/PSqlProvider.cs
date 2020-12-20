using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Models;
using Npgsql;
using System.Data;

namespace Todos.Data
{
    public class PSqlProvider : IDbProvider
    {
        private readonly IConfiguration configuration;
        private string connectionString;

        public PSqlProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration["ConnectionStrings:Todos"];
        }

        public void DeleteTodo(int id)
        {
            
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(connectionString))
                {
                    NpgsqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "DELETE FROM  public.todos WHERE id=@id";
                    cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    
                }
            }
            catch (Exception ex)
            {
                
            }
            
        }

        public IEnumerable<Todo> GetTodos()
        {
            List<Todo> list = new List<Todo>();

            try
            {
                using(NpgsqlConnection cn = new NpgsqlConnection(connectionString))
                {
                    NpgsqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT id, action FROM public.todos";
                    cn.Open();

                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Todo item = new Todo();

                        item.Id = Convert.ToInt32(reader["id"].ToString());
                        item.Action = reader["action"].ToString();

                        list.Add(item);
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return list;
        }

        public bool SaveTodo(Todo todo)
        {
            bool success = false;
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(connectionString))
                {
                    NpgsqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO public.todos (action) VALUES(@action) ";
                    cmd.Parameters.Add("@action", NpgsqlTypes.NpgsqlDbType.Varchar).Value = todo.Action;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                }
            }
            catch(Exception ex)
            {
                success = false;
            }
            return success;
        }
    }
}
