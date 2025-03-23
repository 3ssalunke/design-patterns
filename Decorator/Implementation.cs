using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Decorator
{
    public interface IMailService
    {
        public bool SendEmail(string message);
    }

    public class CloudMailService : IMailService
    {
        public bool SendEmail(string message)
        {
            Console.WriteLine($"Message \"{message}\" send via {nameof(CloudMailService)}");
            return true;
        }
    }

    public class OnPremiseMailService : IMailService
    {
        public bool SendEmail(string message)
        {
            Console.WriteLine($"Message \"{message}\" send via {nameof(OnPremiseMailService)}");
            return true;
        }
    }

    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;
        public MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }

        public virtual bool SendEmail(string message)
        {
            return _mailService.SendEmail(message);
        }
    }

    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService) { }

        public override bool SendEmail(string message)
        {
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}");
            return base.SendEmail(message);
        }
    }

    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        public List<string> SentMessages { get; private set; } = new List<string>();
        public MessageDatabaseDecorator(IMailService mailService) : base(mailService) { }

        public override bool SendEmail(string message)
        {
            if (base.SendEmail(message))
            {
                SentMessages.Add(message);
                return true;
            }

            return false;
        }
    }
}