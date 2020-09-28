using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Given an array of people objects (where each person has a name and a number of pizza slices
/// they’re hungry for) and a number for the number of slices that the pizza can be sliced
/// into, return the number of pizzas you need to buy.
///
///     arr = [{ name: Joe, num: 9 }, { name: Cami, num: 3 },{ name: Cassidy, num: 4 }]
///     gimmePizza(arr, 8)
///     2 // 16 slices needed, pizzas can be sliced into 8 pieces, so 2 pizzas should be ordered
///
/// </summary>
class HowManyPizzas
{
    class People
    {
        public string Name { get; set; }
        public int NumSlices { get; set; }
    }

    static int GimmePizza(List<People> people, int pizzaSlices)
        => (int)Math.Ceiling((decimal)people.Sum(p => p.NumSlices) / pizzaSlices);

    static void Main()
    {
        var peeps = new List<People>
        {
            new People { Name = "Joe", NumSlices = 9 },
            new People { Name = "Cami", NumSlices = 3 },
            new People { Name = "Cassidy", NumSlices = 4 }
        };

        Console.WriteLine($"This'll doo: { GimmePizza(peeps, 8) }");
    }
}