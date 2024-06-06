using MaximTestCases.RequestsLimitLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MaximTestCases.RequestsLimitLogic;

public static class RequestsLimitStartUp
{
    public static IServiceCollection TryAddRequestsLimit(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IRequestsLimitService, RequestsLimitService>();
        
        return serviceCollection;
    }
}