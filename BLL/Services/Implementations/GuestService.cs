using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public class GuestService : IGuestService
    {
        private IGenericRepository<Guest> _guestRepository;

        public GuestService(IGenericRepository<Guest> repository)
        {
            _guestRepository = repository;
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _guestRepository.GetAll();
        }

        public async Task<Guest> GetGuestById(int id)
        {
            return await _guestRepository.GetById(id);
        }

        public async Task AddGuest(Guest _guest)
        {
            _guestRepository.Add(_guest);
            await _guestRepository.Save();
        }

        public async Task UpdateGuest(Guest _guest)
        {
            _guestRepository.Update(_guest);
            await _guestRepository.Save();
        }

        public async Task DeleteGuest(int id)
        {
            _guestRepository.Delete(id);
            await _guestRepository.Save();
        }
    }
}