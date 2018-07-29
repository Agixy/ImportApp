using System;

namespace ImportApp
{
    class PeselInputException : Exception
    {
        public PeselInputException(string message)
            :base(message)
        { 
        }
    }
}