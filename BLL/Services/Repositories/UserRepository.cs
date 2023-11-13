// <copyright file="UserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.Services.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL.Data;
    using DAL.Models;

    public class UserRepository : IUserRepository
    {
        private EventPlannerContext _context;

        public UserRepository(EventPlannerContext context)
        {
            this._context = context;
        }

        public async Task<User> Login(string password, string email)
        {
            // var user = _context.User.FirstOrDefault(u => u.Password == password && u.Email == email);
            var user = this._context.User.FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<User> Register(User user1)
        {
            User user = new ()
            {
                // UserId = 3,
                Surname = "Божена",
                Name = "Сальнікова",
                PhoneNumber = "8432652",
                Email = user1.Email,
                Password = user1.Password,
                Events = new List<Event>(),
                Gender = Gender.Female,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                UserImage = new byte[6],
            };

            await this._context.AddAsync(user);
            await this._context.SaveChangesAsync();

            return user;
        }
    }
}
