using FluentValidation;
using Hahn.ApplicatonProcess.May2020.Domain.Models;

namespace Hahn.ApplicatonProcess.May2020.Web.Validators
{
    public class ApplicantValidator : AbstractValidator<Applicant>
    {
        public ApplicantValidator()
        {
            this.CascadeMode = CascadeMode.Continue;
            RuleFor(a => a.Name).NotEmpty().MinimumLength(5);
            RuleFor(a => a.FamilyName).NotEmpty().MinimumLength(5);
            RuleFor(a => a.Address).NotEmpty().MinimumLength(10);
            RuleFor(a => a.Age).GreaterThan(19).LessThan(61);
            RuleFor(a => a.EmailAddress).NotEmpty().EmailAddress();
        }
    }
}
