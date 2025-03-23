namespace Template
{
    public abstract class MailParser
    {
        public virtual void FindServer()
        {
            Console.WriteLine("Finding server...");
        }

        public abstract void AuthenticateToServer();

        public string ParseHtmlMailBody(string identifier)
        {
            Console.WriteLine("Parsing HTML mail body...");
            return $"This is the body of mail with id {identifier}";
        }

        public string ParseMailBody(string identifier)
        {
            Console.WriteLine("Parsing Mail body(in template method)...");
            FindServer();
            AuthenticateToServer();
            return ParseHtmlMailBody(identifier);
        }
    }

    public class ExchangeMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to exchange");
        }
    }

    public class ApacheMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to apache");
        }
    }

    public class EudoraMailParser : MailParser
    {
        public override void FindServer()
        {
            Console.WriteLine("Finding eudora mail server through custom algorithm...");
        }
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to eudora");
        }
    }
}