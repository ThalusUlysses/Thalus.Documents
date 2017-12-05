using System;
using System.IO;
using System.Linq;
using Thalus.Documents.Contracts;

namespace Thalus.Documents
{
    public class DocumentIndexer
    {
        private Func<string, string> _descriptionLookup;

        public DocumentIndexer() : this(null)
        {
        }

        public DocumentIndexer(Func<string, string> descriptionLookup)
        {
            _descriptionLookup = descriptionLookup;
        }

        public IDocumentIndex Index(string path, bool deep = false)
        {
            DocumentCollection c = new DocumentCollection {Type = "directory", Index = 0, Path = path};
            Index(c, deep);

            return c;
        }

        private void Index(DocumentCollection c, bool deep)
        {
            var files = Directory.GetFiles(c.Path).OrderBy(i => i);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);

                string desc = _descriptionLookup?.Invoke(fi.Name);
                DocumentIndex d = new DocumentIndex {Index = c.Count, Name = fi.Name, Path = fi.FullName, Type = fi.Extension, Description = desc};
                c.Add(d);
            }

            if (deep)
            {
                var dirs = Directory.GetDirectories(c.Path).OrderBy(i => i);
                foreach (string dir in dirs)
                {
                    DirectoryInfo di = new DirectoryInfo(dir);
                    string desc = _descriptionLookup?.Invoke(di.Name);

                    DocumentCollection coll = new DocumentCollection
                    {
                        Path = di.FullName,
                        Name = di.Name,
                        Type = "directory",
                        Index = c.Count,Description = desc
                    };

                    Index(coll, true);
                }
            }
        }
    }
}