using System;
using TodoApp.Web.Models;

namespace TodoApp.Web.Services
{
	public class TodoItemDeadlineStateCalculator
	{
		private readonly IDateTimeProvider dateTimeProvider;

		public TodoItemDeadlineStateCalculator(IDateTimeProvider dateTimeProvider)
		{
			this.dateTimeProvider = dateTimeProvider;
		}

		public ItemDeadlineState CalculateItemDeadlineState(TodoItem todoItem)
		{
			if(todoItem.IsCompleted)
				return ItemDeadlineState.COMPLETED;

			var isPastDeadline = DateTime.Compare(todoItem.Deadline, DateTime.Now) < 0;
			if(isPastDeadline)
				return ItemDeadlineState.PAST_DEADLINE;

			var daysToDeadline = (todoItem.Deadline - dateTimeProvider.Now).Days;
			var isNearDeadline = daysToDeadline <= 0;
			if(isNearDeadline)
				return ItemDeadlineState.NEAR_DEADLINE;

			return ItemDeadlineState.UNCOMPLETED;
		}
	}
}
