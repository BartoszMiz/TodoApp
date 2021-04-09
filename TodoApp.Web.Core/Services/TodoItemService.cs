using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Web.Core.Models;
using TodoApp.Web.Core.Contexts;

namespace TodoApp.Web.Core.Services
{
	public class TodoItemService : ITodoItemProvider
	{
		private readonly TodoItemDbContext dbContext;

		public async Task<TodoItem> GetTodoItemAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
		{
			throw new System.NotImplementedException();
		}
	}
}