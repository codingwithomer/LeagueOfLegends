using LeagueOfLegends.Common.Enums;
using LeagueOfLegends.Common.Validators.Abracts;
using System;

namespace LeagueOfLegends.Common.Validators.Concretes
{
    public class ValidatorFactory : IValidatorFactory
    {
        public InputValidatorBase CreateValidator(ValidatorType validatorType)
        {
            InputValidatorBase inputValidatorBase;

            switch (validatorType)
            {
                case ValidatorType.CharacterInputValidator:
                    inputValidatorBase = new CharacterInputValidator();
                    break;
                case ValidatorType.HealthEquipmentValidator:
                    inputValidatorBase = new HealthEquipmentValidator();
                    break;
                default:
                    throw new NotSupportedException("Invalid validator!");
            }

            return inputValidatorBase;
        }
    }
}
