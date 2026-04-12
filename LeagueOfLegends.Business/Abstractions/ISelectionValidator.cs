using System.Collections.Generic;

namespace LeagueOfLegends.Business.Abstractions
{
    /// <summary>
    /// Validates numeric menu selections against an allowed option set.
    /// </summary>
    public interface ISelectionValidator
    {
        /// <summary>
        /// Attempts to parse and validate user input.
        /// </summary>
        /// <param name="input">Raw user input.</param>
        /// <param name="validOptions">Allowed numeric options.</param>
        /// <param name="selection">Parsed selection when valid; otherwise default value.</param>
        /// <returns><see langword="true"/> when input is valid; otherwise <see langword="false"/>.</returns>
        bool TryValidate(string? input, IReadOnlyCollection<int> validOptions, out int selection);
    }
}
