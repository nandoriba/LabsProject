using LabsProject.BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabsProject.BackEnd.Infrastructure.Context
{
    public class TestConfiguration : IEntityTypeConfiguration<Tests>
    {
        public void Configure(EntityTypeBuilder<Tests> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Test");            
        }
    }
}
