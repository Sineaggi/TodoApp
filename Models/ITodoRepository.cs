using System.Collections.Generic;

namespace TodoApp.Models
{
    public interface ITodoRepository
    {
        void Add(Todo item);
        IEnumerable<Todo> GetAll();
        Todo Find(string key);
        Todo Remove(string key);
        void Update(Todo item);
    }
}