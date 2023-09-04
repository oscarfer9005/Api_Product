using FluentValidation;
using Infraestructure.Dto;

namespace ProductManagement.Api.Utility
{
    public class Validations : AbstractValidator<ProductDto>
    {
        public Validations()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Stock).NotEmpty();
        }
    }
}
