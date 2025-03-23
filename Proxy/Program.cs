using Proxy;

Console.Title = "Hello, World!";

Console.WriteLine("Constructing a document");
var myDoc = new Document("Mydoc.pdf");
Console.WriteLine("Document constructed");
myDoc.DisplayContent();

Console.WriteLine("Constructing a proxy document");
var proxyDoc = new DocumentProxy("Mydoc.pdf");
Console.WriteLine("Document constructed");
proxyDoc.DisplayContent();

Console.WriteLine("Constructing a protected proxy document");
var protectedProxyDoc = new ProtectedDocumentProxy("Mydoc.pdf", "viewer");
Console.WriteLine("Document constructed");
protectedProxyDoc.DisplayContent();

Console.WriteLine("Constructing a protected proxy document");
var protectedProxyDoc2 = new ProtectedDocumentProxy("Mydoc.pdf", "");
Console.WriteLine("Document constructed");
protectedProxyDoc2.DisplayContent();
