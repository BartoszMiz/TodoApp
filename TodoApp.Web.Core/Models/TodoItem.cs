using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoApp.Web.Core.Models
{
	public class TodoItem
	{
		[Key]
		public int Id { get; set; }
		public string Instruction { get; set; }
		[JsonPropertyName("addition-date")]
		public DateTime AdditionDate { get; set; }
		public DateTime Deadline { get; set; }
		[JsonPropertyName("is-completed")]
		public bool IsCompleted { get; set; }
	}
}