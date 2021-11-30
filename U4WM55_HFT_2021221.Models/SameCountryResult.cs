namespace U4WM55_HFT_2021221.Models
{
    /// <summary>
    /// Result of the SameCountry linq query.
    /// </summary>
    public class SameCountryResult
    {
        /// <summary>
        /// Gets or sets the ID of the competitions.
        /// </summary>
        public int MUACompID { get; set; }

        /// <summary>
        /// Gets or sets the country where the competitions take place.
        /// </summary>
        public string CompetitionPlace { get; set; }

        /// <summary>
        /// Gets or sets the country of the MUAs.
        /// </summary>
        public string MUAPlace { get; set; }

        /// <summary>
        /// Gets or sets the ID of the MUAs.
        /// </summary>
        public int MUAVeryID { get; set; }

        /// <summary>
        /// Gets or sets the name of the MUAs.
        /// </summary>
        public string MUAVeryName { get; set; }

        /// <summary>
        /// Overriding the ToString metod to get a nice message.
        /// </summary>
        /// <returns>A pretty and readable string.</returns>
        public override string ToString()
        {
            return $"The following MUAs with ID number {this.MUAVeryID} whos name is {this.MUAVeryName} came from the same country {this.MUAPlace}" +
                $" where the competition {this.MUACompID} was held, which is again, {this.CompetitionPlace}.";
        }

        /// <summary>
        /// Used before equals for same purpose.
        /// </summary>
        /// <returns>A cool useful integer.</returns>
        public override int GetHashCode()
        {
            return this.MUACompID + this.CompetitionPlace.Length + this.MUAPlace.Length + this.MUAVeryID + this.MUAVeryName.Length;
        }

        /// <summary>
        /// Checks if it is a unique thing.
        /// </summary>
        /// <param name="obj">A SameCountryResult object hopefully.</param>
        /// <returns>Returns a boolean.</returns>
        public override bool Equals(object obj)
        {
            if (obj is SameCountryResult)
            {
                SameCountryResult test = obj as SameCountryResult;
                if (this.MUACompID == test.MUACompID &&
                    this.CompetitionPlace == test.CompetitionPlace &&
                    this.MUAPlace == test.MUAPlace &&
                    this.MUAVeryID == test.MUAVeryID &&
                    this.MUAVeryName == test.MUAVeryName)
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
