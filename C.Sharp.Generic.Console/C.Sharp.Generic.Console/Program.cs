using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.Sharp.Generic.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentManager<BaseDocument> documentManager = new DocumentManager<BaseDocument>();

            documentManager.AddDocument(new Contract() { Title = "Contract 1" });
            documentManager.AddDocument(new Contract() { Title = "Contract 2" });
            documentManager.AddDocument(new PurchaseOrder() { Title = "PO 1" });
            documentManager.AddDocument(new PurchaseOrder() { Title = "PO 2" });
            documentManager.AddDocument(new PurchaseOrder() { Title = "PO 3" });
            documentManager.AddDocument(new PurchaseOrder() { Title = "PO 4" });

            if(documentManager.HasDocument)
            {
                System.Console.WriteLine(documentManager.TakeDocument().Title);
            }

            System.Console.ReadKey();
        }
    }
}
