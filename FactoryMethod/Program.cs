﻿using FactoryMethod;

Console.Title = "Factory Method";

var factories = new List<DiscountFactory>{
    new CodeDiscountFactory(Guid.NewGuid()),
    new CountryDiscountFactory("IN"),
};

foreach (var factory in factories)
{
    var discountService = factory.CreateDiscountService();

    Console.WriteLine($"Percentage {discountService.DiscountPercentage} coming from {discountService}");
}
