using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityTypeConfigurations;

public class CourseTechEntityTypeConfig:IEntityTypeConfiguration<CourseTechs>
{
    public void Configure(EntityTypeBuilder<CourseTechs> builder)
    {
        builder.Property(x => x.Name).IsRequired();
    }
}