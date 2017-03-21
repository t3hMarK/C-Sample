namespace C.Sharp.Reflection.Search
{
    public interface ISearch
    {
        /// <summary>
        /// Search for a term
        /// </summary>
        /// <param name="term">Term of search</param>
        /// <returns>Search result</returns>
        string Search(string term);
    }
}
