using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Repository
{
    /// <summary>
    /// This is the interface for the looks repository.
    /// </summary>
    interface ILooksRepository : IRepository<Looks>
    {
        /// <summary>
        /// Changes the theme of an existing look.
        /// </summary>
        /// <param name="id">Id of a look.</param>
        /// <param name="newTheme">A string representing the new theme.</param>
        void ChangeTheme(int id, string newTheme);

        /// <summary>
        /// Increases or decreases the difficulty of the look.
        /// </summary>
        /// <param name="id">Id of a look.</param>
        /// <param name="newLookDiff">An int representing the new difficulty of the look.</param>
        void ChangeLookDifficulty(int id, int newLookDiff);
    }
}
