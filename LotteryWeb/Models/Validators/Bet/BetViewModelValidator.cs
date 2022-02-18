using FluentValidation;
using LotteryWeb.Models.Entity;
using LotteryWeb.ViewModels.Bet;
using System.Collections.Generic;

namespace LotteryWeb.Models.Validators.Bet
{
    public class BetViewModelValidator : AbstractValidator<BetViewModel>
    {
        private static readonly int minNumber = 1;
        private static readonly int maxNumber = 50;

        private readonly string notNullMessage = "Bu Verinin Girilmesi Mecburidir.";
        private readonly string inclusiveBetweenMessage = $"Lütfen {minNumber} ile {maxNumber} arasında bir değer girin.";

        public BetViewModelValidator()
        {
            var ruleList = new List<IRuleBuilderInitial<BetViewModel, int>>()
            {
                RuleFor(x=>x.Number1),
                RuleFor(x=>x.Number2),
                RuleFor(x=>x.Number3),
                RuleFor(x=>x.Number4),
                RuleFor(x=>x.Number5),
                RuleFor(x=>x.Number6),
            };

            foreach (var rule in ruleList)
            {
                rule
                    .NotNull().WithMessage(notNullMessage)
                    .NotEmpty().WithMessage(notNullMessage)
                    .InclusiveBetween(minNumber, maxNumber).WithMessage(inclusiveBetweenMessage);
            }           
        }
    }
}
