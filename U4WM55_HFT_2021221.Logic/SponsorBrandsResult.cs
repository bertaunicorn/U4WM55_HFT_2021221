namespace U4WM55_HFT_2021221.Logic
{
    /// <summary>
    /// Result of the SponsorBrands linq query.
    /// </summary>
    public class SponsorBrandsResult
    {
        /// <summary>
        /// Gets or sets the ID of the MUAs.
        /// </summary>
        public int MUAId { get; set; }

        /// <summary>
        /// Gets or sets the name of the MUAs.
        /// </summary>
        public string MUAName { get; set; }

        /// <summary>
        /// Gets or sets the sponsor of the MUAs.
        /// </summary>
        public string MUASpon { get; set; }

        /// <summary>
        /// Gets or sets the brand of the looks.
        /// </summary>
        public string LookBrand { get; set; }

        /// <summary>
        /// Gets or sets the ID of the looks.
        /// </summary>
        public int LookID { get; set; }

        /// <summary>
        /// Overriding the ToString metod to get a nice message.
        /// </summary>
        /// <returns>A pretty and readable string.</returns>
        public override string ToString()
        {
            return $"The following MUAs with ID number {this.MUAId} whos name is {this.MUAName} had the same sponsor {this.MUASpon}" +
                $" as the folloing looks with brand {this.LookBrand} and the ID number {this.LookID}.";
        }

        /// <summary>
        /// Used before equals for same purpose.
        /// </summary>
        /// <returns>A cool useful integer.</returns>
        public override int GetHashCode()
        {
            return this.MUAId + this.MUAName.Length + this.MUASpon.Length + this.LookBrand.Length + this.LookID;
        }

        /// <summary>
        /// Checks if it is a unique thing.
        /// </summary>
        /// <param name="obj">A SponsorBrandsResult object hopefully.</param>
        /// <returns>Returns a boolean.</returns>
        public override bool Equals(object obj)
        {
            if (obj is SponsorBrandsResult)
            {
                SponsorBrandsResult test = obj as SponsorBrandsResult;
                if (this.MUAId == test.MUAId &&
                    this.MUAName == test.MUAName &&
                    this.MUASpon == test.MUASpon &&
                    this.LookBrand == test.LookBrand &&
                    this.LookID == test.LookID)
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
