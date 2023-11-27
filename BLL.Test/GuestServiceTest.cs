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
    public class GuestServiceTest
    {
        [Fact]
        public async Task GetAll_ReturnsGuestList()
        {
            // Arrange
            var expectedGuestList = new List<Guest>
            {
                new Guest { GuestId = 1, /* initialize properties */ },
                new Guest { GuestId = 2, /* initialize properties */ },
                // Add more guest instances as needed
            };

            var guestRepositoryMock = new Mock<IGenericRepository<Guest>>();
            guestRepositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<Guest, bool>>>()))
                .ReturnsAsync(expectedGuestList);

            var guestService = new GuestService(guestRepositoryMock.Object);

            // Act
            var result = await guestService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Guest>>(result);

            var resultList = result.ToList(); // Convert IEnumerable to List for easier comparison
            Assert.Equal(expectedGuestList.Count, resultList.Count);
        }

        [Fact]
        public async Task GetGuest_ReturnsGuest()
        {
            // Arrange
            var expectedGuest = new Guest { GuestId = 1, /* initialize properties */ };

            var guestRepositoryMock = new Mock<IGenericRepository<Guest>>();
            guestRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<Guest, bool>>>()))
                .ReturnsAsync(expectedGuest);

            var guestService = new GuestService(guestRepositoryMock.Object);

            // Act
            var result = await guestService.GetGuest(g => g.GuestId == 1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedGuest.GuestId, result.GuestId); // Adjust for other properties as needed
        }

        [Fact]
        public async Task AddGuest_WithValidGuest_DoesNotThrowException()
        {
            // Arrange
            var validGuest = new Guest { GuestId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Guest>>();
            var GuestService = new GuestService(repositoryMock.Object);

            // Act
            var exception = await Record.ExceptionAsync(async () => await GuestService.AddGuest(validGuest));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public async Task UpdateGuest_CallsRepositoryUpdateAsync()
        {
            // Arrange
            var GuestToUpdate = new Guest { GuestId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Guest>>();
            var GuestService = new GuestService(repositoryMock.Object);

            // Act
            await GuestService.UpdateGuest(GuestToUpdate);

            // Assert
            repositoryMock.Verify(repo => repo.UpdateAsync(GuestToUpdate), Times.Once);
        }

        [Fact]
        public async Task DeleteGuest_CallsRepositoryDeleteAsync()
        {
            // Arrange
            var GuestIdToDelete = 1;

            var repositoryMock = new Mock<IGenericRepository<Guest>>();
            var GuestService = new GuestService(repositoryMock.Object);

            // Act
            await GuestService.DeleteGuest(GuestIdToDelete);

            // Assert
            repositoryMock.Verify(repo => repo.DeleteAsync(GuestIdToDelete), Times.Once);
        }

    }

}
