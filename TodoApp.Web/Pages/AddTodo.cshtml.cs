using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.Web.Core.Models;
using TodoApp.Web.Core.Services;

namespace TodoApp.Web.Pages
{
    public class AddTodoModel : PageModel
    {
		private readonly ITodoItemAdder itemService;
		public readonly IDateTimeProvider DateTimeProvider;

		[Required] [BindProperty]
		public string Instruction { get; set; }
		[Required] [BindProperty]
		public string DeadlineDate { get; set; }
		[Required] [BindProperty]
		public string DeadlineTime { get; set; }

		public AddTodoModel(ITodoItemAdder itemService, IDateTimeProvider dateTimeProvider)
		{
			this.itemService = itemService;
			this.DateTimeProvider = dateTimeProvider;
		}

		public void OnGet()
        {
        }

		public async Task<IActionResult> OnPostAsync()
		{
			// var instruction = Request.Form["instruction"].ToString();
			// var deadlineDate = Request.Form["deadline-date"].ToString();
			// var deadlineTime = Request.Form["deadline-time"].ToString();

			if(ModelState.IsValid)
			{
				var deadline = DateTime.Parse(DeadlineDate) + DateTime.Parse(DeadlineTime).TimeOfDay;

				var todoItem = new TodoItem
				{
					Instruction = Instruction,
					AdditionDate = DateTimeProvider.Now,
					Deadline = deadline,
					IsCompleted = false
				};

				await itemService.AddTodoItemAsync(todoItem);
			}
			return RedirectToPage("Index");
		}
    }
}
