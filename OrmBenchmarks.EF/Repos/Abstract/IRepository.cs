using OrmBenchmarks.Entities.Abstract;

namespace OrmBenchmarks.EF.Repos.Abstract;

public interface IRepository<T> where T : class, IEntity
{
    Task<List<T>> GetAll(bool ignoreDeleted = true);
    Task<T?> GetById(long id);
    Task<List<T>> GetByIds(List<long> ids);
    Task<T> Add(T entity);
    Task<List<T>> Add(List<T> entities);
    Task<T> Update(T entity);
    Task<List<T>> Update(List<T> entities);
    Task<T> AddOrUpdate(T entity);
    Task<int> Save(T entity);
    Task<T> Delete(T entity);
    Task<List<T>> Delete(List<T> entities);
    Task<T> Restore(T entity);
    Task<List<T>> Restore(List<T> entities);
}