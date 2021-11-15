using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Repository
{
    /// <summary>
    /// This is the interface for the competitions repository.
    /// </summary>
    public interface ICompetitionsRepository : IRepository<Competitions>
    {
        /// <summary>
        /// Changes the difficulty of a competition.
        /// </summary>
        /// <param name="id">Id of a Competition.</param>
        /// <param name="newDifficulty">An int representing the new difficulty level.</param>
        void ChangeCompDifficulty(int id, int newDifficulty);

        /// <summary>
        /// Changes the place of the competition.
        /// </summary>
        /// <param name="id">Id of a Competition.</param>
        /// <param name="newPlace">A string representing the new place.</param>
        void ChangePlace(int id, string newPlace);
    }
}
