using System;
using Xunit;
using Registration.Services;

namespace Registration.UnitTests.Services
{
    public class RegistrationService_IsDigitCorrect
    {
        [Theory]
        [InlineData("0000")]
        [InlineData("9992")]
        public void Return0(string value)
        {
            var result = RegistrationService.GetDigit(value);
            Assert.Equal('0', result);
        }

        [Theory]
        [InlineData("9999")]
        [InlineData("9876")]
        public void ReturnE(string value)
        {
            var result = RegistrationService.GetDigit(value);
            Assert.Equal('E', result);
        }

        [Fact]
        public void ReturnResultGivenRandomNumber()
        {
            var rnd = new Random();

            var a = rnd.Next(0, 10);
            var b = rnd.Next(0, 10);
            var c = rnd.Next(0, 10);
            var d = rnd.Next(0, 10);

            var modulo = (a * 5 + b * 4 + c * 3 + d * 2) % 16;
            char expected;
            if (modulo > 9)
                expected = (char)('A' + modulo - 10);
            else
                expected = (char)('0' + modulo);

            string registration = 
                a.ToString() + b.ToString() + c.ToString() + d.ToString();
            var result = RegistrationService.GetDigit(registration);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Invalid Format")]
        [InlineData("10000")]
        [InlineData("-1")]
        [InlineData("-001")]
        [InlineData("9ABC")]
        [InlineData("3000000000")]
        public void ThrowsExceptionGivenInvalidFormat(string value)
        {
            Action act = () => RegistrationService.GetDigit(value);
            Assert.Throws<FormatException>(act);
        }

        [Fact]
        public void DigitAlwaysBetween0AndF()
        {
            var rnd = new Random();
            var totalRandomTests = 1000000;
            for (int i = 0; i < totalRandomTests; i++)
            {
                var reg = rnd.Next(0, 10000);
                var regstr = reg.ToString().PadLeft(4, '0');
                var digit = RegistrationService.GetDigit(regstr);
                Assert.True((0 <= digit - '0' && digit - '0' < 10)
                    || (0 <= digit - 'A' && digit - 'A' < 6));
            }
        }
    }
}
