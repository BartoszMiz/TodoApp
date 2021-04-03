using System;

namespace TodoApp.Web.Models
{
	public class TodoItem
	{
		public int Id { get; set; }
		public string Instruction { get; set; }
		public DateTime AdditionDate { get; set; }
		public DateTime Deadline { get; set; }
	}
}