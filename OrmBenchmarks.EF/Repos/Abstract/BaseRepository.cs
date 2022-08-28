using Microsoft.EntityFrameworkCore;
using OrmBenchmarks.Entities.Abstract;

namespace OrmBenchmarks.EF.Repos.Abstract;

public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>, IDisposable
    where TEntity : class, IEntity
    where TContext : EfApplicationContext
{
    private readonly TContext _dbContext;

    protected BaseRepository(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public virtual async Task<List<TEntity>> GetAll(bool ignoreDeleted = true)
    {
        var set = _dbContext.Set<TEntity>().Where(p => !ignoreDeleted || !p.IsDeleted);

        return await set.ToListAsync();
    }

    public virtual async Task<TEntity?> GetById(long id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<List<TEntity>> GetByIds(List<long> ids)
    {
        return await _dbContext.Set<TEntity>()
            .Where(x => ids.Contains(x.Id))
            .ToListAsync();
    }

    public virtual async Task<TEntity> Add(TEntity entity)
    {
        var entry = _dbContext.Set<TEntity>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<List<TEntity>> Add(List<TEntity> entities)
    {
        await _dbContext.Set<TEntity>().AddRangeAsync(entities);

        foreach (var entity in entities)
            _dbContext.Entry(entity).State = EntityState.Added;

        await _dbContext.SaveChangesAsync();

        return entities;
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<List<TEntity>> Update(List<TEntity> entities)
    {
        foreach (var entity in entities)
            _dbContext.Entry(entity).State = EntityState.Added;

        await _dbContext.SaveChangesAsync();
        return entities;
    }

    public async Task<TEntity> AddOrUpdate(TEntity entity)
    {
        if (entity.Id > 0 && await GetById(entity.Id) != null)
            return await Update(entity);

        return await Add(entity);
    }

    public virtual async Task<int> Save(TEntity entity)
    {
        return await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<TEntity> Delete(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException("Entity with was null");

        entity.IsDeleted = true;
        entity.DeletedDateTime = DateTime.UtcNow;

        return await Update(entity);
    }

    public virtual async Task<List<TEntity>> Delete(List<TEntity> entities)
    {
        if (entities == null)
            throw new ArgumentNullException("Entity with was null");

        if (entities.Count == 0)
            return entities;

        foreach (var entity in entities)
        {
            entity.IsDeleted = true;
            entity.DeletedDateTime = DateTime.UtcNow;
        }

        return await Update(entities);
    }

    public virtual async Task<TEntity> Restore(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException("Entity with was null");

        entity.IsDeleted = false;
        entity.DeletedDateTime = null;

        return await Update(entity);
    }

    public virtual async Task<List<TEntity>> Restore(List<TEntity> entities)
    {
        if (entities == null)
            throw new ArgumentNullException("Entity with was null");

        if (entities.Count == 0)
            return entities;

        foreach (var entity in entities)
        {
            entity.IsDeleted = false;
            entity.DeletedDateTime = null;
        }

        return await Update(entities);
    }
}