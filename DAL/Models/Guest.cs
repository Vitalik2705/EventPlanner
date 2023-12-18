namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Guest
    {
        public int GuestId { get; set; }

        public string Surname { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public ICollection<EventGuest> GuestEvents { get; set; }

        public string? Name { get; set; }

        public Gender Gender { get; set; }
    }
}
