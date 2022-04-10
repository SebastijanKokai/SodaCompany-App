using System;

namespace SodaCompany.Common.Exceptions
{
    public class UnAuthorizedException : Exception
    {
        public UnAuthorizedException(string message) : base(message)
        {
        }
    }
}
