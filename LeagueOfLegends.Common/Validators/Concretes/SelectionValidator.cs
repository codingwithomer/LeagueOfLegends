using LeagueOfLegends.Business.Abstractions;

namespace LeagueOfLegends.Common.Validators.Concretes
{
    /// <summary>
    /// Validates menu selections by parsing input and checking allowed values.
    /// </summary>
    public class SelectionValidator : ISelectionValidator
    {
        /// <summary>
        /// Attempts to parse and validate a selection input.
        /// </summary>
        /// <param name="input">Raw user input.</param>
        /// <param name="validOptions">Allowed numeric options.</param>
        /// <param name="selection">Parsed value when valid, otherwise default.</param>
        /// <returns><see langword="true"/> if input is valid; otherwise <see langword="false"/>.</returns>
        public bool TryValidate(string? input, IReadOnlyCollection<int> validOptions, out int selection)
        {
            selection = default;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            if (!int.TryParse(input, out int parsed))
            {
                return false;
            }

            if (!validOptions.Contains(parsed))
            {
                return false;
            }

            selection = parsed;
            return true;
        }
    }
}
