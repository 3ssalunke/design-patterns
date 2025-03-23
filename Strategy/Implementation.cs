namespace Strategy
{
    public interface IExportService
    {
        void Export(Order order);
    }

    public class JsonExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to json");
        }
    }

    public class XmlExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to xml");
        }
    }

    public class CsvExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to csv");
        }
    }

    public class Order
    {
        public string Customer { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public IExportService? ExportService { get; set; }

        public Order(string customer, int amount, string name)
        {
            Customer = customer;
            Amount = amount;
            Name = name;
        }

        public void Export()
        {
            ExportService?.Export(this);
        }
    }
}