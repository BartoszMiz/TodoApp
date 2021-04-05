using System;

namespace TodoApp.Web.Core.Services
{
	public class DefaultDateTimeProvider : IDateTimeProvider
	{
		public DateTime Now => DateTime.Now;
	}
}
