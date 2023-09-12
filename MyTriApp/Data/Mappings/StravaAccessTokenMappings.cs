using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyTriApp.Data.Entities;

namespace MyTriApp.Data.Mappings
{
    public class StravaAccessTokenMappings : IEntityTypeConfiguration<StravaAccessToken>
    {
        public void Configure(EntityTypeBuilder<StravaAccessToken> builder)
        {
            builder.HasKey(sat => sat.Id);
            builder.HasOne(sat => sat.User).WithOne(user => user.StravaAccessToken);
        }
    }
}
