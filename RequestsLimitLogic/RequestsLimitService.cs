using MaximTestCases.RequestsLimitLogic.Interfaces;

namespace MaximTestCases.RequestsLimitLogic;

public class RequestsLimitService : IRequestsLimitService
{
    private readonly SemaphoreSlim semaphoreSlim;
    
    public RequestsLimitService(IConfiguration configuration)
    {
        var limit = configuration.GetSection("Settings").GetSection("ParallelLimit").Get<int>();

        semaphoreSlim = new SemaphoreSlim(0, limit);
        
        // для проверки верной работы
        // semaphoreSlim = new SemaphoreSlim(limit, limit);
    }
    
    public async Task<bool> IsLimit()
    {
        return await semaphoreSlim.WaitAsync(0);
    }

    public void Exit()
    {
        semaphoreSlim.Release();
    }
}