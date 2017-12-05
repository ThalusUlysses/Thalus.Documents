using System.IO;
using Thalus.Documents.Contracts;

namespace Thalus.Documents
{
    public class DocumentIndex :  IDocumentIndex
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public string Type { get; set; }

        public int Index { get; set; }

        public string AsString()
        {
            return File.ReadAllText(Path);
        }

        public byte[] AsByte()
        {
            return File.ReadAllBytes(Path);
        }

    }
}
