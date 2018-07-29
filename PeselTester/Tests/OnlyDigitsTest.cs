using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PeselTester.Tests
{
    class OnlyDigitsTest : TestTemplate
    {
        protected override PeselValidationResult NotPassResult => PeselValidationResult.NotOnlyDigits;

        public override bool TestCondition(string pesel)
        {
            var regex = new Regex(@"^[0-9]*$");
            Match match = regex.Match(pesel);
            return match.Success;
        }
    }
}
