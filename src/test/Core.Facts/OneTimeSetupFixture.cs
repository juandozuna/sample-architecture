using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Wepsys.Polux.Sample.Core.Facts
{
    [SetUpFixture]
    [Parallelizable(scope: ParallelScope.All)]
    public class OneTimeSetupFixture
    {
        private static readonly string ProcessesNamesFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "ProcessNames.dat");
        // private static readonly string SecretNamesFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "SecretNames.dat");
        // private static readonly string FlowElementKeysFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "FlowElementKeys.dat");
        // private static readonly string InvalidFlowElementKeysFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "InvalidFlowElementKeys.dat");
        // private static readonly string ValidRestRoutesFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "ValidRestRoutes.dat");
        // private static readonly string HttpHeaderNamesFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "HttpHeaderNames.dat");
        // private static readonly string HttpHeaderValuesFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "HttpHeaderValues.dat");
        public static readonly char[] ControlCharacters = Enumerable.Range(char.MinValue, char.MaxValue).Select(c => (char)c).Where(char.IsControl).ToArray();

        // public static IEnumerable<TestCaseParameters> SecretNamesAsTestData()
        //     => EnumerateTestDataFile(SecretNamesFilePath);
    
        public static IEnumerable<TestCaseParameters> ProcessNamesAsTestData()
            => EnumerateTestDataFile(ProcessesNamesFilePath);

        // public static IEnumerable<TestCaseParameters> FlowElementKeysAsTestData()
        //     => EnumerateTestDataFile(FlowElementKeysFilePath);
        //
        // public static IEnumerable<TestCaseParameters> InvalidFlowElementKeysAsTestData()
        //     => EnumerateTestDataFile(InvalidFlowElementKeysFilePath);
        //
        // public static IEnumerable<TestCaseParameters> ValidRestRoutes()
        //     => EnumerateTestDataFile(ValidRestRoutesFilePath);
        //
        // public static IEnumerable<string> HttpHeaderNames()
        //     => EnumerateTestDataFileRaw(HttpHeaderNamesFilePath);
        //
        // public static IEnumerable<string> HttpHeaderValues()
        //     => EnumerateTestDataFileRaw(HttpHeaderValuesFilePath);

        private static IEnumerable<TestCaseParameters> EnumerateTestDataFile(string fullPath)
            => EnumerateTestDataFileRaw(fullPath).Select(rawValue => new TestCaseData(rawValue));

        private static IEnumerable<string> EnumerateTestDataFileRaw(string fullPath)
        {
            foreach (string rawValue in File.ReadAllLines(fullPath).Where(line => IsValidTestFileLine(line)))
            {
                yield return rawValue;
            }
        }

        private static bool IsValidTestFileLine(in string line)
            => !string.IsNullOrWhiteSpace(line) && !line.StartsWith("#");

        [OneTimeSetUp]
        public void RunBeforeAnyTests() => Assume.That(File.Exists(ProcessesNamesFilePath));

        [OneTimeTearDown]
        public void RunAfterAllTests()
        {
        }
    }
}
