using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoApp.Web.Core.Models;
using TodoApp.Web.Core.Services;
using System.Threading.Tasks;
using System.Linq;

namespace TodoApp.Web.Pages
{
	public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
		private readonly ITodoItemProvider todoItemProvider;
		public readonly TodoItemDeadlineStateCalculator itemDeadlineStateCalculator;
		public TodoItem[] TodoItems { get; private set; }

		public IndexModel(
			ILogger<IndexModel> logger,
			ITodoItemProvider todoItemProvider,
			TodoItemDeadlineStateCalculator itemDeadlineStateCalculator)
		{
			_logger = logger;
			this.todoItemProvider = todoItemProvider;
			this.itemDeadlineStateCalculator = itemDeadlineStateCalculator;
		}

		public async Task OnGetAsync()
        {
			TodoItems = (await todoItemProvider.GetTodoItemsAsync()).ToArray();
        }
    }
}
