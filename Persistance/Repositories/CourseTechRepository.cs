using Domain.Entities;
using Domain.Repositories;
using Persistance.Contexts;

namespace Persistance.Reposiories;

public class CourseTechRepository:EfCoreBaseRepository<CourseTechs,BaseDbContext>,ICourseTechRepository
{
    public CourseTechRepository(BaseDbContext context) : base(context)
    {
    }
}