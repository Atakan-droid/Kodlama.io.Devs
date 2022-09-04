using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityTypeConfigurations;

public class CourseEntityTypeConfig : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(x => x.CourseName).IsRequired();
        builder.HasIndex(x => x.CourseName);
        builder.Property(x => x.Price).IsRequired();

        /////

        Course[] seedCourses =
        {
            new Course()
            {
                Id = Guid.NewGuid(),
                CourseName = "C#",
                Price = 250,
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                StartDate = DateTime.Now.AddDays(4),
                EndDate = DateTime.Now.AddDays(30)
            },
            new Course()
            {
                Id = Guid.NewGuid(),
                CourseName = "Java",
                Price = 1000,
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                StartDate = DateTime.Now.AddDays(3),
                EndDate = DateTime.Now.AddDays(10)
            },
        };

        builder.HasData(seedCourses);
    }
}