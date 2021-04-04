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

		public ItemDeadlineState CalculateItemDeadlineState(DateTime itemDeadline)
		{
			var isPastDeadline = DateTime.Compare(itemDeadline, DateTime.Now) < 0;
			if(isPastDeadline)
				return ItemDeadlineState.PAST_DEADLINE;

			var daysToDeadline = (itemDeadline - dateTimeProvider.Now).Days;
			var isNearDeadline = daysToDeadline <= 0;
			if(isNearDeadline)
				return ItemDeadlineState.NEAR_DEADLINE;

			return ItemDeadlineState.UNCOMPLETED;
		}
	}
}
