using Microsoft.EntityFrameworkCore;
using TodoApp.Web.Core.Models;

namespace TodoApp.Web.Core.Contexts
{
	public class TodoItemDbContext : DbContext
	{
		public DbSet<TodoItem> TodoItems { get; set; }

		public TodoItemDbContext(DbContextOptions<TodoItemDbContext> options) : base(options) {	}
	}
}