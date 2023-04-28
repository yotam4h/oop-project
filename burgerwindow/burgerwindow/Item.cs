using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item
{
    public abstract class Order
    {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }

        public virtual void Display()
        {
            Console.WriteLine(value: $"Item: {Name} | Price: {Price:C}");
        }

        public Order() : this(name: "", price: 0.00M) { }
        public Order(string name) : this(name, 0.00M) { }
        public Order(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override abstract string ToString();
    }

    public class IOrder
    {
        private readonly List<Order> cart = new();
        private readonly List<Order> menu = new()
        {
        new Food.Burger("small", new List<string>{"lettuce", "tomato", "onion"}),
        new Food.Burger("medium", new List<string>{"lettuce", "tomato", "onion", "cheese"}),
        new Food.Burger("large", new List<string>{"lettuce", "tomato", "onion", "cheese", "bacon"}),
        new Food.BurgerWithFries("medium", new List<string>{"lettuce", "tomato", "onion", "cheese"}),
        new Food.BurgerWithFries("large", new List<string>{"lettuce", "tomato", "onion", "cheese", "bacon"}),
        new Drink.Water(),
        new Drink.Soda("Coke", 500),
        new Drink.Soda("Sprite", 330),
        new Drink.Soda("Fanta", 330)
    };

        public void DisplayMenu()
        {
            Console.WriteLine("Here is the menu:");
            foreach (Order item in menu)
            {
                Console.Write($"{menu.IndexOf(item) + 1}. ");
                item.Display();
            }
            Console.WriteLine();
        }

        public void AddToOrder(Order item)
        {
            cart.Add(item);
            if (item is Drink.Soda)
            {
                Console.WriteLine("Would you like ice with that? (y/n)");
                do
                {
                    var input = Console.ReadLine().ToUpper();
                    if (input == "Y")
                    {
                        ((Drink.Soda)item).AddIce();
                        break;
                    }
                    else if (input == "N")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                } while (true);
            }

            Console.WriteLine($"Added {item.Name} to order.");
            Console.WriteLine();
        }

        public void RemoveFromOrder(Order item)
        {
            cart.Remove(item);
            Console.WriteLine($"Removed {item.Name} from order.");
            Console.WriteLine();

        }

        public void DisplayOrder()
        {
            Console.WriteLine("\nHere is your order:");

            foreach (Order item in cart)
            {
                item.Display();
            }
            Console.WriteLine();

        }

        internal int MenuLength()
        {
            return menu.Count;
        }

        internal Order GetMenuItem(int v)
        {
            return menu[v];
        }

        internal decimal TotalPrice()
        {
            decimal total = 0.00M;
            foreach (Order item in cart)
            {
                total += item.Price;
            }
            return total;
        }
    }
}

namespace Item.Food
{
    public class Burger : Order
    {
        public string Size { get; protected set; }
        public List<string> Ingredients { get; }

        public Burger(string size, List<string> ingredients) : base(name: "Burger", price: 0.00M)
        {
            Size = size.ToUpper();
            Ingredients = ingredients;
            Price = Size switch
            {
                "SMALL" => 5.99M,
                "MEDIUM" => 6.99M,
                "LARGE" => 7.99M,
                _ => 0.00M,
            };
        }

        public override void Display()
        {
            Console.WriteLine(value: ToString());
        }

        public override string ToString()
        {
            return $"Item: {Size} {Name} | {string.Join(", ", Ingredients)} | Price: {Price:C}";
        }
    }

    public class BurgerWithFries : Burger
    {
        public BurgerWithFries(string size, List<string> ingredients) : base(size: size, ingredients: ingredients)
        {
            Name = "Burger with Fries";
            Price += 2.99M;
        }
    }
}

namespace Item.Drink
{
    public abstract class Drink : Order
    {
        public bool HasIce { get; protected set; }

        public Drink() : this(hasIce: false) { }
        public Drink(bool hasIce)
        {
            HasIce = hasIce;
        }

        public virtual void AddIce()
        {
            Console.WriteLine(value: "Cannot add ice to this drink.");
        }
    }

    public class Water : Drink
    {
        public Water() : base(hasIce: false)
        {
            Name = "Water";
            Price = 0.00M;
        }

        public override string ToString()
        {
            return $"Item: {Name} | Price: {Price:C}";
        }

        public override void Display()
        {
            Console.WriteLine(value: ToString());
        }

    }

    public class Soda : Drink
    {
        public int Size { get; protected set; }

        public Soda(string name, int size) : base(hasIce: false)
        {
            Name = name;
            Size = size;
            Price = Size switch
            {
                330 => 1.99M,
                500 => 2.49M,
                _ => 0.00M,
            };
        }
        public override void AddIce() { HasIce = true; Name += " with Ice"; }

        public override string ToString()
        {
            if (HasIce)
            {
                return $"Item: {Name} with ice | Price: {Price:C}";
            }
            return $"Item: {Name} | Price: {Price:C}";
        }
    }


}


