using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeselTester.Tests
{
    class ControlNumberTest : TestTemplate
    {
        private readonly int[] factors = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };

        protected override PeselValidationResult NotPassResult => PeselValidationResult.WrongControlSum;

        public override bool TestCondition(string pesel)
        {
            var sum = CountFactorizedSum(pesel);
            var isControlSumValid = sum % 10 == 0;

            return isControlSumValid;
        }

        private int CountFactorizedSum(string pesel)
        {
            var sum = 0;
            for (int i = 0; i < 11; i++)
            {
                sum += factors[i] * Convert.ToInt32(pesel[i]);
            }
            return sum;
        }
    }
}
