using Bridge;

Console.Title = "Bridge";

var noCoupon = new NoCoupon();
var oneRupeeCoupon = new OneRupeeCoupon();

var vegMenu = new VegetarianMenu(noCoupon);
var nonVegMenu = new NonVegMenu(oneRupeeCoupon);

Console.WriteLine($"Bill for veg menu {vegMenu.CalculatePrice()}");
Console.WriteLine($"Bill for non veg menu {nonVegMenu.CalculatePrice()}");
