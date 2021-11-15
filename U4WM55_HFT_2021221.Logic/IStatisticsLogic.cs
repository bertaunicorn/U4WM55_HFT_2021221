using System.Collections.Generic;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Logic
{
    /// <summary>
    /// Logic for the GetAll and GetOne methods from every class.
    /// </summary>
    public interface IStatisticsLogic
    {
        /// <summary>
        /// Finding a specific competition.
        /// </summary>
        /// <param name="id">We need a Competitions.Id parameter.</param>
        /// <returns>Returns the found Competitions type object.</returns>
        Competitions GetOneComp(int id);

        /// <summary>
        /// Listing all competitions.
        /// </summary>
        /// <returns>Returns a list of all Competitions.</returns>
        IList<Competitions> GetAllComps();

        /// <summary>
        /// Finding a specific look.
        /// </summary>
        /// <param name="id">We need a Looks.Id parameter.</param>
        /// <returns>Returns the found Looks type object.</returns>
        Looks GetOneLook(int id);

        /// <summary>
        /// Listing all looks.
        /// </summary>
        /// <returns>Returns a list of all Looks.</returns>
        IList<Looks> GetAllLooks();

        /// <summary>
        /// Finding a specific MUA.
        /// </summary>
        /// <param name="id">We need a MUAs.Id parameter.</param>
        /// <returns>Returns the found MUAs type object.</returns>
        MUAs GetOneMUA(int id);

        /// <summary>
        /// Listing all MUAs.
        /// </summary>
        /// <returns>Returns a list of all MUAs.</returns>
        IList<MUAs> GetAllMUAs();

        /// <summary>
        /// Finding a specific connection.
        /// </summary>
        /// <param name="id">We need a CCMId parameter.</param>
        /// <returns>Returns a Connection.</returns>
        Connector GetOneConn(int id);

        /// <summary>
        /// Listing all connections.
        /// </summary>
        /// <returns>Returns a list of all Connections.</returns>
        IList<Connector> GetAllConns();
    }
}
