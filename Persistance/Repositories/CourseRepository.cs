using Domain.Entities;
using Domain.Repositories;
using Persistance.Contexts;

namespace Persistance.Reposiories;

public class CourseRepository:EfCoreBaseRepository<Course,BaseDbContext>,ICourseRepository
{
    public CourseRepository(BaseDbContext context) : base(context)
    {
    }
}