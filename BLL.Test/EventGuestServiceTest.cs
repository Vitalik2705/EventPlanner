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
    public class EventGuestServiceTest
    {
        [Fact]
        public async Task GetAll_ReturnsEventGuestList()
        {
            // Arrange
            var expectedEventGuestList = new List<EventGuest>
            {
                new EventGuest { EventGuestId = 1, /* initialize properties */ },
                new EventGuest { EventGuestId = 2, /* initialize properties */ },
                // Add more event guest instances as needed
            };

            var eventGuestRepositoryMock = new Mock<IGenericRepository<EventGuest>>();
            eventGuestRepositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<EventGuest, bool>>>()))
                .ReturnsAsync(expectedEventGuestList);

            var eventGuestService = new EventGuestService(eventGuestRepositoryMock.Object);

            // Act
            var result = await eventGuestService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<EventGuest>>(result);

            var resultList = result.ToList(); // Convert IEnumerable to List for easier comparison
            Assert.Equal(expectedEventGuestList.Count, resultList.Count);
        }

        [Fact]
        public async Task GetEventGuest_ReturnsEventGuest()
        {
            // Arrange
            var expectedGuest = new EventGuest { EventGuestId = 1, /* initialize properties */ };

            var guestRepositoryMock = new Mock<IGenericRepository<EventGuest>>();
            guestRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<EventGuest, bool>>>()))
                .ReturnsAsync(expectedGuest);

            var guestService = new EventGuestService(guestRepositoryMock.Object);

            // Act
            var result = await guestService.GetEventGuest(g => g.GuestId == 1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedGuest.GuestId, result.GuestId); // Adjust for other properties as needed
        }

        [Fact]
        public async Task AddEventGuest_WithValidEventGuest_DoesNotThrowException()
        {
            // Arrange
            var validGuest = new EventGuest { EventGuestId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<EventGuest>>();
            var GuestService = new EventGuestService(repositoryMock.Object);

            // Act
            var exception = await Record.ExceptionAsync(async () => await GuestService.AddEventGuest(validGuest));

            // Assert
            Assert.Null(exception);
        }


        [Fact]
        public async Task UpdateEventGuest_CallsRepositoryUpdateAsync()
        {
            // Arrange
            var GuestToUpdate = new EventGuest { EventGuestId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<EventGuest>>();
            var EventGuestService = new EventGuestService(repositoryMock.Object);

            // Act
            await EventGuestService.UpdateEventGuest(GuestToUpdate);

            // Assert
            repositoryMock.Verify(repo => repo.UpdateAsync(GuestToUpdate), Times.Once);
        }

        [Fact]
        public async Task DeleteEventGuest_CallsRepositoryDeleteAsync()
        {
            // Arrange
            var GuestIdToDelete = 1;

            var repositoryMock = new Mock<IGenericRepository<EventGuest>>();
            var EventGuestService = new EventGuestService(repositoryMock.Object);

            // Act
            await EventGuestService.DeleteEventGuest(GuestIdToDelete);

            // Assert
            repositoryMock.Verify(repo => repo.DeleteAsync(GuestIdToDelete), Times.Once);
        }
        
        [Fact]
        public async Task GetEventsForGuest_ReturnsEventGuestList()
        {
            // Arrange
            int guestId = 1;
            var expectedEventGuestList = new List<EventGuest>
            {
                new EventGuest { EventGuestId = 1, GuestId = guestId /* other properties */ },
                new EventGuest { EventGuestId = 2, GuestId = guestId /* other properties */ },
                // Add more event guest instances as needed
            };

            var repositoryMock = new Mock<IGenericRepository<EventGuest>>();
            repositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<EventGuest, bool>>>()))
                .ReturnsAsync(expectedEventGuestList);

            var eventGuestService = new EventGuestService(repositoryMock.Object);

            // Act
            var result = await eventGuestService.GetEventsForGuest(guestId);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<EventGuest>>(result);

            var resultList = result.ToList(); // Convert IEnumerable to List for easier comparison
            Assert.Equal(expectedEventGuestList.Count, resultList.Count);
        }

        [Fact]
        public async Task GetGuestsForEvent_ReturnsEventGuestList()
        {
            // Arrange
            int eventId = 1;
            var expectedEventGuestList = new List<EventGuest>
            {
                new EventGuest { EventGuestId = 1, EventId = eventId /* other properties */ },
                new EventGuest { EventGuestId = 2, EventId = eventId /* other properties */ },
                // Add more event guest instances as needed
            };

            var repositoryMock = new Mock<IGenericRepository<EventGuest>>();
            repositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<EventGuest, bool>>>()))
                .ReturnsAsync(expectedEventGuestList);

            var eventGuestService = new EventGuestService(repositoryMock.Object);

            // Act
            var result = await eventGuestService.GetGuestsForEvent(eventId);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<EventGuest>>(result);

            var resultList = result.ToList(); // Convert IEnumerable to List for easier comparison
            Assert.Equal(expectedEventGuestList.Count, resultList.Count);
        }
    }
}

