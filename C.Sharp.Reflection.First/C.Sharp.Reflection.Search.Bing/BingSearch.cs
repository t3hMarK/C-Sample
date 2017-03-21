using C.Sharp.Reflection.Search.Attributes;

namespace C.Sharp.Reflection.Search.Bing
{
    [SearchProviderName("Bing")]
    public class BingSearch : ISearch
    {
        public string Search(string term) => "Bing... seriously...";
    }
}
