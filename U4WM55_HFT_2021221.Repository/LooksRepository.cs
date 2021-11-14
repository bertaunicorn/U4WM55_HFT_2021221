using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Repository
{
    /// <summary>
    /// This is the LooksRepository class.
    /// </summary>
    public class LooksRepository : Repository<Looks>, ILooksRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LooksRepository"/> class.
        /// </summary>
        /// <param name="context">We need a DbContext type parameter.</param>
        public LooksRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Increases or decreases the difficulty of the look.
        /// </summary>
        /// <param name="id">Id of a look.</param>
        /// <param name="newLookDiff">An int representing the new difficulty of the look.</param>
        public void ChangeLookDifficulty(int id, int newLookDiff)
        {
            var look = this.GetOne(id);
            if (look == null)
            {
                throw new InvalidOperationException("Look not found!");
            }

            look.Difficulty = newLookDiff;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Changes the theme of an existing look.
        /// </summary>
        /// <param name="id">Id of a look.</param>
        /// <param name="newTheme">A string representing the new theme.</param>
        public void ChangeTheme(int id, string newTheme)
        {
            var look = this.GetOne(id);
            if (look == null)
            {
                throw new InvalidOperationException("Look not found!");
            }

            look.Theme = newTheme;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Finds one specific look based on the id.
        /// </summary>
        /// <param name="id">Id of a look.</param>
        /// <returns>It returns a Looks object.</returns>
        public override Looks GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Adds a new Look.
        /// </summary>
        /// <param name="entity">A Looks type object.</param>
        public override void Insert(Looks entity)
        {
            this.Context.Set<Looks>().Add(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Deletes a Look.
        /// </summary>
        /// <param name="id">An integer representing the ID of a look.</param>
        public override void Remove(int id)
        {
            Looks obj = this.GetOne(id);
            this.Context.Set<Looks>().Remove(obj);
            this.Context.SaveChanges();
        }
    }
}
