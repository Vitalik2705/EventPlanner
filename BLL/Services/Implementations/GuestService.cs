using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BLL.Services.Interfaces
{
    public class GuestService : IGuestService
    {
        private IGenericRepository<Guest> _guestRepository;

        public GuestService(IGenericRepository<Guest> repository)
        {
            _guestRepository = repository;
        }

        public async Task<IEnumerable<Guest>> GetAll(Expression<Func<Guest, bool>>? filter = null)
        {
            return await _guestRepository.GetAllAsync(filter);
        }

        public async Task<Guest> GetGuest(Expression<Func<Guest, bool>>? filter = null)
        {
            return await _guestRepository.GetAsync(filter);
        }

        public async Task AddGuest(Guest _guest)
        {
            await _guestRepository.AddAsync(_guest);
        }

        public async Task UpdateGuest(Guest _guest)
        {
            await _guestRepository.UpdateAsync(_guest);
        }

        public async Task DeleteGuest(int id)
        {
            await _guestRepository.DeleteAsync(id);
        }

        public async Task<List<Guest>> GetGuestsAsync(Expression<Func<Guest, bool>>? filter = null)
        {
            return (await _guestRepository.GetAllAsync(filter)).ToList();
        }
    }
}