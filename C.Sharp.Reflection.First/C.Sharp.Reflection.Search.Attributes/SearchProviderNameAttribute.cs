using System;

namespace C.Sharp.Reflection.Search.Attributes
{
    public class SearchProviderNameAttribute : Attribute
    {
        /// <summary>
        /// Name of the search provider
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Create an SearchProviderNameAttribute with the specified name
        /// </summary>
        /// <param name="name">Name of the search provider</param>
        public SearchProviderNameAttribute(string name)
        {
            Name = name;
        }
    }
}
