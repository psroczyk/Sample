﻿using Sample.Domain.Base;

namespace Sample.Domain.Product.Exceptions
{
    public class RequiredFieldNotProvidedException : DomainException
    {
        public RequiredFieldNotProvidedException(string msg) : base(msg)
        {
        }
    }
}
