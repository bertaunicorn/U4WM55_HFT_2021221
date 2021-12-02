using System;
using System.Collections.Generic;
using System.Linq;
using U4WM55_HFT_2021221.Models;
using U4WM55_HFT_2021221.Repository;

namespace U4WM55_HFT_2021221.Logic
{
    /// <summary>
    /// Updates regarding the participants.
    /// </summary>
    public class ParticipantLogic : IParticipantLogic
    {
        private IMUAsRepository muaRepo;
        private IConnectorRepository connRepo;
        private ICompetitionsRepository compRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParticipantLogic"/> class.
        /// </summary>
        /// <param name="muaRepo">We need an IMUAsRepository type parameter.</param>
        /// <param name="connRepo">We need an IConnectorRepository type parameter.</param>
        /// <param name="compRepo">We need an ICompetitionRepository type parameter.</param>
        public ParticipantLogic(IMUAsRepository muaRepo, IConnectorRepository connRepo, ICompetitionsRepository compRepo)
        {
            this.muaRepo = muaRepo;
            this.connRepo = connRepo;
            this.compRepo = compRepo;
        }

        /// <summary>
        /// Changes the number of models a MUA has. They might loose or gain 1 or 2.
        /// </summary>
        /// <param name="id">Id of a MUA.</param>
        /// <param name="newModels">An int representing the ugraded number of models a MUA has.</param>
        public void ChangeNumOfModels(int id, int newModels)
        {
            this.muaRepo.ChangeNumOfModels(id, newModels);
        }

        /// <summary>
        /// Upgrades a MUA's experience level if they get better.
        /// </summary>
        /// <param name="id">Id of a MUA.</param>
        /// <param name="newExperienceLvl">An int representing the new experience level of the MUA.</param>
        public void UpgradeMUA(int id, int newExperienceLvl)
        {
            this.muaRepo.UpgradeMUA(id, newExperienceLvl);
        }

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
        public void CreateMUA(string name, string gender, string country, int experienceLvl, long phone, string email, string sponsor, int numOfModels, double points)
        {
            MUAs newMUA = new MUAs()
            {
                Name = name,
                Gender = gender,
                Country = country,
                ExperienceLvl = experienceLvl,
                Phone = phone,
                Email = email,
                Sponsor = sponsor,
                NumOfModels = numOfModels,
                Points = points,
            };

            IQueryable<MUAs> muaList = this.muaRepo.GetAll();

            bool exists = false;
            foreach (MUAs item in muaList)
            {
                if (item.Equals(newMUA))
                {
                    exists = true;
                }
            }

            if (exists == false)
            {
                this.muaRepo.Insert(newMUA);
            }
            else
            {
                throw new InvalidOperationException("This MUA already exists!");
            }
        }

        /// <summary>
        /// Deleting an existing connection.
        /// </summary>
        /// <param name="id">An int representing the ID of the connenction we want to delete.</param>
        public void DeleteConnection(int id)
        {
            Connector connToDelete = this.connRepo.GetOne(id);

            if (connToDelete == null)
            {
                throw new InvalidOperationException("Connection not found!");
            }
            else
            {
                this.connRepo.Remove(id);
            }
        }

        /// <summary>
        /// Creating a new connection between mua and competition.
        /// </summary>
        /// <param name="compId">An integer representing the ID of the competition.</param>
        /// <param name="muaId">An integer representing the ID of the makeup artist.</param>
        public void CreateConnection(int compId, int muaId)
        {
            Connector newConn = new Connector()
            {
                CompetitionId = compId,
                MUAsId = muaId,
            };

            IQueryable<Connector> connList = this.connRepo.GetAll();

            bool exists = false;
            foreach (Connector item in connList)
            {
                if (item.Equals(newConn))
                {
                    exists = true;
                }
            }

            if (exists == false)
            {
                this.connRepo.Insert(newConn);
            }
            else
            {
                throw new InvalidOperationException("This Connection already exists!");
            }
        }

        /// <summary>
        /// This is a non-CRUD linq query which shows how many of each gender option there were at the competitions.
        /// </summary>
        /// <returns>Returns an IList.</returns>
        public IList<GendersResult> Genders()
        {
            IList<MUAs> muaList = this.muaRepo.GetAll().ToList();
            IList<Connector> connList = this.connRepo.GetAll().ToList();

            var muaConn = from conn in connList
                          join mua in muaList
                          on conn.MUAsId equals mua.Id
                          let compId = conn.CompetitionId
                          orderby compId
                          select new
                          {
                              CompetitionID = compId,
                              ConnectorID = conn.CCMId,
                              MUAId = mua.Id,
                              MUAName = mua.Name,
                              MUAGender = mua.Gender,
                          };

            var genders = from muas in muaConn
                          group muas by new { muas.CompetitionID, muas.MUAGender } into grp
                          let count = grp.Count()
                          select new GendersResult()
                          {
                              CompetitionID = grp.Key.CompetitionID,
                              Gender = grp.Key.MUAGender,
                              Number = count,
                          };

            return genders.ToList();
        }

        /// <summary>
        /// This is a non-CRUD linq query which shows if there is a MUA from the country of the current competition.
        /// </summary>
        /// <returns>Returns an IList.</returns>
        public IList<SameCountryResult> SameCountry()
        {
            IList<MUAs> muaList = this.muaRepo.GetAll().ToList();
            IList<Competitions> compList = this.compRepo.GetAll().ToList();
            IList<Connector> connList = this.connRepo.GetAll().ToList();


            var muaConn = from conn in connList
                          join mua in muaList
                          on conn.MUAsId equals mua.Id
                          let compId = conn.CompetitionId
                          orderby compId
                          select new
                          {
                              CompetitionID = compId,
                              ConnectorID = conn.CCMId,
                              MUAId = mua.Id,
                              MUAName = mua.Name,
                              MUACountry = mua.Country,
                          };

            var compConn = from muas in muaConn
                           join comp in compList
                           on muas.CompetitionID equals comp.Id
                           where comp.Place == muas.MUACountry
                           select new SameCountryResult()
                           {
                               MUACompID = muas.CompetitionID,
                               CompetitionPlace = comp.Place,
                               MUAPlace = muas.MUACountry,
                               MUAVeryID = muas.MUAId,
                               MUAVeryName = muas.MUAName,
                           };

            return compConn.ToList();
        }

        ///// <summary>
        ///// The async version of my Genders() method.
        ///// </summary>
        ///// <returns>Returns a Taks.</returns>
        //public Task<IList<GendersResult>> GendersAsync()
        //{
        //    return Task.Run(this.Genders);
        //}

        ///// <summary>
        ///// The async version of my SameCountry() method.
        ///// </summary>
        ///// <returns>Returns a Taks.</returns>
        //public Task<IList<SameCountryResult>> SameCountryAsync()
        //{
        //    return Task.Run(this.SameCountry);
        //}
    }
}
