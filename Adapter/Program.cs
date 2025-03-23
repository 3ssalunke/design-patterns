using ClassAdapter;

Console.Title = "Adapter";

ICityAdapter Adapter = new CityAdapter();
var city = Adapter.GetCity();

Console.WriteLine($"{city.FullName}, {city.Inhabitants}");
