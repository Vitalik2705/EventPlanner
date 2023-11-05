using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public IEnumerable<Guest> GetAll()
        {
            return _guestRepository.GetAll();
        }
        public Guest GetGuestById(int id)
        {
            return _guestRepository.GetById(id);
        }
        public void AddGuest(Guest guest)
        {
            _guestRepository.Add(guest);
            _guestRepository.Save();
        }
        public void UpdateGuest(Guest guest)
        {
            _guestRepository.Update(guest);
            _guestRepository.Save();
        }
        public void DeleteGuest(int id)
        {
            _guestRepository.Delete(id);
            _guestRepository.Save();
        }
    }
}
