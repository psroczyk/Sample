using System.ComponentModel.DataAnnotations;

namespace Sample.Api.Requests
{
    public class AddProductRequest
    {
        public AddProductRequest(string name)
        {
            Name = name;
        }

        [Required]//For fast validation purposes, we can use for example FluentValidation in MediatR pipeline for business validation
        public string Name { get; }
    }
}
