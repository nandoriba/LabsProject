using LabsProject.BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabsProject.BackEnd.Infrastructure.Context
{
    public class LaboratoriesConfiguration : IEntityTypeConfiguration<Laboratories>
    {
        public void Configure(EntityTypeBuilder<Laboratories> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Laboratorie");

            
        }
    }
}