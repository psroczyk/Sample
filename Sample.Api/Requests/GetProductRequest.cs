using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.Api.Requests
{
    public class GetProductRequest
    {
        public GetProductRequest(Guid id)
        {
            Id = id;
        }

        //For fast validation purposes, we can use for example FluentValidation in MediatR pipeline for business validation
        [Required]
        public Guid? Id { get; }
    }
}
