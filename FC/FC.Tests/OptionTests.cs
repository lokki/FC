using FC;
using Xunit;
using static FC.F;

namespace FC.Tests
{
    public class OptionTests
    {
        [Fact]
        public void Test()
        {
            string Greet(Option<string> name)
                => name.Match(
                    None: () => "Hello, stranger!",
                    Some: n => $"Hello, {n}!");

            var a = Greet(None);
            var b = Greet(Some("Vasya"));

            Assert.Equal("Hello, stranger!", a);
            Assert.Equal("Hello, Vasya!", b);
        }
    }
}
