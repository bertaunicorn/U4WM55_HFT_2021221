using System.Linq;

namespace U4WM55_HFT_2021221.Repository
{
    /// <summary>
    /// This is the IRepository class.
    /// </summary>
    /// <typeparam name="T">We need a parameter.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// This method will find 1 specific object for you.
        /// </summary>
        /// <param name="id">We need a parameter.</param>
        /// <returns>It returns a T type record.</returns>
        T GetOne(int id);

        /// <summary>
        /// This method will list all records.
        /// </summary>
        /// <returns>It returns all T type records as a list.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// This method will insert a T type entity into our database.
        /// </summary>
        /// <param name="entity">We need a parameter.</param>
        void Insert(T entity);

        /// <summary>
        /// This method will remove a T type entity from our database.
        /// </summary>
        /// <param name="id">We need a parameter.</param>
        void Remove(int id);
    }
}
