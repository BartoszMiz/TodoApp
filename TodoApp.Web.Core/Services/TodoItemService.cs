using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Web.Core.Models;
using TodoApp.Web.Core.Contexts;
using System.Linq;

namespace TodoApp.Web.Core.Services
{
	public class TodoItemService : ITodoItemProvider, ITodoItemAdder
	{
		private readonly TodoItemDbContext dbContext;

		public TodoItemService(TodoItemDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public Task<TodoItem> GetTodoItemAsync(int id)
		{
			return Task.FromResult(dbContext.TodoItems.FirstOrDefault(x => x.Id == id));
		}

		public Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
		{
			return Task.FromResult((IEnumerable<TodoItem>)dbContext.TodoItems);
		}

		public async Task AddTodoItemAsync(TodoItem item)
		{
			await dbContext.TodoItems.AddAsync(item);
			await dbContext.SaveChangesAsync();
		}
	}
}
