using checkout_kata_KR.Interfaces.SKU;
using Moq;
using System.Text;

namespace checkout_kata_KR.Application
{
    public class CheckoutTests
    {
        private Mock<TextReader>? _ConsoleInput;
        private StringBuilder? _ConsoleOutput;
        private Mock<ICheckout>? _mockCheckout;

        [Fact]
        public void SKU_ValidDiscount_Input_Returns_Ok()
        {
            // Arrange
            _ConsoleOutput = new StringBuilder();
            var consoleOutputWriter = new StringWriter(_ConsoleOutput);
            _ConsoleInput = new Mock<TextReader>();
            Console.SetOut(consoleOutputWriter);
            Console.SetIn(_ConsoleInput.Object);
            SetupUserResponses("a", "a", "a", "done");

            // Act
            var checkoutService = new CheckoutProcessor();

            // Assert
            var expectedTotal = 130.00m;
            var response = GetConsoleOutput();
            var totalItem = response[5].ToString();
            var total = totalItem.Split('£');
            var actualTotal = Decimal.Parse(total[1]);
            Assert.Equal(expectedTotal, actualTotal);
        }

        [Fact]
        public void SKU_InValidDiscount_Input_Returns_Ok()
        {
            // Arrange
            _ConsoleOutput = new StringBuilder();
            var consoleOutputWriter = new StringWriter(_ConsoleOutput);
            _ConsoleInput = new Mock<TextReader>();
            Console.SetOut(consoleOutputWriter);
            Console.SetIn(_ConsoleInput.Object);
            SetupUserResponses("a", "b", "done");

            // Act
            var checkoutService = new CheckoutProcessor();

            // Assert
            var expectedTotal = 80.00m;
            var response = GetConsoleOutput();
            var totalItem = response[6].ToString();
            var total = totalItem.Split('£');
            var actualTotal = Decimal.Parse(total[1]);
            Assert.Equal(expectedTotal, actualTotal);
        }

        [Fact]
        public void SKU_Invalid_Input_Returns_Bad()
        {
            // Arrange
            _ConsoleOutput = new StringBuilder();
            var consoleOutputWriter = new StringWriter(_ConsoleOutput);
            _ConsoleInput = new Mock<TextReader>();
            Console.SetOut(consoleOutputWriter);
            Console.SetIn(_ConsoleInput.Object);
            SetupUserResponses("a", "a", "x", "done");

            // Act
            var checkoutService = new CheckoutProcessor();

            // Assert
            var expectedTotal = 100.00m;
            var response = GetConsoleOutput();
            var unknownItemText = response[5].ToString();
            var totalItem = response[7].ToString();
            var total = totalItem.Split('£');
            var actualTotal = Decimal.Parse(total[1]);
            Assert.Equal("Unknown item scanned, please wait for staff assistance.", unknownItemText);
            Assert.Equal(expectedTotal, actualTotal);
        }

        private MockSequence SetupUserResponses(params string[] userResponse) 
        { 
            var sequence = new MockSequence();
            foreach(var response in userResponse)
            {
                _ConsoleInput?.InSequence(sequence).Setup(x => x.ReadLine()).Returns(response); 
            }
            return sequence;
        }

        private string[]? GetConsoleOutput() 
        { 
            return _ConsoleOutput?.ToString().Split("\r\n");
        }
    }
}