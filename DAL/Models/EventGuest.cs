namespace DAL.Models
{
    public class EventGuest
    {
        public int EventGuestId { get; set; }

        public Event Event { get; set; }

        public int EventId { get; set; }

        public Guest Guest { get; set; }

        public int GuestId { get; set; }
    }
}