namespace Evice.Authentication.Domain.SeedWork
{
    public interface IRepository<TEntity>
    {
        Task<bool> Add(TEntity entity);

        Task<bool> Update(TEntity entity);

        Task<bool> Delete(Guid id);
    }
}