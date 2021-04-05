using System;
using System.Text.Json.Serialization;

namespace TodoApp.Web.Models
{
	public class TodoItem
	{
		public int Id { get; set; }
		public string Instruction { get; set; }
		[JsonPropertyName("addition-date")]
		public DateTime AdditionDate { get; set; }
		public DateTime Deadline { get; set; }
		[JsonPropertyName("is-completed")]
		public bool IsCompleted { get; set; }
	}
}