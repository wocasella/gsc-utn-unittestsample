namespace Utils.Tests.Unit
{
    public class StringExtensionsTests
    {
        public class TheMethod_CountCharOccurrences : StringExtensionsTests
        {
            [Theory]
            [InlineData('a', 1)]
            [InlineData('u', 3)]
            [InlineData('U', 3)]
            [InlineData('$', 0)]
            [InlineData('+', 1)]
            public void Should_be_able_to_count_char_occurrences_in_simple_sentence(char chr, int expected)
            {
                // arrange
                const string sentence = "Curso fullstack GSC+UTN!";

                // act
                int count = sentence.CountCharOccurrences(chr);

                // assert
                count.Should().Be(expected);
            }
        }
    }
}
