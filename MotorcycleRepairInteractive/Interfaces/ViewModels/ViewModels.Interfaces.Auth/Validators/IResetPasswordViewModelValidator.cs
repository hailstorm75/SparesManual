using FluentValidation;
using ViewModels.Interfaces.Auth.ViewModels;

namespace ViewModels.Interfaces.Auth.Validators
{
  public interface IResetPasswordViewModelValidator
    : IValidator<IResetPasswordViewModel>
  {
  }
}