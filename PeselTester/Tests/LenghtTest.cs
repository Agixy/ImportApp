using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeselTester.Tests
{
    class LenghtTest : TestTemplate
    {
        private const int PeselLenght = 11;

        protected override PeselValidationResult NotPassResult => PeselValidationResult.WrongLenght;
        

        public override bool TestCondition(string pesel)
        {
            return pesel.Length == PeselLenght;
        }
    }
}
