using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace MvcApp.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Todo>().Key(a => a.Name);
            base.OnModelCreating(builder);
        }
    }
}