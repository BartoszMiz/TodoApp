using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using TodoApp.Web.Core.Models;

namespace TodoApp.Web.Core.Services
{
	public class TodoItemJsonProvider : ITodoItemProvider
	{
		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly string jsonFilePath;
		private TodoItem[] storedItems;

		public TodoItemJsonProvider(IWebHostEnvironment webHostEnvironment)
		{
			this.webHostEnvironment = webHostEnvironment;
			jsonFilePath = Path.Combine(webHostEnvironment.WebRootPath, "todo-items.json");
		}

		private void FetchTodoItems()
		{
			using(var fileReader = File.OpenText(jsonFilePath))
			{
				var jsonText = fileReader.ReadToEnd();
				storedItems = JsonSerializer.Deserialize<TodoItem[]>(jsonText, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
			}
		}

		public Task<TodoItem> GetTodoItemAsync(int id)
		{
			if(storedItems == null)
				FetchTodoItems();

			if(id < storedItems.Length && id >= 0)
				return Task.FromResult(storedItems[id]);
			else
				return null;
		}

		public Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
		{
			if(storedItems == null)
				FetchTodoItems();
			return Task.FromResult((IEnumerable<TodoItem>)storedItems);
		}
	}
}