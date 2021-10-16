
namespace U4WM55_HFT_2021221.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// This class represents the competitions table, which has the 11 competitions of the year in it, for the annual championship/cup.
    /// </summary>
    [Table("competitions")]
    public class Competitions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Competitions"/> class.
        /// </summary>
        public Competitions()
        {
            this.Connectors = new HashSet<Connector>();
            this.Looks = new HashSet<Looks>();
        }

        /// <summary>
        /// Gets the navigational property for the Connector table.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Connector> Connectors { get; }

        /// <summary>
        /// Gets the navigational propery for the Looks table.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Looks> Looks { get; }

        /// <summary>
        /// Gets or sets an identifier for the table.
        /// Primary Key of the competitions table, on which the attributes depend.
        /// </summary>
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the country where the competition takes place.
        /// </summary>
        [MaxLength(200)]
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets the difficulty of the competition, on a scale of 1-10.
        /// </summary>
        public int Difficulty { get; set; }

        /// <summary>
        /// Gets or sets the date of the competition in YYYY-MM-DD format.
        /// The time part will be set to 00:00:00 since there is no simple date type in the C# language.
        /// </summary>
        public DateTime CompDate { get; set; }

        /// <summary>
        /// Gets or sets the number of judges on one competition to give points to attendees.
        /// Can be 3, 5 or 7 judges.
        /// </summary>
        public int HowManyJudges { get; set; }

        /// <summary>
        /// Gets or sets the main judge of a competition, usually a famous MUA from the host country.
        /// </summary>
        [MaxLength(200)]
        public string HeadOfJury { get; set; }

        /// <summary>
        /// Writes out all data in a nice joined string format.
        /// </summary>
        /// <returns> Returns a string with all needed information. </returns>
        public override string ToString()
        {
            return $"{this.Id}. competition of the year, taking place at {this.Place} on {this.CompDate}." +
                $" The difficulty is {this.Difficulty}/10." +
                $" There are {this.HowManyJudges} judges, and the head of the jury is {this.HeadOfJury}";
        }

        /// <summary>
        /// Adds all fields as an integer, for an initial is it equal check.
        /// </summary>
        /// <returns>Returns an integer, which is sum of all fields in some way.</returns>
        public override int GetHashCode()
        {
            return this.Place.Length + this.Difficulty +
                (int)Math.Round(this.CompDate.ToOADate()) + this.HowManyJudges + this.HeadOfJury.Length;
        }

        /// <summary>
        /// Checks two Competitions if they are the same or not.
        /// </summary>
        /// <param name="obj">We hope to get a Competitions type object to compare.</param>
        /// <returns>Returns a boolean based on the check.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Competitions)
            {
                Competitions test = obj as Competitions;
                if (this.Place == test.Place &&
                    this.Difficulty == test.Difficulty &&
                    this.CompDate == test.CompDate &&
                    this.HowManyJudges == test.HowManyJudges &&
                    this.HeadOfJury == test.HeadOfJury)
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
