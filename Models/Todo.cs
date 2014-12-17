using System;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
    public class Todo
    {
        [Key]
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        public bool Completed { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}