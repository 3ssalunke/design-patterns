namespace AbstractFactory
{
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostService CreateShippingCostService();
    }

    public interface IDiscountService
    {
        public int DiscountPercentage { get; }
    }

    public interface IShippingCostService
    {
        public decimal ShippingCosts { get; }
    }

    public class IndiaDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }

    public class AustraliaDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }

    public class IndiaShippingCostService : IShippingCostService
    {
        public decimal ShippingCosts => 5;
    }

    public class AustraliaShippingCostService : IShippingCostService
    {
        public decimal ShippingCosts => 4;
    }

    public class IndiaShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new IndiaDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new IndiaShippingCostService();
        }
    }

    public class AustraliaShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new AustraliaDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new AustraliaShippingCostService();
        }
    }

    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostService _shippingCostService;
        private int _orderCosts;

        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService = factory.CreateDiscountService();
            _shippingCostService = factory.CreateShippingCostService();
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total Costs = {_orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostService.ShippingCosts}");
        }
    }
}