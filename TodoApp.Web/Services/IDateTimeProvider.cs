using System;

namespace TodoApp.Web.Services
{
	public interface IDateTimeProvider
	{
		public DateTime Now { get; }
	}
}
