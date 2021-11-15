namespace U4WM55_HFT_2021221.Logic
{
    /// <summary>
    /// Result of the HowManyLooks linq query.
    /// </summary>
    public class HowManyLooksResult
    {
        /// <summary>
        /// Gets or sets the ID number of the competition we are looking at.
        /// </summary>
        public int CompetitionID { get; set; }

        /// <summary>
        /// Gets or sets the number of looks at that competition.
        /// </summary>
        public int NumberOfLooks { get; set; }

        /// <summary>
        /// Overriding the ToString metod to get a nice message.
        /// </summary>
        /// <returns>A pretty and readable string.</returns>
        public override string ToString()
        {
            return $"At competition number {this.CompetitionID}, there are {this.NumberOfLooks} looks to be created.";
        }

        /// <summary>
        /// Used before equals for same purpose.
        /// </summary>
        /// <returns>A cool useful integer.</returns>
        public override int GetHashCode()
        {
            return this.CompetitionID + this.NumberOfLooks;
        }

        /// <summary>
        /// Checks if it is a unique thing.
        /// </summary>
        /// <param name="obj">A HowManyLooksResult object hopefully.</param>
        /// <returns>Returns a boolean.</returns>
        public override bool Equals(object obj)
        {
            if (obj is HowManyLooksResult)
            {
                HowManyLooksResult test = obj as HowManyLooksResult;
                if (this.CompetitionID == test.CompetitionID &&
                    this.NumberOfLooks == test.NumberOfLooks)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
