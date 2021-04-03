using System.Collections.Generic;
using TodoApp.Web.Models;

namespace TodoApp.Web.Services
{
	public interface ITodoItemProvider
	{
		public IEnumerable<TodoItem> GetTodoItems();
		public TodoItem GetTodoItem(int id);
	}
}