using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion
    }
}
