using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Repository
{
    /// <summary>
    /// This is the interface for the muas repository.
    /// </summary>
    public interface IMUAsRepository : IRepository<MUAs>
    {
        /// <summary>
        /// Upgrades a MUA's experience level if they get better.
        /// </summary>
        /// <param name="id">Id of a MUA.</param>
        /// <param name="newExperienceLvl">An int representing the new experience level of the MUA.</param>
        void UpgradeMUA(int id, int newExperienceLvl);

        /// <summary>
        /// Changes the number of models a MUA has. They might loose or gain 1 or 2.
        /// </summary>
        /// <param name="id">Id of a MUA.</param>
        /// <param name="newModels">An int representing the ugraded number of models a MUA has.</param>
        void ChangeNumOfModels(int id, int newModels);
    }
}
