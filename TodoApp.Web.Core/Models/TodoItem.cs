using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoApp.Web.Core.Models
{
	public class TodoItem
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Instruction { get; set; }
		[JsonPropertyName("addition-date")] [Required]
		public DateTime AdditionDate { get; set; }
		[Required]
		public DateTime Deadline { get; set; }
		[JsonPropertyName("is-completed")] [Required]
		public bool IsCompleted { get; set; }
	}
}