using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkMap.Areas.Identity.Data;
using ParkMap.Models;

namespace ParkMap.Areas.Identity.Data;

public class ParkMapContext : IdentityDbContext<ParkMapUser>
{
    public ParkMapContext(DbContextOptions<ParkMapContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ParkUserEntityConfiguration());
    }

    public DbSet<ParkMap.Models.Post> Post { get; set; }

    public DbSet<ParkMap.Models.ParkingLot> ParkingLot { get; set; }
}

public class ParkUserEntityConfiguration : IEntityTypeConfiguration<ParkMapUser>
{
    public void Configure(EntityTypeBuilder<ParkMapUser> builder)
    {
        builder.Property(u => u.NickName).HasMaxLength(15);
    }
}