using System.Threading.Tasks;
using TodoApp.Web.Core.Models;

namespace TodoApp.Web.Core.Services
{
	public interface ITodoItemAdder
	{
		public Task AddTodoItemAsync(TodoItem item);
	}
}
