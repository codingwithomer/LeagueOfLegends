namespace LeagueOfLegends.Business.Abstractions
{
    /// <summary>
    /// Handles character-selection user interaction.
    /// </summary>
    public interface ICharacterSelectionService
    {
        /// <summary>
        /// Prints available character options.
        /// </summary>
        void DisplayCharacterMenu();

        /// <summary>
        /// Reads character selection input from the user.
        /// </summary>
        /// <returns>Raw input value.</returns>
        string GetCharacterInput();

        /// <summary>
        /// Informs user that the selection is invalid.
        /// </summary>
        void ShowInvalidSelectionMessage();

        /// <summary>
        /// Displays selected character option text.
        /// </summary>
        /// <param name="input">Validated input value.</param>
        void ShowSelection(string input);
    }
}
