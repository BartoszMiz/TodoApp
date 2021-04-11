using System.Threading.Tasks;
using TodoApp.Web.Core.Models;

namespace TodoApp.Web.Core.Services
{
	public interface ITodoItemCompleter
	{
		public Task CompleteTodoItemAsync(int id);
	}
}