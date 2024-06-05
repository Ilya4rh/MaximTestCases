using MaximTestCases.WordsBlackListLogic.Interfaces;

namespace MaximTestCases.WordsBlackListLogic;

public class WordsBlackListServiceService : IWordsBlackListService
{
    private readonly HashSet<string> blacklist;

    public WordsBlackListServiceService(IConfiguration configuration)
    {
        blacklist = configuration.GetSection("Settings").GetSection("WordsBlackList").Get<HashSet<string>>();
    }
    
    public bool IsWordInList(string word)
    {
        return blacklist.Contains(word);
    }
}