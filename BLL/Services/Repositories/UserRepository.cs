﻿// <copyright file="UserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.Services.Repositories
{
    using System;
    using System.Collections.Generic;
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
            IQueryable<User> query = this._table.Where(x => x.Email == email && x.Password == password);

            // var user = this._context.User.FirstOrDefaultAsync(u => u.Password == password && u.Email == email);
            var user = await query.FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Parameter 'name' cannot be null.");
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

            await this._table.AddAsync(user);

            await this._context.SaveChangesAsync();

            return result;
        }

        public async Task UpdateAsync(User user)
        {
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
