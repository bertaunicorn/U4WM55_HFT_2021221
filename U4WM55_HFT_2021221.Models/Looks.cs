
namespace U4WM55_HFT_2021221.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// This class represents the looks table, which has the makeup looks to be created at the competitions.
    /// </summary>
    [Table("looks")]
    public class Looks
    {
        private int diffi;

        /// <summary>
        /// Gets or sets the Primary Key of the looks table, on which the attributes depend.
        /// </summary>
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the theme of the look to be created, can be eg. winter or halloween, a specific movie or anything basically.
        /// </summary>
        [MaxLength(200)]
        public string Theme { get; set; }

        /// <summary>
        /// Gets or sets the brand of makeup that the MUAs can use for this look.
        /// </summary>
        [MaxLength(200)]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the amount of money the MUAs can spend to buy products from the given brand, given in USD.
        /// </summary>
        public int Budget { get; set; }

        /// <summary>
        /// Gets or sets the amount of minutes the MUAs can spend on creating a look.
        /// </summary>
        [Required]
        public int TimeFrame { get; set; }

        /// <summary>
        /// Gets or sets how difficult the look is x/5. This determines the max points the judges can give the MUAs for the look.
        /// </summary>
        [Required]
        [Range(1, 5)]
        public int Difficulty
        {
            get
            {
                return this.diffi;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The value must be greater than 0!");
                }

                this.diffi = value;
            }
        }

        /// <summary>
        /// Gets or sets the Id of the competition where this look will be created.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Competitions))]
        public int? CompId { get; set; }

        /// <summary>
        /// Gets or sets a Competition type object.
        /// </summary>
        [NotMapped]
        public virtual Competitions Competition { get; set; }

        /// <summary>
        /// Writes out all data in a nice joined string format.
        /// </summary>
        /// <returns> returns a string with all needed information. </returns>
        public override string ToString()
        {
            return $"{this.Id}. look of the {this.CompId}. competition." +
                $" The MUAs have to create a look in a {this.Theme} theme, using {this.Brand} brand." +
                $" They have {this.Budget} US dollars to spend at the {this.Brand} store, to get all the makeup they will use." +
                $" They have to create their look in {this.TimeFrame} minutes." +
                $" The difficulty is {this.Difficulty}/5, this is the max point they can get for the look from the jury.";
        }

        /// <summary>
        /// Adds all fields as an integer, for an initial is it equal check.
        /// </summary>
        /// <returns>Returns an integer, which is sum of all fields in some way.</returns>
        public override int GetHashCode()
        {
            return this.Theme.Length + this.Brand.Length + this.Budget + this.TimeFrame + this.Difficulty;
        }

        /// <summary>
        /// Checks two Looks if they are the same or not.
        /// </summary>
        /// <param name="obj">We hope to get a Looks type object to compare.</param>
        /// <returns>Returns a boolean based on the check.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Looks)
            {
                Looks test = obj as Looks;
                if (this.Theme == test.Theme &&
                    this.Brand == test.Brand &&
                    this.Budget == test.Budget &&
                    this.TimeFrame == test.TimeFrame &&
                    this.Difficulty == test.Difficulty &&
                    this.CompId == test.CompId)
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
