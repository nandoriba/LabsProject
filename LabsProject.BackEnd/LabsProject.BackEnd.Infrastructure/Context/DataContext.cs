using LabsProject.BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
  

            modelBuilder.ApplyConfiguration(new LaboratoriesConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new AssociateLabsWithTestsConfigurationTestsHandler());

            base.OnModelCreating(modelBuilder);
        }

    }

}
