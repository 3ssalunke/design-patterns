using AbstractFactory;

Console.Title = "Abstract Factory";

var indiaShoppingCartPurchaseFactory = new IndiaShoppingCartPurchaseFactory();
var shoppingCartForIndia = new ShoppingCart(indiaShoppingCartPurchaseFactory);
shoppingCartForIndia.CalculateCosts();

var australiaShoppingCartPurchaseFactory = new AustraliaShoppingCartPurchaseFactory();
var shoppingCartForAustralia = new ShoppingCart(australiaShoppingCartPurchaseFactory);
shoppingCartForAustralia.CalculateCosts();
