using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        ITodoRepository TodoItems;
        public TodoController(ITodoRepository todoItems)
        {
            TodoItems = todoItems;
        }

        public IEnumerable<Todo> GetAll()
        {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            Console.WriteLine("Id passed in is [" + id + "]");
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Todo item)
        {
            Console.WriteLine("POST!!!!!!!");
            if (!ModelState.IsValid) {
                Console.WriteLine("Bad data");
                return BadRequest();
            }
            if (item == null)
            {
                return BadRequest();
            }
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { controller = "Todo", id = item.Key }, item);
        }
    }
}