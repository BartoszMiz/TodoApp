using System;

namespace TodoApp.Web.Core.Services
{
	public interface IDateTimeProvider
	{
		public DateTime Now { get; }
	}
}
