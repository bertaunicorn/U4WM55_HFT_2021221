using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Logic
{
    /// <summary>
    /// Updates that jury members/organizers can make.
    /// </summary>
    public interface IJuryLogic
    {
        /// <summary>
        /// Increases or decreases the difficulty of the look.
        /// </summary>
        /// <param name="id">Id of a look.</param>
        /// <param name="newLookDiff">An int representing the new difficulty of the look.</param>
        void ChangeLookDifficulty(int id, int newLookDiff);

        /// <summary>
        /// Changes the theme of an existing look.
        /// </summary>
        /// <param name="id">Id of a look.</param>
        /// <param name="newTheme">A string representing the new theme.</param>
        void ChangeTheme(int id, string newTheme);

        /// <summary>
        /// Changes the difficulty of a competition.
        /// </summary>
        /// <param name="id">Id of a Competition.</param>
        /// <param name="newDifficulty">An int representing the new difficulty level.</param>
        void ChangeCompDifficulty(int id, int newDifficulty);

        /// <summary>
        /// Removing a MUA from the competition list.
        /// </summary>
        /// <param name="id">We'd like to get the id of the MUA we need to delete as an integer.</param>
        public void DeleteMUA(int id);

        /// <summary>
        /// Creating a new competition.
        /// </summary>
        /// <param name="place">A string telling us where the competition takes place.</param>
        /// <param name="difficulty">An integer which shows how difficult the competition is.</param>
        /// <param name="compDate">A DateTime parameter to show when they hold the competition.</param>
        /// <param name="howManyJudges">In integer telling us how many judges will jude at this competition.</param>
        /// <param name="headOfJury">A string representing the main Judge.</param>
        public void CreateComp(string place, int difficulty, DateTime compDate, int howManyJudges, string headOfJury);

        /// <summary>
        /// Deleting an existing competition.
        /// </summary>
        /// <param name="id">An int representing the ID of the competition we want to delete.</param>
        public void DeleteComp(int id);

        /// <summary>
        /// Creating a new makeup look.
        /// </summary>
        /// <param name="theme">A string saying the theme of the competition.</param>
        /// <param name="brand">A string telling us the brand of makeup with which the muas have to make the look.</param>
        /// <param name="budget">An int representing the amunt of money a mua can spend on the look.</param>
        /// <param name="timeframe">An int saying how much time the mua has for the look.</param>
        /// <param name="difficulty">An integer telling us how difficult it is to create this look.</param>
        /// <param name="compId">This int is a foreign key telling us the competition in which this look will be created.</param>
        public void CreateLook(string theme, string brand, int budget, int timeframe, int difficulty, int compId);

        /// <summary>
        /// Deleting an existing makeup look.
        /// </summary>
        /// <param name="id">An int representing the ID of the makeup look we want to delete.</param>
        public void DeleteLook(int id);

        /// <summary>
        /// This is a non-CRUD linq query which shows if there is a brand that is used for a look and also sponsors a MUA.
        /// </summary>
        /// <returns>This returns an IList type variable.</returns>
        IList<SponsorBrandsResult> SponsorBrands();

        /// <summary>
        /// How many looks are there at comps.
        /// </summary>
        /// <returns>This returns an IList type variable.</returns>
        IList<HowManyLooksResult> HowManyLooks();

        ///// <summary>
        ///// The async version of my SponsorBrands() method.
        ///// </summary>
        ///// <returns>Returns a Taks.</returns>
        //public Task<IList<SponsorBrandsResult>> SponsorBrandsAsync();

        ///// <summary>
        ///// The async version of my HowManyLooks() method.
        ///// </summary>
        ///// <returns>Returns a Taks.</returns>
        //public Task<IList<HowManyLooksResult>> HowManyLooksAsync();
    }
}
