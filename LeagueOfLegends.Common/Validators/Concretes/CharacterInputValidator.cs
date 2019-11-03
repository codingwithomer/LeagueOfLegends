using LeagueOfLegends.Character.Models;
using LeagueOfLegends.Common.Validators.Abracts;
using System.Collections.Generic;

namespace LeagueOfLegends.Common.Validators.Concretes
{
    public class CharacterInputValidator : InputValidatorBase, ICharacterValidator
    {
        public override bool IsInputValid(string input, ref int characterType)
        {
            bool isValid = false;

            if (string.IsNullOrWhiteSpace(input))
                return isValid;

            List<int> validKeys = new List<int> { 1, 2, 3, 4 };

            isValid = int.TryParse(input, out int result);

            if (isValid)
                isValid = validKeys.Contains(result);

            if (isValid == true)
                characterType = result;

            return isValid;
        }

        public bool CharacterIsNull(CharacterBase character)
        {
            if (character == null)
                return false;

            return true;
        }
    }
}
