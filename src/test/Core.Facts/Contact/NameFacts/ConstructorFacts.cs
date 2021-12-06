using NUnit.Framework;
using System;
using Wepsys.Polux.Sample.Core.Contact;

namespace Wepsys.Polux.Sample.Core.Facts.Contact.NameFacts
{
    [TestFixture]
    internal sealed class ConstructorFacts
    {
        [TestCaseSource(typeof(OneTimeSetupFixture), nameof(OneTimeSetupFixture.ProcessNamesAsTestData))]
        public void With_Valid_Names_Throws_Nothing(string rawName)
         => Assert.That(() => new Name(rawName), Throws.Nothing);
        

        [Test]
        public void With_Null_Throws_ArgumentNullException()
            => Assert.That(() => new Name(null), Throws.ArgumentNullException);

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        public void With_Empty_Throws_ArgumentOutOfRangeException(string rawName)
            => Assert.That(() => new Name(rawName), Throws.InstanceOf<ArgumentOutOfRangeException>());

        [TestCase("     ")]
        [TestCase("          ")]
        public void With_Empty_And_Larger_Than_Minimum_Throws_FormatException(string rawName)
            => Assert.That(() => new Name(rawName), Throws.InstanceOf<FormatException>());

        // [Test]
        // public void With_Invalid_Chars_Throws_FormatException([Values('@', ',', ':', ';', '_', '*', '+', '.')] char invalidChar)
        //     => Assert.That(() => new Name($"sample{invalidChar}name"), Throws.InstanceOf<FormatException>());

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(150)]
        [TestCase(250)]
        public void With_Names_Length_Outside_Boundaries_Throws_ArgumentOutOfRangeException(int length)
        {
            string rawName = new('a', length);
            Assert.That(() => new Name(rawName), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [TestCase(" Hello World")]
        [TestCase("Hello World ")]
        [TestCase(" Hello World ")]
        public void With_Leading_Or_Trailing_White_Spaces_Throws_FormatException(string rawName)
            => Assert.That(() => new Name(rawName), Throws.InstanceOf<FormatException>());
    }
}