using System.Collections.Generic;
using TodoApp.Web.Core.Models;

namespace TodoApp.Web.Core.Services
{
	public interface ITodoItemProvider
	{
		public IEnumerable<TodoItem> GetTodoItems();
		public TodoItem GetTodoItem(int id);
	}
}