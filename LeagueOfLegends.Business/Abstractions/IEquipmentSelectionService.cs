namespace LeagueOfLegends.Business.Abstractions
{
    /// <summary>
    /// Handles equipment selection user interaction.
    /// </summary>
    public interface IEquipmentSelectionService
    {
        /// <summary>
        /// Prints health equipment options.
        /// </summary>
        void DisplayHealthEquipmentMenu();

        /// <summary>
        /// Reads health equipment selection input.
        /// </summary>
        /// <returns>Raw input value.</returns>
        string GetHealthEquipmentInput();

        /// <summary>
        /// Prints attack equipment options.
        /// </summary>
        void DisplayAttackEquipmentMenu();

        /// <summary>
        /// Reads attack equipment selection input.
        /// </summary>
        /// <returns>Raw input value.</returns>
        string GetAttackEquipmentInput();
    }
}
