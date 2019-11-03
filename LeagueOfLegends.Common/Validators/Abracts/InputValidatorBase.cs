namespace LeagueOfLegends.Common.Validators.Abracts
{
    public abstract class InputValidatorBase
    {
        public abstract bool IsInputValid(string input, ref int characterType);
    }
}
