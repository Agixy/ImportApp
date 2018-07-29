using PeselTester.Tests;
using System.Collections.Generic;
using System.Linq;

namespace PeselTester
{
    internal class ValidationChainBuilder
    {
        public List<TestTemplate> Tests;

        internal ValidationChainBuilder()
        {
            Tests = new List<TestTemplate>();
        }

        public ValidationChainBuilder AddOnlyDigitsTest()
        {
            Tests.Add(new OnlyDigitsTest());
            return this;
        }

        public ValidationChainBuilder AddLenghtTest()
        {
            Tests.Add(new LenghtTest());
            return this;
        }

        public ValidationChainBuilder AddControlNumberTest()
        {
            Tests.Add(new ControlNumberTest());
            return this;
        }

        public TestTemplate Build()
        {
            for (int i = 0; i < Tests.Count - 1; i++)
            {
                Tests[i].SetNext(Tests[i + 1]);
            }

            return Tests.First();
        }
    }
}
