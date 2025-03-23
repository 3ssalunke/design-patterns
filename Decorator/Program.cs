using Decorator;

Console.Title = "Decorator";

var cloudMailService = new CloudMailService();
cloudMailService.SendEmail("Hi through cloud mail service");

var onPremiseMailService = new OnPremiseMailService();
onPremiseMailService.SendEmail("Hi through on premise mail service");

var statisticsDecorator = new StatisticsDecorator(onPremiseMailService);
statisticsDecorator.SendEmail($"Hi through on premise mail service via {nameof(StatisticsDecorator)}");

var databaseDecorator = new MessageDatabaseDecorator(cloudMailService);
databaseDecorator.SendEmail($"Hi through cloud mail service via {nameof(MessageDatabaseDecorator)}");