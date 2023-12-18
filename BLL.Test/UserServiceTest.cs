using BLL.Services.Interfaces;
using BLL.Services.Repositories;
using DAL.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Services.Repositories.IUserRepository;

namespace BLL.Test
{
    public class UserServiceTest
    {
        [Fact]
        public async Task Login_ValidCredentials_ReturnsUser()
        {
            // Arrange
            var email = "test@example.com";
            var password = "Password123";
            var expectedUser = new User { UserId = 1, Email = email, /* other properties */ };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.Login(password, email))
                .ReturnsAsync(expectedUser);

            var userService = new UserService(userRepositoryMock.Object);

            // Act
            var result = await userService.Login(password, email);

            // Assert
            Assert.Equal(expectedUser, result);
        }

        [Fact]
        public async Task Register_ValidUser_ReturnsRegistrationResult()
        {
            // Arrange
            var userToRegister = new User { UserId = 1, Email = "test@example.com", /* other properties */ };
            var expectedRegistrationResult = new RegistrationResult(); // Assuming RegistrationResult is a class without specific properties

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.Register(userToRegister))
                .ReturnsAsync(expectedRegistrationResult);

            var userService = new UserService(userRepositoryMock.Object);

            // Act
            var result = await userService.Register(userToRegister);

            // Assert
            Assert.Equal(expectedRegistrationResult, result);
        }

    }
}
