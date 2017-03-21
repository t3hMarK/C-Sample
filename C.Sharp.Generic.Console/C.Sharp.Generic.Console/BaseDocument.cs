using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C.Sharp.Generic.Console
{
    public abstract class BaseDocument : IDocument
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}