using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeselTester.Tests
{
    public abstract class TestTemplate
    {
        protected TestTemplate NextTest;
        protected abstract PeselValidationResult NotPassResult { get; }

        private const PeselValidationResult SuccessResult = PeselValidationResult.Ok;

        public abstract bool TestCondition(string pesel);

        public void SetNext(TestTemplate test)
        {
            NextTest = test;
        }

        public PeselValidationResult StartCheckingFlow(string password)
        {
            var isPassingTest = TestCondition(password);

            if (isPassingTest && NextTest != null)
                return NextTest.StartCheckingFlow(password);

            if (isPassingTest && NextTest == null)
                return SuccessResult;

            return NotPassResult;
        }

    }
}
