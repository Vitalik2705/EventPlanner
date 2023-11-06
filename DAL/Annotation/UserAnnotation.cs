using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Annotation
{
    internal class UserAnnotation : BaseEntityAnnotation<User>
    {
        internal UserAnnotation(ModelBuilder builder)
            : base(builder)
        {

        }

        public override void Annotate()
        {
            ModelBuilder.HasKey(u => u.UserId);
            ModelBuilder.Property(u => u.UserId).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("user_id");
            ModelBuilder.Property(u => u.Surname).IsRequired().HasMaxLength(20).HasColumnName("surname");
            ModelBuilder.Property(u => u.Name).IsRequired().HasMaxLength(20).HasColumnName("name");
            ModelBuilder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15).HasColumnName("phone_number");
            ModelBuilder.Property(u => u.Email).IsRequired().HasMaxLength(40).HasColumnName("email");
            ModelBuilder.Property(u => u.Password).IsRequired().HasMaxLength(40).HasColumnName("password");
            ModelBuilder.HasMany(u => u.Events).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            ModelBuilder.Property(u => u.Gender).IsRequired().HasConversion<string>().HasColumnName("gender");
            ModelBuilder.Property(u => u.CreatedDate).IsRequired().HasColumnName("created_date");
            ModelBuilder.Property(u => u.ModifiedDate).HasColumnName("modified_date").IsRequired(false);
            ModelBuilder.Property(p => p.UserImage).HasColumnName("user_image").IsRequired(false);
        }
    }
}
