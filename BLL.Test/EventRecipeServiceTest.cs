using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;
using Telerik.JustMock;
using BLL.Services.Interfaces;
using BLL.Services.Repositories;
using BLL.Services.Implementations;
using Moq;


namespace BLL.Test
{
    public class EventRecipeServiceTest
    {
        [Fact]
        public async Task GetAll_ReturnsEventRecipeList()
        {
            // Arrange
            var expectedEventRecipeList = new List<EventRecipe>
            {
                new EventRecipe { EventRecipeId = 1, /* initialize properties */ },
                new EventRecipe { EventRecipeId = 2, /* initialize properties */ },
                // Add more event recipe instances as needed
            };

            var eventRecipeRepositoryMock = new Mock<IGenericRepository<EventRecipe>>();
            eventRecipeRepositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<EventRecipe, bool>>>()))
                .ReturnsAsync(expectedEventRecipeList);

            var eventRecipeService = new EventRecipeService(eventRecipeRepositoryMock.Object);

            // Act
            var result = await eventRecipeService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<EventRecipe>>(result);

            var resultList = result.ToList(); // Convert IEnumerable to List for easier comparison
            Assert.Equal(expectedEventRecipeList.Count, resultList.Count);
        }


        [Fact]
        public async Task GetEventRecipe_ReturnsEventGuest()
        {
            // Arrange
            var expectedRecipe = new EventRecipe { EventRecipeId = 1, /* initialize properties */ };

            var eventRecipeRepositoryMock = new Mock<IGenericRepository<EventRecipe>>();
            eventRecipeRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<EventRecipe, bool>>>()))
                .ReturnsAsync(expectedRecipe);

            var eventRecipeService = new EventRecipeService(eventRecipeRepositoryMock.Object);

            // Act
            var result = await eventRecipeService.GetEventRecipe(g => g.EventRecipeId == 1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedRecipe.EventRecipeId, result.EventRecipeId); // Adjust for other properties as needed
        }

        [Fact]
        public async Task AddEventRecipe_WithValidEventRecipe_DoesNotThrowException()
        {
            // Arrange
            var validEventRecipe = new EventRecipe { EventRecipeId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<EventRecipe>>();
            var EventRecipeService = new EventRecipeService(repositoryMock.Object);

            // Act
            var exception = await Record.ExceptionAsync(async () => await EventRecipeService.AddEventRecipe(validEventRecipe));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public async Task UpdateEventRecipe_CallsRepositoryUpdateAsync()
        {
            // Arrange
            var EventRecipeToUpdate = new EventRecipe { EventRecipeId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<EventRecipe>>();
            var EventRecipeService = new EventRecipeService(repositoryMock.Object);

            // Act
            await EventRecipeService.UpdateEventRecipe(EventRecipeToUpdate);

            // Assert
            repositoryMock.Verify(repo => repo.UpdateAsync(EventRecipeToUpdate), Times.Once);
        }

        [Fact]
        public async Task DeleteEventRecipe_CallsRepositoryDeleteAsync()
        {
            // Arrange
            var EventRecipeIdToDelete = 1;

            var repositoryMock = new Mock<IGenericRepository<EventRecipe>>();

            var EventRecipeService = new EventRecipeService(repositoryMock.Object);

            // Act
            await EventRecipeService.DeleteEventRecipe(EventRecipeIdToDelete);

            // Assert
            repositoryMock.Verify(repo => repo.DeleteAsync(EventRecipeIdToDelete), Times.Once);
        }


        [Fact]
        public async Task GetRecipesForEvent_ReturnsEventRecipeList()
        {
            // Arrange
            int eventId = 1;
            var expectedEventRecipeList = new List<EventRecipe>
            {
                new EventRecipe { EventRecipeId = 1, EventId = eventId /* other properties */ },
                new EventRecipe { EventRecipeId = 2, EventId = eventId /* other properties */ },
                // Add more event recipe instances as needed
            };

            var repositoryMock = new Mock<IGenericRepository<EventRecipe>>();
            repositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<EventRecipe, bool>>>()))
                .ReturnsAsync(expectedEventRecipeList);

            var eventRecipeService = new EventRecipeService(repositoryMock.Object);

            // Act
            var result = await eventRecipeService.GetRecipesForEvent(eventId);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<EventRecipe>>(result);

            var resultList = result.ToList(); // Convert IEnumerable to List for easier comparison
            Assert.Equal(expectedEventRecipeList.Count, resultList.Count);
        }
    }
}
