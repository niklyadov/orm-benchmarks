using OrmBenchmarks.Entities;
using OrmBenchmarks.Services;

namespace OrmBenchmarks.Benchmarks.Scenarios.Abstract;

public abstract class BaseUserScenario
{
    protected AUsersService Service;

    protected BaseUserScenario(AUsersService service)
    {
        Service = service;
    }

    public virtual async Task<User> AddRandomUserAsync()
    {
        return await Service.AddRandomAsync();
    }

    public virtual async Task<User> AddRandomUserAndDeleteAsync()
    {
        return await Service.DeleteAsync(await AddRandomUserAsync());
    }
    
    public virtual async Task<User> AddRandomUserAndDeleteAndRestoreAsync()
    {
        return await Service.RestoreAsync(await AddRandomUserAndDeleteAsync());
    }
    
    public virtual async Task<User> AddRandomUserAndUpdateAsync()
    {
        return await Service.UpdateRandomAsync(await AddRandomUserAsync());

    }
    
    public virtual async Task<User> AddRandomUserAndFindByIdAsync()
    {
        var user = await AddRandomUserAsync();

        return await Service.GetByIdAsync(user.Id);
    }
}