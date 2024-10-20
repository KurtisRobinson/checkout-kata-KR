using checkout_kata_KR.Models.SKU;

namespace checkout_kata_KR.Application
{
    public class CheckoutTests
    {
        [Fact]
        public void SKU_Valid_Input_Returns_Ok()
        {
            var testCheckoutList = new List<string>()
            {
                "A",
                "B",
                "C",
                "D"
            };

            SKU a = new SKU() { SkuName = "a", UnitPrice = 50, SpecialPrice = "3 for 150" };
            SKU b = new SKU() { SkuName = "b", UnitPrice = 30, SpecialPrice = "2 for 45" };
            SKU c = new SKU() { SkuName = "c", UnitPrice = 20, SpecialPrice = "" };
            SKU d = new SKU() { SkuName = "d", UnitPrice = 15, SpecialPrice = "" };

            List<SKU> SKUs = new List<SKU>() { a, b, c, d };

            List<Reciept> reciepts = new List<Reciept>();

            var checkoutService = new CheckoutProcessor();

            var endTotal = checkoutService.GetTotalPrice(reciepts);

            var actualTotal = 240.00m;

            Assert.Equal(endTotal, actualTotal);
        }

        [Fact]
        public void SKU_InValid_Input_Returns_Bad()
        {

        }

        [Fact]
        public void SKU_Special_Input_Returns_Ok()
        {

        }
    }
}