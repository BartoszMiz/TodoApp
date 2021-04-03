using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoApp.Web.Models;
using TodoApp.Web.Services;

namespace TodoApp.Web.Pages
{
	public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
		private readonly ITodoItemProvider todoItemProvider;
		public IEnumerable<TodoItem> TodoItems { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, ITodoItemProvider todoItemProvider)
		{
            _logger = logger;
			this.todoItemProvider = todoItemProvider;
		}

        public void OnGet()
        {
			TodoItems = todoItemProvider.GetTodoItems();
        }
    }
}
