using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.Web.Core.Services;

namespace TodoApp.Web.Pages
{
    public class CompleteTaskModel : PageModel
    {
		private readonly ITodoItemCompleter itemCompleter;

		public CompleteTaskModel(ITodoItemCompleter itemCompleter)
		{
			this.itemCompleter = itemCompleter;
		}

		[BindProperty(SupportsGet = true)]
		public int ItemIndex { get; set; }
        public async Task<IActionResult> OnGet()
        {
			await itemCompleter.CompleteTodoItemAsync(ItemIndex);
			return RedirectToPage("Index");
        }
    }
}