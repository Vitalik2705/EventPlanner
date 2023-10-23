using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Annotation
{
    internal class EventAnnotation : BaseEntityAnnotation<Event>
    {
        internal EventAnnotation(ModelBuilder builder)
            : base(builder)
        {

        }

        public override void Annotate()
        {
            ModelBuilder.HasKey(u => u.EventId);
            ModelBuilder.Property(u => u.EventId).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("event_id");
            ModelBuilder.Property(u => u.Name).IsRequired().HasMaxLength(20);
            ModelBuilder.HasMany(u => u.Recipes).WithMany(u => u.Events);
            ModelBuilder.HasMany(u => u.Guests);
            ModelBuilder.Property(u => u.CreatedDate).IsRequired();
            ModelBuilder.Property(u => u.ModifiedDate);
        }
    }
}
