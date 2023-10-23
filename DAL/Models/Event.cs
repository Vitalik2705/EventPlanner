using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public User User { get; set; }

        public ICollection<Guest> Guests { get; set; }

        public ICollection<Recipe> Recipes { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
