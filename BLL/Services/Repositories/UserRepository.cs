// <copyright file="UserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

//using Org.BouncyCastle.Crypto.Generators;

namespace BLL.Services.Repositories
{
    using BCrypt.Net;
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BLL.Validation;
    using DAL.Data;
    using DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using static BLL.Services.Repositories.IUserRepository;

    public class UserRepository : IUserRepository
    {
        private EventPlannerContext _context;
        private DbSet<User> _table;

        public UserRepository(EventPlannerContext context)
        {
            this._context = context;
            this._table = this._context.Set<User>();
        }

        public async Task<User> Login(string password, string email)
        {
            IQueryable<User> query = this._table.Where(x => x.Email == email);

            var user = await query.FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Parameter 'name' cannot be null.");
            }

            if (!BCrypt.Verify(password, user.Password))
            {
                throw new ArgumentException("Invalid password.");
            }

            return user;
        }

        public async Task<RegistrationResult> Register(User user)
        {
            RegistrationResult result = RegistrationResult.Success;

            var validator = new RegisterValidation();
            var validationResult = validator.Validate(user);

            if (!validationResult.IsValid)
            {
                return RegistrationResult.PasswordsDoNotMatch;
            }

            bool userExist = await _table.AnyAsync(u => u.Email == user.Email);
            if (userExist)
            {
                return RegistrationResult.EmailAlreadyExists;
            }

            string hashedPassword = BCrypt.HashPassword(user.Password);

            user.Password = hashedPassword;

            await this._table.AddAsync(user);

            await this.SaveAsync();

            return result;
        }

        public async Task UpdateAsync(User user)
        {
            user.ModifiedDate = DateTime.UtcNow;
            this._table.Attach(user);
            this._context.Entry(user).State = EntityState.Modified;
            await this.SaveAsync();
        }

        public async Task SaveAsync()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
