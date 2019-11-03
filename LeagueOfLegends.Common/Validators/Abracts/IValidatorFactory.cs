using LeagueOfLegends.Common.Enums;

namespace LeagueOfLegends.Common.Validators.Abracts
{
    public interface IValidatorFactory
    {
        InputValidatorBase CreateValidator(ValidatorType validatorType);
    }
}