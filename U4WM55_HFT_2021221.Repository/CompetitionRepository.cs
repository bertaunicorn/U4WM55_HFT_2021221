using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Repository
{
    /// <summary>
    /// This is the CompetitionRepository class.
    /// </summary>
    public class CompetitionRepository : Repository<Competitions>, ICompetitionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompetitionRepository"/> class.
        /// </summary>
        /// <param name="context">We need a DbContext type parameter.</param>
        public CompetitionRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Changes the difficulty of the given competition.
        /// </summary>
        /// <param name="id">Gets a Competition as a parameter.</param>
        /// <param name="newDifficulty">An int representing the new difficulty.</param>
        public void ChangeCompDifficulty(int id, int newDifficulty)
        {
            var competition = this.GetOne(id);
            if (competition == null)
            {
                throw new InvalidOperationException("Competition not found!");
            }

            competition.Difficulty = newDifficulty;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Changes the place of the competition.
        /// </summary>
        /// <param name="id">Id of a Competition.</param>
        /// <param name="newPlace">A string representing the new place.</param>
        public void ChangePlace(int id, string newPlace)
        {
            var competition = this.GetOne(id);
            if (competition == null)
            {
                throw new InvalidOperationException("Competition not found!");
            }

            competition.Place = newPlace;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Finds one specific competition based on the id.
        /// </summary>
        /// <param name="id">Id of a comeptition.</param>
        /// <returns>It returns a Competitions object.</returns>
        public override Competitions GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Adds a new Competition.
        /// </summary>
        /// <param name="entity">A Competitions object.</param>
        public override void Insert(Competitions entity)
        {
            this.Context.Set<Competitions>().Add(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Deletes an existing competition.
        /// </summary>
        /// <param name="id">An integer representing the ID of a competition.</param>
        public override void Remove(int id)
        {
            Competitions obj = this.GetOne(id);
            this.Context.Set<Competitions>().Remove(obj);
            this.Context.SaveChanges();
        }
    }
}
