using Domain.Entities;
using Domain.Repositories;
using Persistance.Contexts;

namespace Persistance.Reposiories;

public class UserRepository:EfCoreBaseRepository<User,BaseDbContext>,IUserRepository{
    public UserRepository(BaseDbContext context) : base(context)
    {
    }
}