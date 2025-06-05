using DataPipeline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataPipeline.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Email);
            builder.HasIndex(x => x.FullName);

            // Composite index on Email and FullName
            // builder.HasIndex(x => new { x.Email, x.FullName })
            //       .HasDatabaseName("IX_User_Email_FullName");


            // Unique Index
            // builder.HasIndex(u => u.Email)
            //    .IsUnique();

            // ..............
        }
    }
}
