using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyTriApp.Data.Entities;

namespace MyTriApp.Data.Mappings
{
    public class UserMappings : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.ExternalId);
            builder.HasOne(e => e.StravaAccessToken)
                .WithOne(e => e.User)
                .HasForeignKey<StravaAccessToken>(e => e.UserId)
                .IsRequired();
        }
    }
}
