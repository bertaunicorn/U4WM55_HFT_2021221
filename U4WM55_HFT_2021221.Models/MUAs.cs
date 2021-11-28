
namespace U4WM55_HFT_2021221.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    /// <summary>
    /// This class represents the muas table, which has the makeup artists in it, who might compete in the cup.
    /// </summary>
    [Table("muas")]
    public class MUAs
    {
        private int experienceLvl;

        /// <summary>
        /// Initializes a new instance of the <see cref="MUAs"/> class.
        /// </summary>
        public MUAs()
        {
            this.Connectors = new HashSet<Connector>();
        }

        /// <summary>
        ///  Gets the navigational property for the Connector table.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Connector> Connectors { get; }

        /// <summary>
        /// Gets or sets the Primary Key of the muas table, on which the attributes depend.
        /// </summary>
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the makeup artist.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the gender of the competitior.
        /// It should be indicated with one letter.
        /// M stands for male, F for female and N for non-binary.
        /// </summary>
        [MaxLength(1)]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the country where the competitior was born/where they are a resident.
        /// Longest country name in the world is 84 characters.
        /// It's called The Separate Customs Territory of Taiwan, Penghu, Kinmen, and Matsu (Chinese Taipei).
        /// </summary>
        [MaxLength(100)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the level of experience the makeup artist has.
        /// If it's below 2, they can't take part in the competition, because they're not experienced enough.
        /// </summary>
        [Required]
        [Range(1, 10)]
        public int ExperienceLvl
        {
            get
            {
                return this.experienceLvl;
            }

            set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The value must be greater than 0 and smaller than 11!");
                }

                this.experienceLvl = value;
            }
        }

        /// <summary>
        /// Gets or sets the phone number of the MUA.
        /// I didn't put restriction, because the numbers in different countries can be longer or shorter and not in the same format.
        /// </summary>
        public long Phone { get; set; }

        /// <summary>
        /// Gets or sets the email address of the competitior.
        /// </summary>
        [MaxLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the brand that sponsors the MUA.
        /// </summary>
        [MaxLength(200)]
        public string Sponsor { get; set; }

        /// <summary>
        /// Gets or sets the number of models a MUA has.
        /// /// It can only be 1/2/3.
        /// If they don't have enough, maybe they won't be able to finish in time,
        /// because they have to take off the makeup before applying a new look.
        /// </summary>
        [Required]
        public int NumOfModels { get; set; }

        /// <summary>
        /// Gets or sets the points the MUA collected so far in the competitions.
        /// </summary>
        public double Points { get; set; }

        /// <summary>
        /// Writes out all data in a nice joined string format.
        /// </summary>
        /// <returns>Returns a string with all needed information.</returns>
        public override string ToString()
        {
            string pronouns = "they/them";
            if (this.Gender == "N")
            {
                pronouns = "they/them";
            }
            else if (this.Gender == "M")
            {
                pronouns = "he/him";
            }
            else if (this.Gender == "F")
            {
                pronouns = "she/her";
            }

            return $"The {this.Id}. makeup artist in the registration list is {this.Name}." +
                $" They use the pronouns {pronouns} and they come from {this.Country} with an experience level of {this.ExperienceLvl}." +
                $" Their contact information is the following: phone number: {this.Phone} email address: {this.Email}." +
                $" They are sponsored by {this.Sponsor}, they have {this.NumOfModels} models " +
                $" and they collected {this.Points} points so far.";
        }

        /// <summary>
        /// Adds all fields as an integer, for an initial is it equal check.
        /// </summary>
        /// <returns>Returns an integer, which is sum of all fields in some way.</returns>
        public override int GetHashCode()
        {
            return this.Name.Length + this.Gender.Length + this.Country.Length + this.ExperienceLvl + (int)this.Phone + this.Email.Length
                + this.Sponsor.Length + this.NumOfModels + (int)this.Points;
        }

        /// <summary>
        /// Checks two MUAs if they are the same or not.
        /// </summary>
        /// <param name="obj">We hope to get a MUAs type object to compare.</param>
        /// <returns>Returns a boolean based on the check.</returns>
        public override bool Equals(object obj)
        {
            if (obj is MUAs)
            {
                MUAs test = obj as MUAs;
                if (this.Name == test.Name &&
                    this.Gender == test.Gender &&
                    this.Country == test.Country &&
                    this.ExperienceLvl == test.ExperienceLvl &&
                    this.Phone == test.Phone &&
                    this.Email == test.Email &&
                    this.Sponsor == test.Sponsor &&
                    this.NumOfModels == test.NumOfModels &&
                    this.Points == test.Points)
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
