using Microsoft.EntityFrameworkCore;

namespace ToDoVSCode.Models {

    public class TodoContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=todoconsole.db");

        public DbSet<TodoItem> TodoItems {get;set;}
    }
}