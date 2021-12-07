using System;
using System.Collections.Generic;
using System.Linq;
using U4WM55_HFT_2021221.Repository;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Logic
{
    /// <summary>
    /// Updates that jury members/organizers can make.
    /// </summary>
    public class JuryLogic : IJuryLogic
    {
        private ILooksRepository lookRepo;
        private ICompetitionsRepository compRepo;
        private IMUAsRepository muaRepo;
        private IConnectorRepository connRepo;
        /// <summary>
        /// Initializes a new instance of the <see cref="JuryLogic"/> class.
        /// </summary>
        /// <param name="lookRepo">We need an ILookRepository type parameter.</param>
        /// <param name="compRepo">We need an ICompetitionsRepository type parameter.</param>
        /// <param name="muaRepo">We need an IMUARepository type parameter.</param>
        /// <param name="connRepo">We need an IConnectorRepository type parameter.</param>
        public JuryLogic(ILooksRepository lookRepo, ICompetitionsRepository compRepo, IMUAsRepository muaRepo, IConnectorRepository connRepo)
        {
            this.lookRepo = lookRepo;
            this.compRepo = compRepo;
            this.muaRepo = muaRepo;
            this.connRepo = connRepo;
        }

        /// <summary>
        /// Increases or decreases the difficulty of the look.
        /// </summary>
        /// <param name="id">We need a look id.</param>
        /// <param name="newLookDiff">An int representing the new difficulty of the look.</param>
        public void ChangeLookDifficulty(int id, int newLookDiff)
        {
            this.lookRepo.ChangeLookDifficulty(id, newLookDiff);
        }

        /// <summary>
        /// Changes the theme of an existing look.
        /// </summary>
        /// <param name="id">We need a look id.</param>
        /// <param name="newTheme">A string representing the new theme.</param>
        public void ChangeTheme(int id, string newTheme)
        {
            this.lookRepo.ChangeTheme(id, newTheme);
        }

        /// <summary>
        /// Changes the difficulty of a competition.
        /// </summary>
        /// <param name="id">Id of a Competition.</param>
        /// <param name="newDifficulty">An int representing the new difficulty level.</param>
        public void ChangeCompDifficulty(int id, int newDifficulty)
        {
            this.compRepo.ChangeCompDifficulty(id, newDifficulty);
        }

        /// <summary>
        /// Removing a MUA from the competition list.
        /// </summary>
        /// <param name="id">We'd like to get the id of the MUA we need to delete as an integer.</param>
        public void DeleteMUA(int id)
        {
            MUAs muaToDelete = this.muaRepo.GetOne(id);

            if (muaToDelete == null)
            {
                throw new InvalidOperationException("MUA not found!");
            }
            else
            {
                this.muaRepo.Remove(id);
            }
        }

        /// <summary>
        /// Creating a new competition.
        /// </summary>
        /// <param name="place">A string telling us where the competition takes place.</param>
        /// <param name="difficulty">An integer which shows how difficult the competition is.</param>
        /// <param name="compDate">A DateTime parameter to show when they hold the competition.</param>
        /// <param name="howManyJudges">In integer telling us how many judges will jude at this competition.</param>
        /// <param name="headOfJury">A string representing the main Judge.</param>
        public void CreateComp(string place, int difficulty, DateTime compDate, int howManyJudges, string headOfJury)
        {
            Competitions newComp = new Competitions()
            {
                Place = place,
                Difficulty = difficulty,
                CompDate = compDate,
                HowManyJudges = howManyJudges,
                HeadOfJury = headOfJury,
            };

            IQueryable<Competitions> compList = this.compRepo.GetAll();

            bool exists = false;
            foreach (Competitions item in compList)
            {
                if (item.Equals(newComp))
                {
                    exists = true;
                }
            }

            if (exists == false)
            {
                this.compRepo.Insert(newComp);
            }
            else
            {
                throw new InvalidOperationException("This Competition alreday exists!");
            }
        }

        /// <summary>
        /// Deleting an existing competition.
        /// </summary>
        /// <param name="id">An int representing the ID of the competition we want to delete.</param>
        public void DeleteComp(int id)
        {
            Competitions compToDelete = this.compRepo.GetOne(id);

            if (compToDelete == null)
            {
                throw new InvalidOperationException("Competition not found!");
            }
            else
            {
                this.compRepo.Remove(id);
            }
        }

        /// <summary>
        /// Creating a new makeup look.
        /// </summary>
        /// <param name="theme">A string saying the theme of the competition.</param>
        /// <param name="brand">A string telling us the brand of makeup with which the muas have to make the look.</param>
        /// <param name="budget">An int representing the amunt of money a mua can spend on the look.</param>
        /// <param name="timeframe">An int saying how much time the mua has for the look.</param>
        /// <param name="difficulty">An integer telling us how difficult it is to create this look.</param>
        /// <param name="compId">This int is a foreign key telling us the competition in which this look will be created.</param>
        public void CreateLook(string theme, string brand, int budget, int timeframe, int difficulty, int compId)
        {
            Looks newLook = new Looks()
            {
                Theme = theme,
                Brand = brand,
                Budget = budget,
                TimeFrame = timeframe,
                Difficulty = difficulty,
                CompId = compId,
            };

            IQueryable<Looks> lookList = this.lookRepo.GetAll();

            bool exists = false;
            foreach (Looks item in lookList)
            {
                if (item.Equals(newLook))
                {
                    exists = true;
                }
            }

            if (exists == false)
            {
                this.lookRepo.Insert(newLook);
            }
            else
            {
                throw new InvalidOperationException("This Look already exists!");
            }
        }

        /// <summary>
        /// Deleting an existing makeup look.
        /// </summary>
        /// <param name="id">An int representing the ID of the makeup look we want to delete.</param>
        public void DeleteLook(int id)
        {
            Looks lookToDelete = this.lookRepo.GetOne(id);

            if (lookToDelete == null)
            {
                throw new InvalidOperationException("Look not found!");
            }
            else
            {
                this.lookRepo.Remove(id);
            }
        }

        /// <summary>
        /// This is a non-CRUD linq query which shows if there is a brand that is used for a look and also sponsors a MUA.
        /// </summary>
        /// <returns>This returns an IList type variable.</returns>
        public IList<SponsorBrandsResult> SponsorBrands()
        {
            //var muas = this.muaRepo.GetAll().ToList();
            //var result = this.lookRepo.GetAll()
            //    .Where(look => look.Brand == muas.)

            IList<MUAs> muaList = this.muaRepo.GetAll().ToList();
            IList<Looks> lookList = this.lookRepo.GetAll().ToList();

            var sponBrand = from muas in muaList
                            from looks in lookList
                            where looks.Brand == muas.Sponsor
                            select new SponsorBrandsResult()
                            {
                                MUAId = muas.Id,
                                MUAName = muas.Name,
                                MUASpon = muas.Sponsor,
                                LookBrand = looks.Brand,
                                LookID = looks.Id,
                            };

            return sponBrand.ToList();

            
        }

        /// <summary>
        /// How many looks are there at comps.
        /// </summary>
        /// <returns>This returns an IList type variable.</returns>
        public IQueryable<HowManyLooksResult> HowManyLooks()
        {
            var group = this.lookRepo.GetAll()
                .Where(look => look.CompId == look.Competition.Id)
                .GroupBy(look => new
                {
                    CompId = look.CompId
                })
                .Select(grp => new HowManyLooksResult
                {
                    CompetitionID = (int)grp.Key.CompId,
                    NumberOfLooks = grp.Count(),
                }); //.ToList();

            return group;

            //IList<Competitions> compList = this.compRepo.GetAll().ToList();
            //IList<Looks> lookList = this.lookRepo.GetAll().ToList();

            //var looksAtComp = from looks in lookList
            //                  join comp in compList
            //                  on looks.CompId.Value equals comp.Id
            //                  group looks by looks.CompId.Value into grp
            //                  let count = grp.Count()
            //                  select new HowManyLooksResult()
            //                  {
            //                      CompetitionID = grp.Key,
            //                      NumberOfLooks = count,
            //                  };

            //return looksAtComp.ToList();
        }

        ///// <summary>
        ///// The async version of my SponsorBrands() method.
        ///// </summary>
        ///// <returns>Returns a Taks.</returns>
        //public Task<IList<SponsorBrandsResult>> SponsorBrandsAsync()
        //{
        //    return Task.Run(this.SponsorBrands);
        //}

        ///// <summary>
        ///// The async version of my HowManyLooks() method.
        ///// </summary>
        ///// <returns>Returns a Taks.</returns>
        //public Task<IList<HowManyLooksResult>> HowManyLooksAsync()
        //{
        //    return Task.Run(this.HowManyLooks);
        //}
    }
}
