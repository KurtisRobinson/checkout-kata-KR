namespace checkout_kata_KR.Application
{
    public class CheckoutTests
    {
        [Fact]
        public void SKU_Valid_Input_Returns_Ok()
        {
            var checkoutService = new CheckoutProcessor();

            var testCheckoutList = new List<string>()
            {
                "A",
                "B",
                "C",
                "D"
            };

            decimal endTotal = checkoutService.CalculateTotal(testCheckoutList);

            decimal actualTotal = 230.00m;

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