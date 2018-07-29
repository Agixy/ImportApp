using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeselTester
{
    public enum PeselValidationResult
    {
        Ok,
        WrongLenght,
        NotOnlyDigits,
        WrongControlSum
    }
}
