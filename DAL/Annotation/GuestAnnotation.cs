using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Annotation
{
    internal class GuestAnnotation : BaseEntityAnnotation<Guest>
    {
        internal GuestAnnotation(ModelBuilder builder)
            : base(builder)
        {

        }

        public override void Annotate()
        {
            ModelBuilder.HasKey(u => u.GuestId);
            ModelBuilder.Property(u => u.GuestId).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("guest_id");
            ModelBuilder.Property(u => u.Surname).IsRequired().HasMaxLength(20).HasColumnName("surname");
            ModelBuilder.Property(u => u.Name).IsRequired().HasMaxLength(20).HasColumnName("name");
            ModelBuilder.Property(u => u.Gender).IsRequired().HasConversion<string>().HasColumnName("gender");

        }
    }
}
