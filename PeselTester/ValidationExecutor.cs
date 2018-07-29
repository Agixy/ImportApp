using PeselTester.Tests;

namespace PeselTester
{
    public class ValidationExecutor
    {
        protected TestTemplate TestsChainFirstElement;
        public ValidationExecutor()
        {
            TestsChainFirstElement = new ValidationChainBuilder()
               .AddOnlyDigitsTest()
               .AddLenghtTest()
               .AddControlNumberTest()
               .Build();
        }

        public PeselValidationResult Validate(string password)
        {
            return TestsChainFirstElement.StartCheckingFlow(password);
        }
    }
}
