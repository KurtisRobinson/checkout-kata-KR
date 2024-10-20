using checkout_kata_KR.Interfaces.SKU;
using checkout_kata_KR.Models.SKU;

namespace checkout_kata_KR.Application
{
    public class CheckoutProcessor : ICheckout
    {
        public CheckoutProcessor()
        {
            List<Reciept> reciepts = new List<Reciept>();

            // Check if entered has item has special offer, if threshold for offer has been met, apply discount.
            // Setup initial SKUs prices, to be amended later
            var SKUs = SetupInitialPrices();

            // Take in user input as shopping cart items which are entered via SKU characters
            var checkoutList = UserInputClass();

            // Compile checkoutList into a Reciept class
            reciepts = GetUnitPrice(SKUs, checkoutList);

            // Apply discounts
            //reciepts = CheckDiscounts(reciepts);

            // Display total price at end of application.
            var totalPrice = GetTotalPrice(reciepts);

            Console.WriteLine("Your total is £" + totalPrice);
        }

        private List<string> UserInputClass()
        {
            Console.WriteLine("Welcome to the Self-Checkout Service, please scan your items.");

            var inProgess = true;
            var Checkoutlist = new List<string>();

            while (inProgess)
            {
                var item = Console.ReadLine();
                if (item.Equals("done"))
                {
                    inProgess = false;
                    Console.WriteLine("Please check your shopping total and proceed to payment");
                }
                else
                {
                    Checkoutlist.Add(item);
                    Console.WriteLine("Please enter done to proceed to payment");
                }
            }
            return Checkoutlist;
        }

        private List<SKU> SetupInitialPrices()
        {
            SKU a = new SKU() { SkuName = "a", UnitPrice = 50, SpecialPrice = "3 for 150" };
            SKU b = new SKU() { SkuName = "b", UnitPrice = 30, SpecialPrice = "2 for 45" };
            SKU c = new SKU() { SkuName = "c", UnitPrice = 20, SpecialPrice = "" };
            SKU d = new SKU() { SkuName = "d", UnitPrice = 15, SpecialPrice = "" };

            List<SKU> SKUs = new List<SKU>() { a, b, c, d };

            return SKUs;
        }

        public decimal GetTotalPrice(List<Reciept> reciept)
        {
            decimal totalPrice = 0.00m;
            foreach(var item in reciept)
            {
                totalPrice = totalPrice + item.ItemPrice;
            }
            // Add up total unit price of items in reciept

            return totalPrice;
        }

        public List<Reciept> GetUnitPrice(List<SKU> SKUs, List<string> CheckoutList)
        {
            List<Reciept> receipt = new List<Reciept>();
            // For list of items, check if special discount can be applied
            foreach (var item in CheckoutList)
            {
                foreach (var Sku in SKUs)
                {
                    if (item.Equals(Sku.SkuName))
                    {
                        var recieptItem = new Reciept()
                        {
                            ItemName = item,
                            ItemPrice = (int)Sku.UnitPrice
                        };

                        receipt.Add(recieptItem);
                    }
                }
            }
            return receipt;
        }

        public void Scan(string item)
        {
            // Scan in items, returned an ordered list so we can check number of same occurrences.
        }
    }
}