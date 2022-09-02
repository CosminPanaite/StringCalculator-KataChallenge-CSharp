namespace StringCalculatorTDD
{
    public class StringCalculatorTests
    {
        private StringCalculator calculator = new StringCalculator();
        [Fact]
        public void Test1()
        {
            var result = calculator.Add("");
            Assert.Equal(0, result);

        }
        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("2#3!4", 9)]
        [InlineData("2\n3!4", 9)]
        public void ReturnsGivenStringWithTwoCommaSeparateed(string numbers, int expectedResults)
        {
            var result = calculator.Add(numbers);
            Assert.Equal(expectedResults, result);

        }

        [Theory]
        [InlineData("-1,2", "Negatives not allowed : -1")]

        public void ThrowNegativeException(string numbers, string expectedMessage)
        {
            Action action = () => calculator.Add(numbers);
            var ex = Assert.Throws<Exception>(action);
            Assert.Equal(expectedMessage, ex.Message);

        }
        [Theory]
        [InlineData("1001,2,3", 5)]

        public void IgnoreGreaterThan1000(string numbers, int expectedResult)
        {
            var result = calculator.Add(numbers);
            Assert.Equal(expectedResult, result);

        }

    }
}