using Ardalis.Specification.EntityFrameworkCore;

namespace NSLogistics.Infrastructure.Persistance.Repositories;

public class EfRepository<T>
    : RepositoryBase<T> where T : class
{
    public EfRepository(AppDbContext dbContext) : base(dbContext) { }
}
