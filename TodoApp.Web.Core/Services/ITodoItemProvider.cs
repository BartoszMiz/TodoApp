using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Web.Core.Models;

namespace TodoApp.Web.Core.Services
{
	public interface ITodoItemProvider
	{
		public Task<IEnumerable<TodoItem>> GetTodoItemsAsync();
		public Task<TodoItem> GetTodoItemAsync(int id);
	}
}