using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Guest
    {
        public int GuestId { get; set; }

        public string Surname { get; set; } = string.Empty;

        public string? Name { get; set; }

        public Gender Gender { get; set; }
    }
}
