using FluentValidation;

namespace Cv.Models
{
    public class CandidateValidations : AbstractValidator<CandidateModel>
    {
        public CandidateValidations()
        {
            RuleFor(x => x.PersonalData).NotNull().WithMessage("Not Null");
            RuleFor(x => x.PersonalData.FullName)
                .NotEmpty().WithMessage("Not Null or Empty")
                .MinimumLength(5).WithMessage("Minimum Length 5")
                .MaximumLength(100).WithMessage("Maximum Length 100");
        }
    }
}
