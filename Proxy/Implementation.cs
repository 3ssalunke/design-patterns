namespace Proxy
{
    public interface IDocument
    {
        public void DisplayContent();
    }

    public class Document : IDocument
    {
        public string? Title { get; private set; }
        public string? Content { get; private set; }
        public int AuthorId { get; private set; }
        public DateTimeOffset LastAccessed { get; private set; }
        private string _filename;

        public Document(string filename)
        {
            _filename = filename;
            LoadDocument(_filename);
        }

        private void LoadDocument(string filename)
        {
            Console.WriteLine($"Executing expensive action: loading file {filename} from the disk");
            Thread.Sleep(1000);

            Title = "An expensive document";
            Content = "Lots and lots of content";
            AuthorId = 1;
            LastAccessed = DateTimeOffset.UtcNow;
        }

        public void DisplayContent()
        {
            Console.WriteLine($"Title: {Title}, Content: {Content}");
        }
    }

    public class DocumentProxy : IDocument
    {
        private Lazy<Document> _document;
        private string _filename;

        public DocumentProxy(string filename)
        {
            _filename = filename;
            _document = new Lazy<Document>(() => new Document(_filename));
        }

        public void DisplayContent()
        {
            _document.Value.DisplayContent();
        }
    }

    public class ProtectedDocumentProxy : IDocument
    {
        private string _filename;
        private string _userRole;
        private DocumentProxy _documentProxy;

        public ProtectedDocumentProxy(string filename, string userRole)
        {
            _filename = filename;
            _userRole = userRole;
            _documentProxy = new DocumentProxy(_filename);
        }

        public void DisplayContent()
        {
            if (_userRole != "viewer")
            {
                throw new UnauthorizedAccessException();
            }

            _documentProxy.DisplayContent();
        }
    }
}