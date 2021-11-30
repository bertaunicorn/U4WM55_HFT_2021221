using System;
using System.Collections.Generic;
using System.Linq;
using U4WM55_HFT_2021221.Models;
using U4WM55_HFT_2021221.Repository;

namespace U4WM55_HFT_2021221.Logic
{
    /// <summary>
    /// Implementing the ISatisticsLogic interface.
    /// </summary>
    public class StatisticsLogic : IStatisticsLogic
    {
        private ICompetitionsRepository compRepo;
        private ILooksRepository lookRepo;
        private IMUAsRepository muaRepo;
        private IConnectorRepository connRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsLogic"/> class.
        /// </summary>
        /// <param name="compRepo">We need an ICompetitionsRepository type parameter.</param>
        /// <param name="lookRepo">We need an ILooksRepository type parameter.</param>
        /// <param name="muaRepo">We need an IMUAsRepository type parameter.</param>
        /// <param name="connRepo">We need an IConnectorRepository type parameter.</param>
        public StatisticsLogic(ICompetitionsRepository compRepo, ILooksRepository lookRepo, IMUAsRepository muaRepo, IConnectorRepository connRepo)
        {
            this.compRepo = compRepo;
            this.lookRepo = lookRepo;
            this.muaRepo = muaRepo;
            this.connRepo = connRepo;
        }

        /// <summary>
        /// Listing all competitions.
        /// </summary>
        /// <returns>Returns a list of all Competitions.</returns>
        public IList<Competitions> GetAllComps()
        {
            return this.compRepo.GetAll().ToList();
        }

        /// <summary>
        /// Listing all looks.
        /// </summary>
        /// <returns>Returns a list of all Looks.</returns>
        public IList<Looks> GetAllLooks()
        {
            return this.lookRepo.GetAll().ToList();
        }

        /// <summary>
        /// Listing all MUAs.
        /// </summary>
        /// <returns>Returns a list of all MUAs.</returns>
        public IList<MUAs> GetAllMUAs()
        {
            return this.muaRepo.GetAll().ToList();
        }

        /// <summary>
        /// Listing all Connections.
        /// </summary>
        /// <returns>A list of all connections.</returns>
        public IList<Connector> GetAllConns()
        {
            return this.connRepo.GetAll().ToList();
        }

        /// <summary>
        /// Finds one specific competition based on the id.
        /// </summary>
        /// <param name="id">We need a Competitions.Id parameter.</param>
        /// <returns>Returns the found Competitions type object.</returns>
        public Competitions GetOneComp(int id)
        {
            Competitions comp = this.compRepo.GetOne(id);
            if (comp == null)
            {
                throw new InvalidOperationException("Competition not found!");
            }

            return this.compRepo.GetOne(id);
        }

        /// <summary>
        /// Finding a specific look.
        /// </summary>
        /// <param name="id">We need a Looks.Id parameter.</param>
        /// <returns>Returns the found Looks type object.</returns>
        public Looks GetOneLook(int id)
        {
            Looks look = this.lookRepo.GetOne(id);
            if (look == null)
            {
                throw new InvalidOperationException("Look not found!");
            }

            return this.lookRepo.GetOne(id);
        }

        /// <summary>
        /// Finding a specific MUA.
        /// </summary>
        /// <param name="id">We need a MUAs.Id parameter.</param>
        /// <returns>Returns the found MUAs type object.</returns>
        public MUAs GetOneMUA(int id)
        {
            MUAs mua = this.muaRepo.GetOne(id);
            if (mua == null)
            {
                throw new InvalidOperationException("Makeup artist not found!");
            }

            return this.muaRepo.GetOne(id);
        }

        /// <summary>
        /// Finding one specific connection.
        /// </summary>
        /// <param name="id">We need a CCMId parameter.</param>
        /// <returns>Returns a Connection.</returns>
        public Connector GetOneConn(int id)
        {
            Connector conn = this.connRepo.GetOne(id);
            if (conn == null)
            {
                throw new InvalidOperationException("Connection not found!");
            }

            return this.connRepo.GetOne(id);
        }
    }
}
