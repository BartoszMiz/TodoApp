using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using TodoApp.Web.Core.Contexts;
using TodoApp.Web.Core.Models;
using TodoApp.Web.Core.Services;
using Xunit;

namespace TodoApp.Web.Core.Tests
{
	public class TodoItemServiceTests : IDisposable
	{
		private readonly TodoItemDbContext dbContext;
		private readonly TodoItemService sut;

		public TodoItemServiceTests()
		{
			var options = new DbContextOptionsBuilder<TodoItemDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString())
				.Options;
			dbContext = new TodoItemDbContext(options);
			sut = new TodoItemService(dbContext);
		}

		[Fact]
		public async Task GetTodoItemAsync_ShouldReturnAnItem_WhenValidIdIsSupplied()
		{
			// Arrange
			var item = GetEmptyTodoItem(0);
			await dbContext.TodoItems.AddAsync(item);
			await dbContext.SaveChangesAsync();

			// Act
			var receivedItem = await sut.GetTodoItemAsync(item.Id);
			
			// Assert
			receivedItem.Should().Be(item);
		}

		[Fact]
		public async Task GetTodoItemAsync_ShouldReturnNull_WhenInvalidIdIdSupplied()
		{
			// Act
			var receivedItem = await sut.GetTodoItemAsync(0);
			
			// Assert
			receivedItem.Should().BeNull();
		}

		[Fact]
		public async Task GetTodoItemsAsync_ShouldReturnAllTodoItems_WhenCalled()
		{
			// Arrange
			var items = new TodoItem[]
			{
				// TODO Figure out why adding an entity with id 0 doesn't work
				GetEmptyTodoItem(1),
				GetEmptyTodoItem(2)
			};
			await dbContext.TodoItems.AddRangeAsync(items);
			await dbContext.SaveChangesAsync();
			
			// Act
			var receivedItems = await sut.GetTodoItemsAsync();
			
			// Assert
			receivedItems.Should().BeEquivalentTo(items);
		}
		
		[Fact]
		public async Task GetTodoItemsAsync_ShouldReturnEmptyArray_WhenNoItemsAreAvailable()
		{
			// Arrange
			var items = new TodoItem[0];
			await dbContext.TodoItems.AddRangeAsync(items);
			await dbContext.SaveChangesAsync();
			
			// Act
			var receivedItems = await sut.GetTodoItemsAsync();
			
			// Assert
			receivedItems.Should().BeEquivalentTo(items);
		}

		[Fact]
		public async Task AddTodoItemAsync_ShouldAddAnItem_WhenCalled()
		{
			// Arrange
			var item = GetEmptyTodoItem();
			
			// Act
			await sut.AddTodoItemAsync(item);

			// Assert
			dbContext.TodoItems.Should().Contain(item);
		}

		[Fact]
		public async Task CompleteTodoItemAsync_ShouldMakeTheGivenItemComplete_WhenTheItemExists()
		{
			// Arrange
			var item = GetEmptyTodoItem();
			await dbContext.TodoItems.AddAsync(item);
			await dbContext.SaveChangesAsync();
			
			// Act
			await sut.CompleteTodoItemAsync(item.Id);
			
			// Assert
			var receivedItem = await sut.GetTodoItemAsync(item.Id);
			receivedItem.IsCompleted.Should().BeTrue();
		}
		
		[Fact]
		public async Task CompleteTodoItemAsync_ShouldNotChangeTheItem_WhenTheItemWasCompleted()
		{
			// Arrange
			var item = GetEmptyTodoItem();
			item.IsCompleted = true;
			await dbContext.TodoItems.AddAsync(item);
			await dbContext.SaveChangesAsync();

			// Act
			await sut.CompleteTodoItemAsync(item.Id);
			
			// Assert
			var receivedItem = await sut.GetTodoItemAsync(item.Id);
			receivedItem.IsCompleted.Should().BeTrue();
		}

		public void Dispose()
		{
			dbContext.Database.EnsureDeleted();
			dbContext.Dispose();
		}

		private TodoItem GetEmptyTodoItem(int id = 0)
		{
			return new()
			{
				Id = id,
				Instruction = string.Empty,
				Deadline = DateTime.Now,
				AdditionDate = DateTime.Now,
				IsCompleted = false
			};
		}
	}
}