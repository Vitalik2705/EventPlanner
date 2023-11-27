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
    public class IngredientUnitServiceTest
    {
        [Fact]
        public async Task GetAll_ReturnsIngredientUnitList()
        {
            // Arrange
            var expectedIngredientUnitList = new List<IngredientUnit>
            {
                new IngredientUnit { IngredientUnitId = 1, /* initialize properties */ },
                new IngredientUnit { IngredientUnitId = 2, /* initialize properties */ },
                // Add more IngredientUnit instances as needed
            };

            var ingredientUnitRepositoryMock = new Mock<IGenericRepository<IngredientUnit>>();
            ingredientUnitRepositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<IngredientUnit, bool>>>()))
                .ReturnsAsync(expectedIngredientUnitList);

            var ingredientUnitService = new IngredientUnitService(ingredientUnitRepositoryMock.Object);

            // Act
            var result = await ingredientUnitService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<IngredientUnit>>(result);

            var resultList = result.ToList(); // Convert IEnumerable to List for easier comparison
            Assert.Equal(expectedIngredientUnitList.Count, resultList.Count);
        }


        [Fact]
        public async Task GetIngredientUnit_ReturnsIngredientUnit()
        {
            // Arrange
            var expectedIngredientUnit = new IngredientUnit { IngredientUnitId = 1, /* initialize properties */ };

            var ingredientUnitRepositoryMock = new Mock<IGenericRepository<IngredientUnit>>();
            ingredientUnitRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<IngredientUnit, bool>>>()))
                .ReturnsAsync(expectedIngredientUnit);

            var ingredientUnitService = new IngredientUnitService(ingredientUnitRepositoryMock.Object);

            // Act
            var result = await ingredientUnitService.GetIngredientUnit(g => g.IngredientUnitId == 1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedIngredientUnit.IngredientUnitId, result.IngredientUnitId); // Adjust for other properties as needed
        }

        [Fact]
        public async Task AddIngredientUnit_WithValidIngredientUnit_DoesNotThrowException()
        {
            // Arrange
            var validIngredientUnit = new IngredientUnit { IngredientUnitId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<IngredientUnit>>();
            var IngredientUnitService = new IngredientUnitService(repositoryMock.Object);

            // Act
            var exception = await Record.ExceptionAsync(async () => await IngredientUnitService.AddIngredientUnit(validIngredientUnit));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public async Task UpdateIngredientUnit_CallsRepositoryUpdateAsync()
        {
            // Arrange
            var IngredientUnitToUpdate = new IngredientUnit { IngredientUnitId = 1, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<IngredientUnit>>();
            var IngredientUnitService = new IngredientUnitService(repositoryMock.Object);

            // Act
            await IngredientUnitService.UpdateIngredientUnit(IngredientUnitToUpdate);

            // Assert
            repositoryMock.Verify(repo => repo.UpdateAsync(IngredientUnitToUpdate), Times.Once);
        }

        [Fact]
        public async Task DeleteIngredientUnit_CallsRepositoryDeleteAsync()
        {
            // Arrange
            var IngredientUnitIdToDelete = 1;

            var repositoryMock = new Mock<IGenericRepository<IngredientUnit>>();
            var IngredientUnitService = new IngredientUnitService(repositoryMock.Object);

            // Act
            await IngredientUnitService.DeleteIngredientUnit(IngredientUnitIdToDelete);

            // Assert
            repositoryMock.Verify(repo => repo.DeleteAsync(IngredientUnitIdToDelete), Times.Once);
        }

    }

}
