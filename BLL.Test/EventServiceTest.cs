using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;
using Telerik.JustMock;
using BLL.Services.Interfaces;
using BLL.Services.Repositories;
using Moq;


namespace BLL.Test
{
    public class EventServiceTest
    {
        [Fact]
        public async Task GetAll_WithDateFilter_ReturnsFilteredEvents()
        {
            // Arrange
            DateTime filterDate = new DateTime(2023, 1, 1); 
            Expression<Func<Event, bool>> filter = e => e.CreatedDate > filterDate;

            var events = new List<Event>
            {
                new Event { EventId = 1, CreatedDate = new DateTime(2023, 1, 2), /* other properties */ },
                new Event { EventId = 2, CreatedDate = new DateTime(2023, 1, 3), /* other properties */ },
            
            };

            var repositoryMock = new Mock<IGenericRepository<Event>>();
            repositoryMock.Setup(repo => repo.GetAllAsync(filter))
                .ReturnsAsync(events);

            var eventService = new EventService(repositoryMock.Object);

            // Act
            var result = await eventService.GetAll(filter);

            // Assert
            Assert.Equal(events.Where(filter.Compile()), result);
        }

        [Fact]
        public async Task GetEvent_WithDateFilter_ReturnsSingleEvent()
        {
            // Arrange
            DateTime filterDate = new DateTime(2023, 1, 1);
            Expression<Func<Event, bool>> filter = e => e.CreatedDate == filterDate;

            var singleEvent = new Event { EventId = 1, CreatedDate = filterDate, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Event>>();
            repositoryMock.Setup(repo => repo.GetAsync(filter))
                .ReturnsAsync(singleEvent);

            var eventService = new EventService(repositoryMock.Object);

            // Act
            var result = await eventService.GetEvent(filter);

            // Assert
            Assert.Equal(singleEvent, result);
        }

        [Fact]
        public async Task AddEvent_WithValidEvent_DoesNotThrowException()
        {
            // Arrange
            var validEvent = new Event { EventId = 1, CreatedDate = DateTime.Now, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Event>>();
            var eventService = new EventService(repositoryMock.Object);

            // Act
            var exception = await Record.ExceptionAsync(async () => await eventService.AddEvent(validEvent));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public async Task UpdateEvent_CallsRepositoryUpdateAsync()
        {
            // Arrange
            var eventToUpdate = new Event { EventId = 1, CreatedDate = DateTime.Now, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Event>>();
            var eventService = new EventService(repositoryMock.Object);

            // Act
            await eventService.UpdateEvent(eventToUpdate);

            // Assert
            repositoryMock.Verify(repo => repo.UpdateAsync(eventToUpdate), Times.Once);
        }

        [Fact]
        public async Task DeleteEvent_CallsRepositoryDeleteAsync()
        {
            // Arrange
            var eventIdToDelete = 1;

            var repositoryMock = new Mock<IGenericRepository<Event>>();
            var eventService = new EventService(repositoryMock.Object);

            // Act
            await eventService.DeleteEvent(eventIdToDelete);

            // Assert
            repositoryMock.Verify(repo => repo.DeleteAsync(eventIdToDelete), Times.Once);
        }

    }

}
