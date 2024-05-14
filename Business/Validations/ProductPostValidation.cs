using FluentValidation;
using Models.ModelsDTO.DTOPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class ProductPostValidation : AbstractValidator<ProductPostDTO>
    {
        public ProductPostValidation()
        {
            RuleFor(p => p.name)
                .NotEmpty()
                .WithMessage("Name empty");

            RuleFor(p => p.stock)
                .NotEmpty()
                .WithMessage("Stock Error"); 
        }
    }
}
