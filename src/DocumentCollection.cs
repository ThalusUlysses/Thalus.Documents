using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thalus.Documents.Contracts;

namespace Thalus.Documents
{
    public class DocumentCollection : IDocumentIndex
    {
        List<IDocumentIndex> _documents = new List<IDocumentIndex>();

        public IDocumentIndex this[int index]
        {
            get => Get()[index];
            set => Get()[index] = value;
        }

        public int Count => _documents.Count;

        public string AsString()
        {
            StringBuilder b = new StringBuilder();
            foreach (IDocumentIndex index in _documents)
            {
                b.AppendLine(index.AsString());
            }

            return b.ToString();
        }

        public byte[] AsByte()
        { 
            List<byte> bts = new List<byte>();
            foreach (IDocumentIndex index in _documents)
            {
                bts.AddRange(index.AsByte());
            }

            return bts.ToArray();
        }

        public void Add(IDocumentIndex d)
        {
            Get().Add(d);
        }

        public void RemoveAt(int idx)
        {
            Get().RemoveAt(idx);
        }

        public bool Remove(IDocumentIndex d)
        {
            return Get().Remove(d);
        }

        public void AddRange(IEnumerable<IDocumentIndex> d)
        {
            Get().AddRange(d);
        }

        private List<IDocumentIndex> Get()
        {
            if (_documents == null)
            {
                _documents = new List<IDocumentIndex>();
            }

            return _documents;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public int Index { get; set; }
    }
}