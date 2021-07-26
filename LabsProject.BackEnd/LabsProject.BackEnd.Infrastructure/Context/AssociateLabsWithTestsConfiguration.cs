using LabsProject.BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabsProject.BackEnd.Infrastructure.Context
{
    public class AssociateLabsWithTestsConfigurationTestsHandler : IEntityTypeConfiguration<AssociateLabsWithTests>
    {
        public void Configure(EntityTypeBuilder<AssociateLabsWithTests> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("AssociateLabsWithTests");
        }
    }
}
