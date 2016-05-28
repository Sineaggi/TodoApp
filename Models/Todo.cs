using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class Todo
    {
        public string Key { get; set; }
        public string Contents { get; set; }
    }
}