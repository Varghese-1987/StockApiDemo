using StockApi.DataAccess.ViewModels;

using FluentValidation;

namespace StockApi.DataAccess.Validators
{
    public class StockVMValidator:AbstractValidator<StockVM>
    {
        public StockVMValidator()
        {
            RuleFor(x => x.Company).NotEmpty();
            RuleFor(x => x.Symbol).NotEmpty();
        }
    }
}
