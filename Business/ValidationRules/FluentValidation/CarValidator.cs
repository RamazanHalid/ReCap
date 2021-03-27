using Entities.Concrete;
using FluentValidation;
namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p=>p.CarName).MinimumLength(2);
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
           // RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.ColorId == 1);
            RuleFor(p => p.CarName).Must(StartWithA);
            //.WithMassage ile mesaj eklenebilir.
        }
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A"); 
        }
    }
}