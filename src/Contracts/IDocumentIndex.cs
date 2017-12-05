namespace Thalus.Documents.Contracts
{
    public interface IDocumentIndex
    {
        /// <summary>
        /// Gets or sets the name of the document as <see cref="string"/> for example 00_firstdoc.md
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the description on the document as <see cref="string"/> for example "A document"
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the full qualified path of the document as <see cref="string"/> for example c:\temp\docs\00_mydoc.doc
        /// </summary>
        string Path { get; set; }

        /// <summary>
        /// Gets or sets the type of the document as <see cref=" string"/> for example *.md, *.txt for files and "directory" for folders
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets the index of a document as <see cref="int"/> per hierachy level
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// Gets the underlying data as <see cref="string"/>. Loads it from <see cref="Path"/> recursively.
        /// </summary>
        /// <returns></returns>
        string AsString();

        /// <summary>
        /// Gets the underlyung data as <see cref="string"/>. Loads it from <see cref="Path"/> recursively
        /// </summary>
        /// <returns></returns>
        byte[] AsByte();

    }
}