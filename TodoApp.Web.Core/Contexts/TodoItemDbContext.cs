using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Web.Core.Models;

namespace TodoApp.Web.Core.Contexts
{
	public class TodoItemDbContext : DbContext, ITodoItemDbContext
	{
		public DbSet<TodoItem> TodoItems { get; set; }

		public TodoItemDbContext(DbContextOptions<TodoItemDbContext> options) : base(options) {	}
		
		public Task<int> SaveChangesAsync() => base.SaveChangesAsync();

		public void Update(TodoItem item) => base.Update(item);
	}
}