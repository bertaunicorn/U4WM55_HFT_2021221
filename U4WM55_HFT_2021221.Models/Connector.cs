
namespace U4WM55_HFT_2021221.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// This class represents the conn_comp_mua table, which is a connector table between the competitions and muas table.
    /// </summary>
    [Table("conn_comp_mua")]
    public class Connector
    {
        /// <summary>
        /// Gets or sets the Primary Key of the connector table, on which the attributes depend.
        /// It's generated automatically.
        /// </summary>
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CCMId { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Competition where we'll use this connection.
        /// </summary>
        [ForeignKey(nameof(Competitions))]
        [Required]
        public int CompetitionId { get; set; }

        /// <summary>
        /// Gets or sets a Competition type object.
        /// </summary>
        public virtual Competitions Competitions { get; set; }

        /// <summary>
        /// Gets or sets the Id of the MUA who we will use this connection for.
        /// </summary>
        [ForeignKey(nameof(MUAs))]
        [Required]
        public int MUAsId { get; set; }

        /// <summary>
        /// Gets or sets a MUAs type object.
        /// </summary>
        public virtual MUAs MUAs { get; set; }

        /// <summary>
        /// Writes out all data in a nice joined string format.
        /// </summary>
        /// <returns> Returns a string with all needed information. </returns>
        public override string ToString()
        {
            return $"{this.CCMId}. connection which shows us that on the {this.CompetitionId}. competition" +
                $" the {this.MUAsId}. makeup artist, namely {this.MUAs.Name} took part.";
        }

        /// <summary>
        /// Checks two Connector if they are the same or not.
        /// </summary>
        /// <param name="obj">We hope to get a Connector type object to compare.</param>
        /// <returns>Returns a boolean based on the check.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Connector)
            {
                Connector test = obj as Connector;
                if (this.CompetitionId == test.CompetitionId &&
                    this.MUAsId == test.MUAsId)
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

        /// <summary>
        /// Returning a number as an original check for being uniqe.
        /// </summary>
        /// <returns>A number adding all 3 ids (conn id and 2 foreign key ids).</returns>
        public override int GetHashCode()
        {
            return this.CCMId + this.MUAsId + this.CompetitionId;
        }
    }
}
