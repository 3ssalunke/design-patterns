namespace Singleton
{
    public class Logger
    {
        private static readonly Lazy<Logger> _lazyLogger = new Lazy<Logger>(() => new Logger());
        // private static Logger? _instance;

        public static Logger Instance
        {
            get
            {
                // if (_instance == null)
                // {
                //     _instance = new Logger();
                // }
                // return _instance;
                return _lazyLogger.Value;
            }
        }

        protected Logger()
        { }

        public void Log(string message)
        {
            Console.WriteLine($"Message to log: {message}");
        }
    }
}