using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Logic
{
    /// <summary>
    /// Methods regarding participants of the comopetitions.
    /// </summary>
    public interface IParticipantLogic
    {
        /// <summary>
        /// Upgrades a MUA's experience level if they get better.
        /// </summary>
        /// <param name="id">Id of a MUA.</param>
        /// <param name="newExperienceLvl">An int representing the new experience level of the MUA.</param>
        public void UpgradeMUA(int id, int newExperienceLvl);

        /// <summary>
        /// Changes the number of models a MUA has. They might loose or gain 1 or 2.
        /// </summary>
        /// <param name="id">Id of a MUA.</param>
        /// <param name="newModels">An int representing the ugraded number of models a MUA has.</param>
        public void ChangeNumOfModels(int id, int newModels);

        /// <summary>
        /// Creates a new MUA after the existing ones.
        /// </summary>
        /// <param name="name">We need a string type parameter.</param>
        /// <param name="gender">We need a string type parameter which is actually 1 character.</param>
        /// <param name="country">A string type parameter.</param>
        /// <param name="experienceLvl">We need an integer type parameter.</param>
        /// <param name="phone">An long type parameter.</param>
        /// <param name="email">We hope to get a string type parameter.</param>
        /// <param name="sponsor">We are hoping for a string type parameter.</param>
        /// <param name="numOfModels">An integer type parameter is what we long for.</param>
        /// <param name="points">An integer type parameter please.</param>
        public void CreateMUA(string name, string gender, string country, int experienceLvl, long phone, string email, string sponsor, int numOfModels, double points);

        /// <summary>
        /// Deleting an existing connection.
        /// </summary>
        /// <param name="id">An int representing the ID of the connenction we want to delete.</param>
        public void DeleteConnection(int id);

        /// <summary>
        /// Creating a new connection between a mua and a competition.
        /// </summary>
        /// <param name="compId">An integer representing the ID of the competition.</param>
        /// <param name="muaId">An integer representing the ID of the makeup artist.</param>
        public void CreateConnection(int compId, int muaId);

        /// <summary>
        /// This is a non-CRUD linq query which shows how many of each gender option there were at the competitions.
        /// </summary>
        /// <returns>Returns an IList.</returns>
        IQueryable<GendersResult> Genders();

        /// <summary>
        /// This is a non-CRUD linq query which shows if there is a MUA from the country of the current competition.
        /// </summary>
        /// <returns>Returns an IList.</returns>
        IQueryable<SameCountryResult> SameCountry();

        ///// <summary>
        ///// The async version of my Genders() method.
        ///// </summary>
        ///// <returns>Returns a Taks.</returns>
        //public Task<IList<GendersResult>> GendersAsync();

        ///// <summary>
        ///// The async version of my SameCountry() method.
        ///// </summary>
        ///// <returns>Returns a Taks.</returns>
        //public Task<IList<SameCountryResult>> SameCountryAsync();
    }
}
