public class Program
{
    public static void Main(string[] args)
    {
        // Take in user input as shopping cart items which are entered via SKU character.
        UserInputClass();
        // Check if entered has item has special offer, if threshold for offer has been met, apply discount.
        CalculateSKUPrices();
        // Display total price at end of application.
    }

    private static void UserInputClass()
    {
        Console.WriteLine("Welcome to the Self-Checkout Service, please scan your items.");

        var inProgess = true;
        var Checkoutlist = new List<string>();

        while (inProgess)
        {
            var item = Console.ReadLine();
            if(item.Equals("done"))
            {
                inProgess = false;
            }
            else
            {
                Checkoutlist.Add(item);
                Console.WriteLine("Please enter done to proceed to payment");
            }
        }
    }
}