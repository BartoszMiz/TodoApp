using System;
using TodoApp.Web.Core.Models;

namespace TodoApp.Web.Core.Services
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

			var isPastDeadline = DateTime.Compare(todoItem.Deadline, dateTimeProvider.Now) < 0;
			if(isPastDeadline)
				return ItemDeadlineState.PAST_DEADLINE;

			var daysToDeadline = (todoItem.Deadline - dateTimeProvider.Now).Days;
			var isNearDeadline = daysToDeadline <= 1;
			if(isNearDeadline)
				return ItemDeadlineState.NEAR_DEADLINE;

			return ItemDeadlineState.UNCOMPLETED;
		}
	}
}
