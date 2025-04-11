using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SchoolSystem.Bll.Dtos;

namespace SchoolSystem.Bll.Validations
{
   public class SetStudentDtoValidation : AbstractValidator<SetStudentDto>
    {
        public SetStudentDtoValidation()
        {
            RuleFor(student => student.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(student => student.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(student => student.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");

            RuleFor(student => student.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .Must(gender => gender == "Male" || gender == "Female" || gender == "Other")
                .WithMessage("Gender must be 'Male', 'Female', or 'Other'.");

            RuleFor(student => student.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
