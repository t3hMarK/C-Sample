using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.Sharp.Generic.Console
{
    public interface IDocument
    {
        string Title { get; set; }

        string Content { get; set; }
    }
}
