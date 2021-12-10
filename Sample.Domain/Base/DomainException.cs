using System;

namespace Sample.Domain.Base
{
    public class DomainException : Exception
    {
        public string Code { get; private set; }
        //TODO: set Code

        public DomainException():base("Default domain exception")
        {
            Code = "RandomCode";
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
    }
}
