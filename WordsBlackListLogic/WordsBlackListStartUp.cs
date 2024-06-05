using MaximTestCases.WordsBlackListLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MaximTestCases.WordsBlackListLogic;

public static class WordsBlackListStartUp
{
    public static IServiceCollection TryAddWordsBlackList(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IWordsBlackListService, WordsBlackListServiceService>();
        
        return serviceCollection;
    }
}