using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace U4WM55_HFT_2021221.Repository
{
    /// <summary>
    /// This is the Repository class.
    /// </summary>
    /// <typeparam name="T">We need a T type parameter which is a class.</typeparam>
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// This will create the table and bringing information from the data layer private version.
        /// </summary>
        private DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">We need a DbContext type parameter.</param>
        public Repository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets or sets the tables and info from data layer, protected version.
        /// </summary>
        protected DbContext Context { get => this.context; set => this.context = value; }

        /// <summary>
        /// This method will list all records.
        /// </summary>
        /// <returns>It returns all T type records as a list.</returns>
        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }

        /// <summary>
        /// This method will find 1 specific object for you.
        /// </summary>
        /// <param name="id">We need a parameter.</param>
        /// <returns>It returns a T type object.</returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// This method will insert a T type entity into our database.
        /// </summary>
        /// <param name="entity">We need a parameter.</param>
        public abstract void Insert(T entity);

        /// <summary>
        /// This method will remove a T type entity from our database.
        /// </summary>
        /// <param name="id">We need a T type parameter.</param>
        public abstract void Remove(int id);
    }
}
