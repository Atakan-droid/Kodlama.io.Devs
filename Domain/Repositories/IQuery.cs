using Domain.Entities;

namespace Domain.Repositories;

public interface IQuery<T> where T:Entity
{
    IQueryable<T> Query();
}