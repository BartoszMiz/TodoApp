using NSubstitute;
using TodoApp.Web.Core.Models;
using TodoApp.Web.Core.Services;
using System;
using FluentAssertions;
using Xunit;

namespace TodoApp.Web.Core.Tests
{
	public class TodoItemDeadlineStateCalculatorTests
	{
		private readonly IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
		private readonly TodoItemDeadlineStateCalculator sut;

		public TodoItemDeadlineStateCalculatorTests()
		{
			sut = new TodoItemDeadlineStateCalculator(dateTimeProvider);
		}

		[Fact]
		public void CalculateItemDeadlineState_ShouldReturnUncompletedDeadlineState_WhenTodoItemIsNotCompletedAndNotNearDeadline()
		{
			// Arrange
			var todoItem = new TodoItem
			{
				Id = 0,
				Instruction = string.Empty,
				Deadline = new DateTime(2021, 1, 10),
				AdditionDate = new DateTime(),
				IsCompleted = false
			};

			dateTimeProvider.Now.Returns(new DateTime(2021, 1, 1));

			// Act
			var deadlineState = sut.CalculateItemDeadlineState(todoItem);

			// Assert
			deadlineState.Should().Be(ItemDeadlineState.UNCOMPLETED);
		}

		[Fact]
		public void CalculateItemDeadlineState_ShouldReturnCompletedDeadlineState_WhenTodoItemIsCompleted()
		{
			// Arrange
			var todoItem = new TodoItem
			{
				Id = 0,
				Instruction = string.Empty,
				Deadline = new DateTime(2021, 1, 10),
				AdditionDate = new DateTime(),
				IsCompleted = true
			};

			dateTimeProvider.Now.Returns(new DateTime(2021, 1, 1));

			// Act
			var deadlineState = sut.CalculateItemDeadlineState(todoItem);

			// Assert
			deadlineState.Should().Be(ItemDeadlineState.COMPLETED);
		}

		[Fact]
		public void CalculateItemDeadlineState_ShouldReturnPastDeadlineState_WhenCurrentDateIsPastDeadline()
		{
			// Arrange
			var todoItem = new TodoItem
			{
				Id = 0,
				Instruction = string.Empty,
				Deadline = new DateTime(2021, 1, 10),
				AdditionDate = new DateTime(),
				IsCompleted = false
			};

			dateTimeProvider.Now.Returns(new DateTime(2021, 1, 11));

			// Act
			var deadlineState = sut.CalculateItemDeadlineState(todoItem);

			// Assert
			deadlineState.Should().Be(ItemDeadlineState.PAST_DEADLINE);
		}

		[Fact]
		public void CalculateItemDeadlineState_ShouldReturnNearDeadlineState_WhenCurrentDateIsOneDayOrLessBeforeDeadline()
		{
			// Arrange
			var todoItem = new TodoItem
			{
				Id = 0,
				Instruction = string.Empty,
				Deadline = new DateTime(2021, 1, 10),
				AdditionDate = new DateTime(),
				IsCompleted = false
			};

			dateTimeProvider.Now.Returns(new DateTime(2021, 1, 9));

			// Act
			var deadlineState = sut.CalculateItemDeadlineState(todoItem);

			// Assert
			deadlineState.Should().Be(ItemDeadlineState.NEAR_DEADLINE);
		}

		[Fact]
		public void CalculateItemDeadlineState_ShouldThrowNullReferenceException_WhenTodoItemIsNull()
		{
			// Arrange
			TodoItem todoItem = null;
			dateTimeProvider.Now.Returns(new DateTime(2021, 1, 1));

			// Act
			Func<ItemDeadlineState> testedFunction = () => sut.CalculateItemDeadlineState(todoItem);

			// Assert
			testedFunction.Should().Throw<NullReferenceException>();
		}
	}
}
