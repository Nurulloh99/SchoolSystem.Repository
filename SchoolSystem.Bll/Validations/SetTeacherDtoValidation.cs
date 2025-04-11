using FluentValidation;
using SchoolSystem.Bll.Dtos;

namespace SchoolSystem.Bll.Validations;

public class SetTeacherDtoValidation : AbstractValidator<SetTeacherDto>
{
    public SetTeacherDtoValidation()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");

        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Gender is required.")
            .Must(g => g == "Male" || g == "Female" || g == "Other")
            .WithMessage("Gender must be 'Male', 'Female', or 'Other'.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number is not valid.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");

        RuleFor(x => x.SubjectSpecialization)
            .NotEmpty().WithMessage("Subject specialization is required.")
            .MaximumLength(100).WithMessage("Subject specialization cannot exceed 100 characters.");
    }
}