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
    public class RecipeServiceTest
    {
        [Fact]
        public async Task GetAll_WithDateFilter_ReturnsFilteredRecipes()
        {
            // Arrange
            DateTime filterDate = new DateTime(2023, 1, 1); 
            Expression<Func<Recipe, bool>> filter = e => e.CreatedDate > filterDate;

            var Recipes = new List<Recipe>
            {
                new Recipe { RecipeId = 1, CreatedDate = new DateTime(2023, 1, 2), /* other properties */ },
                new Recipe { RecipeId = 2, CreatedDate = new DateTime(2023, 1, 3), /* other properties */ },
            
            };

            var repositoryMock = new Mock<IGenericRepository<Recipe>>();
            repositoryMock.Setup(repo => repo.GetAllAsync(filter))
                .ReturnsAsync(Recipes);

            var RecipeService = new RecipeService(repositoryMock.Object);

            // Act
            var result = await RecipeService.GetAll(filter);

            // Assert
            Assert.Equal(Recipes.Where(filter.Compile()), result);
        }

        [Fact]
        public async Task GetRecipe_WithDateFilter_ReturnsSingleRecipe()
        {
            // Arrange
            DateTime filterDate = new DateTime(2023, 1, 1);
            Expression<Func<Recipe, bool>> filter = e => e.CreatedDate == filterDate;

            var singleRecipe = new Recipe { RecipeId = 1, CreatedDate = filterDate, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Recipe>>();
            repositoryMock.Setup(repo => repo.GetAsync(filter))
                .ReturnsAsync(singleRecipe);

            var RecipeService = new RecipeService(repositoryMock.Object);

            // Act
            var result = await RecipeService.GetRecipe(filter);

            // Assert
            Assert.Equal(singleRecipe, result);
        }

        [Fact]
        public async Task AddRecipe_WithValidRecipe_DoesNotThrowException()
        {
            // Arrange
            var validRecipe = new Recipe { RecipeId = 1, CreatedDate = DateTime.Now, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Recipe>>();
            var RecipeService = new RecipeService(repositoryMock.Object);

            // Act
            var exception = await Record.ExceptionAsync(async () => await RecipeService.AddRecipe(validRecipe));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public async Task UpdateRecipe_CallsRepositoryUpdateAsync()
        {
            // Arrange
            var RecipeToUpdate = new Recipe { RecipeId = 1, CreatedDate = DateTime.Now, /* other properties */ };

            var repositoryMock = new Mock<IGenericRepository<Recipe>>();
            var RecipeService = new RecipeService(repositoryMock.Object);

            // Act
            await RecipeService.UpdateRecipe(RecipeToUpdate);

            // Assert
            repositoryMock.Verify(repo => repo.UpdateAsync(RecipeToUpdate), Times.Once);
        }

        [Fact]
        public async Task DeleteRecipe_CallsRepositoryDeleteAsync()
        {
            // Arrange
            var RecipeIdToDelete = 1;

            var repositoryMock = new Mock<IGenericRepository<Recipe>>();
            var RecipeService = new RecipeService(repositoryMock.Object);

            // Act
            await RecipeService.DeleteRecipe(RecipeIdToDelete);

            // Assert
            repositoryMock.Verify(repo => repo.DeleteAsync(RecipeIdToDelete), Times.Once);
        }

    }

}
