namespace U4WM55_HFT_2021221.Models
{
    /// <summary>
    /// Result of the Genders linq query.
    /// </summary>
    public class GendersResult
    {
        /// <summary>
        /// Gets or sets the ID of the competitions.
        /// </summary>
        public int CompetitionID { get; set; }

        /// <summary>
        /// Gets or sets the genders of MUAs at the competitions.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the number of MUAs from each gender there are at competitions.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Overriding the ToString metod to get a nice message.
        /// </summary>
        /// <returns>A pretty and readable string.</returns>
        public override string ToString()
        {
            return $"At competition number {this.CompetitionID} from gender {this.Gender} there were {this.Number} number of participants. ";
        }

        /// <summary>
        /// Used before equals for same purpose.
        /// </summary>
        /// <returns>A cool useful integer.</returns>
        public override int GetHashCode()
        {
            return this.CompetitionID + this.Gender.Length + this.Number;
        }

        /// <summary>
        /// Checks if it is a unique thing.
        /// </summary>
        /// <param name="obj">A GendersResult object hopefully.</param>
        /// <returns>Returns a boolean.</returns>
        public override bool Equals(object obj)
        {
            if (obj is GendersResult)
            {
                GendersResult test = obj as GendersResult;
                if (this.CompetitionID == test.CompetitionID &&
                    this.Gender == test.Gender &&
                    this.Number == test.Number)
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
