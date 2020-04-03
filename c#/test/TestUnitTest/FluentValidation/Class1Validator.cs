using FluentValidation;

namespace FluentValidation
{
    public class Class1Validator : AbstractValidator<Class1>
    {
        public Class1Validator()
        {
            RuleFor(c => c.PString1).NotNull().Length(0, 10);
            RuleFor(c => c.PString2).NotNull().Length(0, 10);
            RuleFor(c => c.PString3).NotNull().Length(0, 10);
            RuleFor(c => c.PString4).Length(0, 10);
        }
    }
}
