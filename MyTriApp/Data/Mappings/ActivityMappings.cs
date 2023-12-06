using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyTriApp.Data.Entities;

namespace MyTriApp.Data.Mappings
{
    //public class ActivityMappings : IEntityTypeConfiguration<Activity>
    //{
    //    public void Configure(EntityTypeBuilder<Activity> builder)
    //    {
    //        builder.HasKey(a => a.Id);
    //        builder.HasMany(a => a.Laps).WithOne(a => a.Activity).HasForeignKey(l => l.ActivityId).IsRequired();
    //        builder.HasMany(a => a.Splits).WithOne(a => a.Activity).HasForeignKey(s => s.ActivityId).IsRequired();
    //    }
    //}
}
