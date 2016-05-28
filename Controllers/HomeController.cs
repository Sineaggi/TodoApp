using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = new User() {
                Name = "s"
            };
            return View(user);
        }
    }
}