using Microsoft.EntityFrameworkCore;
using System.Linq;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Repository
{
    /// <summary>
    /// This is the connector repository.
    /// </summary>
    public class ConnectorRepository : Repository<Connector>, IConnectorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorRepository"/> class.
        /// </summary>
        /// <param name="context">We need a DbContext type parameter.</param>
        public ConnectorRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Getting one object by the ID.
        /// </summary>
        /// <param name="id">Integer type parameter representing the id of the object to be found.</param>
        /// <returns>Returns a single connection.</returns>
        public override Connector GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.CCMId == id);
        }

        /// <summary>
        /// Adds a new Connection.
        /// </summary>
        /// <param name="entity">A Connector type object.</param>
        public override void Insert(Connector entity)
        {
            this.Context.Set<Connector>().Add(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Deletes a Connection.
        /// </summary>
        /// <param name="id">An integer representing the ID of a connection.</param>
        public override void Remove(int id)
        {
            Connector obj = this.GetOne(id);
            this.Context.Set<Connector>().Remove(obj);
            this.Context.SaveChanges();
        }
    }
}
