using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MvcApp.Models;

namespace MvcApp.ViewModels
{
    public class Index
    {
        public List<Todo> Todos { get; set; }
    }
}