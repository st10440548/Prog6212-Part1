using FluentValidation;
using CMS.Models;
using Microsoft.Extensions.Configuration;

namespace CMS.Validators
{
    public class ClaimValidator : AbstractValidator<Claim>
    {
        public ClaimValidator(IConfiguration config)
        {
            RuleFor(c => c.HoursWorked)
                .GreaterThan(0)
                .WithMessage("Hours must be greater than 0")
                .LessThanOrEqualTo(config.GetValue<decimal>("ClaimPolicy:MaxHoursPerClaim"))
                .WithMessage($"Hours must be <= policy limit");

            RuleFor(c => c.HourlyRate)
                .GreaterThan(0)
                .WithMessage("Rate must be greater than 0")
                .LessThanOrEqualTo(config.GetValue<decimal>("ClaimPolicy:MaxHourlyRate"))
                .WithMessage($"Hourly rate must be <= policy limit");
        }
    }
}
