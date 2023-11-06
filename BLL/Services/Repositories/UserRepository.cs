using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Repositories
{
    public class UserRepository :IUserRepository
    {
        private EventPlannerContext _context;

        public UserRepository(EventPlannerContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string password, string email)
        {
            //var user = _context.User.FirstOrDefault(u => u.Password == password && u.Email == email);

            var user = _context.User.FirstOrDefault();

            if (user == null)
                return null;

            return user;
        }

        public async Task<User> Register(User _user)
        {
            User user = new()
            {
                UserId = 3,
                Surname = "Божена",
                Name = "Сальнікова",
                PhoneNumber = "8432652",
                Email = _user.Email,
                Password = _user.Password,
                Events = new List<Event>(),
                Gender = Gender.Female,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                UserImage = new byte[6]
            };

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
