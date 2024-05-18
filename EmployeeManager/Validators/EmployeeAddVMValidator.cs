using EmployeeManager.Web.ViewModals;
using FluentValidation;

namespace EmployeeManager.Web.Validators
{
    public class EmployeeAddVMValidator : AbstractValidator<EmployeeAddVM>
    {

        public EmployeeAddVMValidator() {
            RuleFor(x => x.FirstName)
                    .NotNull().WithMessage("First name is required")
                    .NotEmpty().WithMessage("First name is required")
                    .MinimumLength(3).WithMessage("First name should contain at least 3 characters")
                    .MaximumLength(20).WithMessage("First name should containt maximum 20 characters");
            RuleFor(x => x.LastName)
                    .NotNull().WithMessage("Last name is required")
                    .NotEmpty().WithMessage("Last name is required")
                    .MinimumLength(3).WithMessage("Last name should contain at least 3 characters")
                    .MaximumLength(20).WithMessage("Last name should containt maximum 20 characters");
        }


    }
}
