using System;

namespace Sample.Domain.Base
{
    public class DomainException : Exception
    {
        public DomainException(string msg) : base(msg)
        {
        }

        //TODO: add more ctors
    }
}
