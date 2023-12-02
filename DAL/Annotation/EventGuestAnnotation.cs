using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Annotation
{
    internal class EventGuestAnnotation : BaseEntityAnnotation<EventGuest>
    {
        internal EventGuestAnnotation(ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            this.ModelBuilder.HasKey(u => u.EventGuestId);
            this.ModelBuilder.Property(u => u.EventGuestId).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("event_guest_id");
            this.ModelBuilder.HasOne(u => u.Event).WithMany(u => u.EventGuests).HasForeignKey(u => u.EventId);
            this.ModelBuilder.HasOne(u => u.Guest).WithMany(u => u.GuestEvents).HasForeignKey(u => u.GuestId);
        }
    }
}
