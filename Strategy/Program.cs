using Strategy;

Console.Title = "Strategy";

var order = new Order("Marvin Software", 5, "Visual Studio Licence");
order.ExportService = new JsonExportService();
order.Export();

order.ExportService = new CsvExportService();
order.Export();
