using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Web.Core.Models;

namespace TodoApp.Web.Core.Contexts
{
    public interface ITodoItemDbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public Task<int> SaveChangesAsync();
        public void Update(TodoItem item);
    }
}