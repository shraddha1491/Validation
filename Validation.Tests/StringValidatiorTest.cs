using Common.Logging;
using NSubstitute;
using System;
using Xunit;

namespace Validation.Tests
{
    public class StringValidatiorTest
    {
        [Fact]
        public void Test_EmptyString()
        {
            var logger = Substitute.For<ILogger>();
            string input = String.Empty;
            IValidator validator = new StringValidator(logger);
            bool result = validator.Validate(input);
            Assert.True(result);

        }

        [Fact]
        public void Test_Null()
        {
            var logger = Substitute.For<ILogger>();
            string input = null;
            IValidator validator = new StringValidator(logger);
            Assert.Throws<ArgumentNullException>( ()=>validator.Validate(input));
        }

        [Fact]
        public void Test_Correct()
        {
            var logger = Substitute.For<ILogger>();
            string input = "(This 'is a' test)";
            IValidator validator = new StringValidator(logger);
            bool result = validator.Validate(input);
            Assert.True(result);

        }

        [Fact]
        public void Test_Incorrect()
        {
            var logger = Substitute.For<ILogger>();
            string input = "'This (is a' test) ";
            IValidator validator = new StringValidator(logger);
            bool result = validator.Validate(input);
            Assert.False(result);

        }

        [Fact]
        public void Test_NullLogger()
        {
            ILogger logger = null;
            Assert.Throws<ArgumentNullException>(() => new StringValidator(logger));

        }


    }
}
