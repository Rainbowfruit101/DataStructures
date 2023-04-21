using System.Collections;
using NUnit.Framework;

namespace Tests;

public abstract class CasesBase
{
    public class MyTestCase
    {
        public string Name { get; set; }
        public object Actual { get; set; }
        public object Expected { get; set; }
        public object[] Other { get; set; }
    }
    
    protected static IEnumerable Convert(params MyTestCase[] cases) => cases.Select(testCase =>
    {
        var args = new[] { testCase.Actual, testCase.Expected }.AsEnumerable();
        if (testCase.Other != null)
        {
            args = args.Concat(testCase.Other);
        }

        return new TestCaseData(args.ToArray()).SetName(testCase.Name);
    });
}