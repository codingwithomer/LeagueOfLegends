using LeagueOfLegends.Common.Validators.Abracts;
using System.Collections.Generic;

namespace LeagueOfLegends.Common.Validators.Concretes
{
    public class HealthEquipmentValidator : InputValidatorBase
    {
        public override bool IsInputValid(string input, ref int healthEquipmentType)
        {
            bool isValid = false;

            if (string.IsNullOrWhiteSpace(input))
                return isValid;

            List<int> validKeys = new List<int> { 1, 2 };

            isValid = int.TryParse(input, out int result);

            if (isValid)
                isValid = validKeys.Contains(result);

            if (isValid == true)
                healthEquipmentType = result;

            return isValid;
        }
    }
}
