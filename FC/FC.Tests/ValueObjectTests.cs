using System;
using Xunit;

namespace FC.Tests
{
    public class ValueObjectTests
    {
        [Fact]
        public void Test()
        {
            Email email1 = (Email)"asdas@asdas.com";
            Email email2 = (Email)"asdas@asdas.com";

            Assert.Equal(email1, email2);
            Assert.True(email1 == email2);
        }
    }

    public class Email : ValueObject<Email>
    {
        public string Value { get; }

        private Email(string value) => Value = value;

        public static Email Create(string value) => new Email(value);

        public static implicit operator string(Email email) => email.Value;

        public static explicit operator Email(string value) => Email.Create(value);

        protected override bool EqualsCore(Email other) => Value == other.Value;

        protected override int GetHashCodeCore() => Value.GetHashCode();
    }
}
