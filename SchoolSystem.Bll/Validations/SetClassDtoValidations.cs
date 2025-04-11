using Microsoft.EntityFrameworkCore;
using SchoolSystem.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SchoolSystem.Bll.Validations
{
    public class SetClassDtoValidations : AbstractValidator<SetClassDto>
    {
        public SetClassDtoValidations() 
        {
            RuleFor(x => x.ClassName)
                .NotEmpty().WithMessage("Class name is required.")
                .Length(3, 50).WithMessage("Class name must be between 3 and 50 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(10, 200).WithMessage("Description must be between 10 and 200 characters.");
            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive status is required.");
        }
    }
   
    
}
