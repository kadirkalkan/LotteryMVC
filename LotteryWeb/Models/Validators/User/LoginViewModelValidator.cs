﻿using FluentValidation;
using LotteryWeb.ViewModels.User;

namespace LotteryWeb.Models.Validators.ViewModel
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        private static readonly int maxLength = 50;

        private readonly string notNullMessage = "Bu Verinin Girilmesi Mecburidir.";
        private readonly string maxLengthMessage = $"Bu alana maksimum {maxLength} karakter girebilirsiniz.";

        public LoginViewModelValidator()
        {
            RuleFor(x => x.Username)
                .NotNull().WithMessage(notNullMessage)
                .NotEmpty().WithMessage(notNullMessage)
                .MaximumLength(maxLength).WithMessage(maxLengthMessage);

            RuleFor(x => x.Password)
                .NotNull().WithMessage(notNullMessage)
                .NotEmpty().WithMessage(notNullMessage)
                .MaximumLength(maxLength).WithMessage(maxLengthMessage);

        }
    }
}
