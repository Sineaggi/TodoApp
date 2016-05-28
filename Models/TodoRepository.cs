using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TodoApp.Models
{
    public class TodoRepository : ITodoRepository
    {
        static ConcurrentDictionary<string, Todo> _todos = new ConcurrentDictionary<string, Todo>();

        public TodoRepository()
        {
            Add(new Todo { Contents = "Item1" });
        }

        public IEnumerable<Todo> GetAll()
        {
            return _todos.Values;
        }

        public void Add(Todo item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public Todo Find(string key)
        {
            Todo item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public Todo Remove(string key)
        {
            Todo item;
            _todos.TryGetValue(key, out item);
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(Todo item)
        {
            _todos[item.Key] = item;
        }
    }
}