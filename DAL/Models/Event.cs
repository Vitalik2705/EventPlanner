namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Event
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public ICollection<EventGuest> EventGuests { get; set; }

        public ICollection<EventRecipe> EventRecipes { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
