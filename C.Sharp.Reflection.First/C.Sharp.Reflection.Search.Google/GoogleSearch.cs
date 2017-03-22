﻿using C.Sharp.Reflection.Search.Attributes;

namespace C.Sharp.Reflection.Search.Google
{
    [SearchProviderName("Google")]
    public class GoogleSearch : ISearch
    {
        #region ISearch Implementation

        public string Search(string term) => "Google is down";

        #endregion
    }
}
