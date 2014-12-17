using System;
using Microsoft.AspNet.Mvc;
using MvcApp.Models;
using System.Linq;

namespace MvcApp
{
    public class HomeController : Controller
    {
        private readonly AppContext db;

        public HomeController(AppContext context)
        {
            db = context;
        }

        public IActionResult Create()
        {
            var todo = new Todo();
            return View(todo);
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            todo.CreatedAt = DateTime.Now;
            todo.UpdatedAt = DateTime.Now;
            db.Todos.Add(todo);
            db.SaveChanges();

            return Redirect("/");
        }

        [HttpPost]
        public IActionResult Toggle(string id)
        {
            var todo = db.Todos.Where(t => t.Name.Equals(id)).FirstOrDefault();
            if (todo != null) {
                todo.Completed = !todo.Completed;
                todo.UpdatedAt = DateTime.Now;
                db.SaveChanges();
            }

            return Redirect("/");
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var todo = db.Todos.Where(t => t.Name.Equals(id)).FirstOrDefault();
            if (todo != null) {
                db.Todos.Remove(todo);
                db.SaveChanges();
            }

            return Redirect("/");
        }

        public IActionResult Index()
        {
            var todos = db.Todos.Select(p => p).ToList();
            var vm = new MvcApp.ViewModels.Index{
                Todos = todos
            };
            return View(vm);
        }
    }
}