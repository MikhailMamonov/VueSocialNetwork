
using FluentValidation;

namespace VueJSSocialNetwork.Web.ViewModels.Validations
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(vm => vm.Email).NotEmpty().WithMessage("Email cannot be empty");

            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(vm => vm.Password).Length(6, 12).WithMessage("Password must be between 6 and 12 characters");

            RuleFor(vm => vm.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword cannot be empty");
            RuleFor(vm => vm.ConfirmPassword).Length(6, 12).WithMessage("ConfirmPassword must be between 6 and 12 characters");

            RuleFor(vm => vm.FirstName).NotEmpty().WithMessage("FirstName cannot be empty");
            RuleFor(vm => vm.FirstName).Length(2, 50).WithMessage("FirstName must be between 2 and 50 characters");

            RuleFor(vm => vm.LastName).NotEmpty().WithMessage("LastName cannot be empty");
            RuleFor(vm => vm.LastName).Length(2, 50).WithMessage("LastName must be between 2 and 50 characters");

            RuleFor(vm => vm.Username).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(vm => vm.Username).Length(2, 50).WithMessage("Username must be between 2 and 50 characters");

            RuleFor(vm => vm.Photo).NotEmpty().WithMessage("Photo cannot be empty");

            RuleFor(vm => vm.Age).NotEmpty().WithMessage("Age cannot be empty");
        }
    }
}