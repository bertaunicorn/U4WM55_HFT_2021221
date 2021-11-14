using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Repository
{
    /// <summary>
    /// This is the MUAsRepository class.
    /// </summary>
    public class MUAsRepository : Repository<MUAs>, IMUAsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MUAsRepository"/> class.
        /// </summary>
        /// <param name="context">We need a DbContext type parameter.</param>
        public MUAsRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Changes the number of models a MUA has. They might loose or gain 1 or 2.
        /// </summary>
        /// <param name="id">Id of a MUA.</param>
        /// <param name="newModels">An int representing the ugraded number of models a MUA has.</param>
        public void ChangeNumOfModels(int id, int newModels)
        {
            var mua = this.GetOne(id);
            if (mua == null)
            {
                throw new InvalidOperationException("MUA not found!");
            }

            mua.NumOfModels = newModels;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Finds one specific MUA based on the id.
        /// </summary>
        /// <param name="id">Id of a MUA.</param>
        /// <returns>It returns a MUAs object.</returns>
        public override MUAs GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Upgrades a MUA's experience level if they get better.
        /// </summary>
        /// <param name="id">Id of a MUA.</param>
        /// <param name="newExperienceLvl">An int representing the new experience level of the MUA.</param>
        public void UpgradeMUA(int id, int newExperienceLvl)
        {
            var mua = this.GetOne(id);
            if (mua == null)
            {
                throw new InvalidOperationException("MUA not found!");
            }

            mua.ExperienceLvl = newExperienceLvl;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Adds a new MUA.
        /// </summary>
        /// <param name="entity">A MUAs type object.</param>
        public override void Insert(MUAs entity)
        {
            this.Context.Set<MUAs>().Add(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Deletes a MUA.
        /// </summary>
        /// <param name="id">An integer representing the ID of a MUA.</param>
        public override void Remove(int id)
        {
            MUAs obj = this.GetOne(id);
            this.Context.Set<MUAs>().Remove(obj);
            this.Context.SaveChanges();
        }
    }
}
