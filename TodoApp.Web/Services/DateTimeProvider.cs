using System;

namespace TodoApp.Web.Services
{
	public class DefaultDateTimeProvider : IDateTimeProvider
	{
		public DateTime Now => DateTime.Now;
	}
}
