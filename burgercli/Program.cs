// Item.Food.Burger test1 = new(size: "small", ingredients: new List<string> { "lettuce", "tomato", "onion" });
// test1.Display();
// Item.Food.BurgerWithFries test2 = new(size: "medium", ingredients: new List<string> { "lettuce", "tomato", "onion" });
// test2.Display();

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        var orderInterface = new Item.IOrder();
        var done = false;

        Console.WriteLine("\n*********************************");
        Console.WriteLine("Welcome to the restaurant!");
        Console.WriteLine("*********************************\n");

        orderInterface.DisplayMenu();

        while (!done)
        {
            Console.WriteLine("Enter an item number to add to your order (or 0 to finish):");

            if (int.TryParse(Console.ReadLine(), out int itemNumber))
            {
                if (itemNumber == 0)
                {
                    done = true;
                }
                else if (0 < itemNumber && itemNumber <= orderInterface.MenuLength())
                {
                    orderInterface.AddToOrder(orderInterface.GetMenuItem(itemNumber - 1));
                }
                else
                {
                    Console.WriteLine("Invalid item number. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        orderInterface.DisplayOrder();
        Console.WriteLine($"Total price: {orderInterface.TotalPrice():C}");
        Console.WriteLine("Thank you for your order!");
    }
}
