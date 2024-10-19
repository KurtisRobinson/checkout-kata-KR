using checkout_kata_KR.Interfaces.SKU;
using checkout_kata_KR.Models.SKU;

namespace checkout_kata_KR.Application
{
    public class CheckoutProcessor : ICheckout
    {
        public CheckoutProcessor(List<string> checkoutList)
        {

            var SKUs = SetupInitialPrices();

            foreach (var item in checkoutList)
            {
                Scan(item);
            }

            GetTotalPrice(SKUs);
        }

        private List<SKU>  SetupInitialPrices()
        {
            SKU a = new SKU() { SkuName=  "a", UnitPrice = 50, SpecialPrice = "3 for 150"};
            SKU b = new SKU() { SkuName = "b", UnitPrice = 30, SpecialPrice = "2 for 45" };
            SKU c = new SKU() { SkuName = "c", UnitPrice = 20, SpecialPrice = "" };
            SKU d = new SKU() { SkuName = "d", UnitPrice = 15, SpecialPrice = "" };

            List<SKU> SKUs = new List<SKU>() { a, b, c, d };

            return SKUs;
        }

        public int GetTotalPrice(List<SKU> SKUs)
        {
            // For list of items, check if special discount can be applied
            var totalPrice = 0;
            return totalPrice;
        }

        public void Scan(string item)
        {
            // For item, check current SKU entries and get UnitPrice 
            throw new NotImplementedException();
        }
    }
}