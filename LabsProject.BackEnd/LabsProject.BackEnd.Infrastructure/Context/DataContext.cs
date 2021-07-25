using LabsProject.BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabsProject.BackEnd.Infrastructure.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Laboratories> Laboratories { get; set; }
        public DbSet<Tests> Tests { get; set; }
        public DbSet<AssociateLabsWithTests> AssociateLabsWithTests { get; set; }
     

    }
    public class LaboratoriesConfiguration : IEntityTypeConfiguration<Laboratories>
    {
        public void Configure(EntityTypeBuilder<Laboratories> builder)
        {            
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Address);
        }
    }
}
