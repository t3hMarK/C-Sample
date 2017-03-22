using System.Collections.Generic;
using System.Linq;

namespace C.Sharp.Generic.Console
{
    public class DocumentManager<TDocument> where TDocument : IDocument
    {
        #region Members

        private Queue<TDocument> _documentQueue;

        #endregion

        #region Properties

        /// <summary>
        /// Whether DocumentManager has a document
        /// </summary>
        public bool HasDocument => _documentQueue.Any();

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of DocumentManager
        /// </summary>
        public DocumentManager()
        {
            _documentQueue = new Queue<TDocument>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add a new Document
        /// </summary>
        /// <param name="document"></param>
        public void AddDocument(TDocument document) => _documentQueue.Enqueue(document);

        /// <summary>
        /// Take a Document from the DocumentManager
        /// </summary>
        /// <returns></returns>
        public TDocument TakeDocument() => HasDocument ? _documentQueue.Dequeue() : default(TDocument);
        
        /// <summary>
        /// Display every Document with title
        /// </summary>
        /// <param name="title"></param>
        public void DisplayDocumentsWithTitle(string title)
        {
            foreach(string doc in _documentQueue.Where(d => d.Title == title).OrderBy(d => d.Title).Select(d => d.Title))
            {
                System.Console.WriteLine(doc);
            }
        }

        #endregion
    }
}
