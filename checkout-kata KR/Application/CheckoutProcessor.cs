using checkout_kata_KR.Interfaces.SKU;
using checkout_kata_KR.Models.SKU;
using System;

namespace checkout_kata_KR.Application
{
    public class CheckoutProcessor : ICheckout
    {
        public CheckoutProcessor()
        {
            List<Reciept> reciepts = new List<Reciept>();

            // Setup initial SKUs prices
            var SKUs = SetupInitialPrices();

            // Take in user input as shopping cart items which are entered via SKU characters
            var checkoutList = UserInputClass();

            // Compile checkoutList into a Reciept class
            reciepts = GetUnitPrice(SKUs, checkoutList);

            // Apply discounts
            reciepts = CheckDiscounts(reciepts);

            // Display total price at end of application.
            var totalPrice = GetTotalPrice(reciepts);

            Console.WriteLine("Your total is £" + totalPrice);
        }

        private List<Reciept> CheckDiscounts(List<Reciept> reciepts)
        {
            List<Reciept> SortedList = reciepts.OrderBy(x => x.ItemName).ToList();
            List<Reciept> OutputList = new List<Reciept>();

            var groupedList = SortedList.GroupBy(x => x.ItemName).Select(x => x.ToList()).ToList();

            foreach (var group in groupedList)
            {
                var grpCount = group.Count();
                var discount = group.First().SpecialPrice;
                var item = group.First();

                var split = discount.Split("for");
                var threshold = Int32.Parse(split[0]);
                var newPrice = Int32.Parse(split[1]);

                if (grpCount >= threshold)
                {
                    Console.Write("Discount applicable");
                    OutputList.Add(new Reciept 
                    {  
                      ItemName = item.ItemName,
                      SpecialPrice = item.SpecialPrice,
                      ItemPrice = newPrice,
                    }
                    );
                }
                else
                {
                    Console.WriteLine("Discount not applied");
                    foreach(var items in group)
                    {
                        OutputList.Add((Reciept) items);
                    }
                }
                
            }
            return OutputList;
        }

        private List<string> UserInputClass()
        {
            Console.WriteLine("Welcome to the Self-Checkout Service, please scan your items.");
            var Checkoutlist = new List<string>();
            Checkoutlist = Scan(Checkoutlist);

            return Checkoutlist;
        }

        private List<SKU> SetupInitialPrices()
        {
            SKU a = new SKU() { SkuName = "a", UnitPrice = 50, SpecialPrice = "3 for 130" };
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
            
            return totalPrice;
        }

        public List<Reciept> GetUnitPrice(List<SKU> SKUs, List<string> CheckoutList)
        {
            List<Reciept> receipt = new List<Reciept>();
            foreach (var item in CheckoutList)
            {
                // Check if item exists in SKU list
                if (SKUs.Where(x => x.SkuName.Equals(item)).Count() < 1)
                {
                    Console.WriteLine("Unknown item scanned, please wait for staff assistance.");
                }

                foreach (var Sku in SKUs)
                {
                    if (item.Equals(Sku.SkuName))
                    {
                        var recieptItem = new Reciept()
                        {
                            ItemName = item,
                            ItemPrice = Sku.UnitPrice,
                            SpecialPrice = Sku.SpecialPrice,
                        };

                        receipt.Add(recieptItem);
                    }
                }
            }
            return receipt;
        }

        public List<string> Scan(List<string> checkoutList)
        {
            var inProgess = true;
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
                    checkoutList.Add(item);
                    Console.WriteLine("Please enter done to proceed to payment");
                }
            }
            return checkoutList;
        }
    }
}