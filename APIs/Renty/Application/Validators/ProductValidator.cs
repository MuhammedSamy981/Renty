using FluentValidation;
using Renty.Domain.Entities;

namespace Renty.Application.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters");

            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Category is required");

/*            RuleFor(p => p.CountryId).NotEmpty().WithMessage("Country is required");

            RuleFor(p => p.CityId).NotEmpty().WithMessage("City is required");

            RuleFor(p => p.AreaId).NotEmpty().WithMessage("Area is required");*/

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Price is required")
                .GreaterThan(0).WithMessage("Price must be greater than 0");

          RuleFor(p => p.Description).NotEmpty().WithMessage("Description is required");
          
        }
    }


}
