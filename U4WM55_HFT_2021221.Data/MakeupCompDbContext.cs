using Microsoft.EntityFrameworkCore;
using System;

namespace U4WM55_HFT_2021221.Models
{
    public class MakeupCompDbContext : DbContext
    {
        private static readonly object padlock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="MakeupCompetitionDatabaseContext"/> class.
        /// </summary>
        public MakeupCompDbContext()
        {
            lock (padlock)
            {
                this.Database.EnsureCreated();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MakeupCompetitionDatabaseContext"/> class.
        /// </summary>
        /// <param name="options">We hope to get DbContextOptions MakeupCompetitionDatabaseContext type object.</param>
        public MakeupCompDbContext(DbContextOptions<MakeupCompDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Competition's DbSet.
        /// </summary>
        public virtual DbSet<Competitions> Competitions { get; set; }

        /// <summary>
        /// Gets or sets the Connector's DbSet.
        /// </summary>
        public virtual DbSet<Connector> Connectors { get; set; }

        /// <summary>
        /// Gets or sets the MUAs' DbSet.
        /// </summary>
        public virtual DbSet<MUAs> MUAs { get; set; }

        /// <summary>
        /// Gets or sets the Looks' DbSet.
        /// </summary>
        public virtual DbSet<Looks> Looks { get; set; }

        /// <summary>
        /// Overrides OnCOnfigurung method.
        /// Makes LazyLoading possible.
        /// </summary>
        /// <param name="optionsBuilder">We hope to get a DbContextOptionsBuilder type object.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null && !optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB; Attachdbfilename=|DataDirectory|\Database.mdf; Integrated security=True; MultipleActiveResultSets=True");
            }
        }

        /// <summary>
        /// Overrides the OnModelCreating method.
        /// Creates the connections between the tables.
        /// We add the code with the information here (creating the records).
        /// </summary>
        /// <param name="modelBuilder">We hope to get a ModelBulider type object.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                modelBuilder.Entity<Looks>(entity =>
                {
                    entity.HasOne(look => look.Competition)
                          .WithMany(competition => competition.Looks)
                          .HasForeignKey(look => look.CompId)
                          .OnDelete(DeleteBehavior.Cascade);
                });

                modelBuilder.Entity<Connector>(entity =>
                {
                    entity.HasOne(conn => conn.Competitions)
                          .WithMany(competition => competition.Connectors)
                          .HasForeignKey(conn => conn.CompetitionId)
                          .OnDelete(DeleteBehavior.Cascade);
                });

                modelBuilder.Entity<Connector>(entity =>
                {
                    entity.HasOne(conn => conn.MUAs)
                          .WithMany(muas => muas.Connectors)
                          .HasForeignKey(conn => conn.MUAsId)
                          .OnDelete(DeleteBehavior.Cascade);
                });
                Competitions comp1 = new Competitions()
                {
                    Id = 1,
                    Place = "Hungary",
                    Difficulty = 5,
                    CompDate = new DateTime(2020, 01, 11),
                    HowManyJudges = 3,
                    HeadOfJury = "Tombor Sarolta",
                };

                Competitions comp2 = new Competitions()
                {
                    Id = 2,
                    Place = "Argentina",
                    Difficulty = 2,
                    CompDate = new DateTime(2020, 02, 08),
                    HowManyJudges = 5,
                    HeadOfJury = "Eva De Dominici",
                };

                Competitions comp3 = new Competitions()
                {
                    Id = 3,
                    Place = "The Neatherlands",
                    Difficulty = 7,
                    CompDate = new DateTime(2020, 03, 14),
                    HowManyJudges = 3,
                    HeadOfJury = "Nikkie de Jager",
                };

                Competitions comp4 = new Competitions()
                {
                    Id = 4,
                    Place = "France",
                    Difficulty = 8,
                    CompDate = new DateTime(2020, 04, 11),
                    HowManyJudges = 7,
                    HeadOfJury = "Jeanne Damas",
                };

                Competitions comp5 = new Competitions()
                {
                    Id = 5,
                    Place = "Sweden",
                    Difficulty = 4,
                    CompDate = new DateTime(2020, 05, 09),
                    HowManyJudges = 5,
                    HeadOfJury = "Evelina Forsell",
                };

                Competitions comp6 = new Competitions()
                {
                    Id = 6,
                    Place = "USA",
                    Difficulty = 5,
                    CompDate = new DateTime(2020, 06, 13),
                    HowManyJudges = 5,
                    HeadOfJury = "Gucci Westman",
                };

                Competitions comp7 = new Competitions()
                {
                    Id = 7,
                    Place = "Australia",
                    Difficulty = 1,
                    CompDate = new DateTime(2020, 07, 11),
                    HowManyJudges = 7,
                    HeadOfJury = "Ania Milczarczyk",
                };

                Competitions comp8 = new Competitions()
                {
                    Id = 8,
                    Place = "Russia",
                    Difficulty = 10,
                    CompDate = new DateTime(2020, 08, 08),
                    HowManyJudges = 3,
                    HeadOfJury = "Andrey Petrov",
                };

                Competitions comp9 = new Competitions()
                {
                    Id = 9,
                    Place = "China",
                    Difficulty = 6,
                    CompDate = new DateTime(2020, 09, 12),
                    HowManyJudges = 5,
                    HeadOfJury = "Lalisa Manoban",
                };

                Competitions comp10 = new Competitions()
                {
                    Id = 10,
                    Place = "USA",
                    Difficulty = 9,
                    CompDate = new DateTime(2020, 10, 10),
                    HowManyJudges = 3,
                    HeadOfJury = "Pat McGrath",
                };

                Competitions comp11 = new Competitions()
                {
                    Id = 11,
                    Place = "Canada",
                    Difficulty = 10,
                    CompDate = new DateTime(2020, 11, 14),
                    HowManyJudges = 3,
                    HeadOfJury = "Mimi Choi",
                };

                Looks look1 = new Looks()
                {
                    Id = 1,
                    Theme = "flowers",
                    Brand = "YSL",
                    Budget = 400,
                    TimeFrame = 60,
                    Difficulty = 2,
                    CompId = 1,
                };

                Looks look2 = new Looks()
                {
                    Id = 2,
                    Theme = "animals",
                    Brand = "NajOleari",
                    Budget = 500,
                    TimeFrame = 120,
                    Difficulty = 4,
                    CompId = comp1.Id,
                };

                Looks look3 = new Looks()
                {
                    Id = 3,
                    Theme = "spring",
                    Brand = "Lancome",
                    Budget = 400,
                    TimeFrame = 60,
                    Difficulty = 1,
                    CompId = comp2.Id,
                };

                Looks look4 = new Looks()
                {
                    Id = 4,
                    Theme = "easter",
                    Brand = "Hourglass",
                    Budget = 600,
                    TimeFrame = 120,
                    Difficulty = 4,
                    CompId = comp2.Id,
                };

                Looks look5 = new Looks()
                {
                    Id = 5,
                    Theme = "diamonds",
                    Brand = "MAC",
                    Budget = 700,
                    TimeFrame = 180,
                    Difficulty = 5,
                    CompId = comp3.Id,
                };

                Looks look6 = new Looks()
                {
                    Id = 6,
                    Theme = "machines",
                    Brand = "Clinique",
                    Budget = 450,
                    TimeFrame = 60,
                    Difficulty = 2,
                    CompId = comp3.Id,
                };

                Looks look7 = new Looks()
                {
                    Id = 7,
                    Theme = "I see red",
                    Brand = "Dior",
                    Budget = 700,
                    TimeFrame = 60,
                    Difficulty = 1,
                    CompId = comp4.Id,
                };

                Looks look8 = new Looks()
                {
                    Id = 8,
                    Theme = "Alice in Wonderland",
                    Brand = "Urban Decay",
                    Budget = 800,
                    TimeFrame = 120,
                    Difficulty = 4,
                    CompId = comp4.Id,
                };

                Looks look9 = new Looks()
                {
                    Id = 9,
                    Theme = "urban",
                    Brand = "Gosh",
                    Budget = 600,
                    TimeFrame = 120,
                    Difficulty = 3,
                    CompId = comp5.Id,
                };

                Looks look10 = new Looks()
                {
                    Id = 10,
                    Theme = "square",
                    Brand = "Burberry",
                    Budget = 900,
                    TimeFrame = 120,
                    Difficulty = 2,
                    CompId = comp5.Id,
                };

                Looks look11 = new Looks()
                {
                    Id = 11,
                    Theme = "shine",
                    Brand = "Glossier",
                    Budget = 800,
                    TimeFrame = 200,
                    Difficulty = 5,
                    CompId = comp5.Id,
                };

                Looks look12 = new Looks()
                {
                    Id = 12,
                    Theme = "nature",
                    Brand = "Giorgio Armani",
                    Budget = 680,
                    TimeFrame = 120,
                    Difficulty = 3,
                    CompId = comp6.Id,
                };

                Looks look13 = new Looks()
                {
                    Id = 13,
                    Theme = "Harry Potter",
                    Brand = "Revolution",
                    Budget = 1200,
                    TimeFrame = 120,
                    Difficulty = 4,
                    CompId = comp6.Id,
                };

                Looks look14 = new Looks()
                {
                    Id = 14,
                    Theme = "Unicorns",
                    Brand = "Givenchy",
                    Budget = 460,
                    TimeFrame = 90,
                    Difficulty = 2,
                    CompId = comp7.Id,
                };

                Looks look15 = new Looks()
                {
                    Id = 15,
                    Theme = "Pride",
                    Brand = "Clarins",
                    Budget = 900,
                    TimeFrame = 200,
                    Difficulty = 5,
                    CompId = comp7.Id,
                };

                Looks look16 = new Looks()
                {
                    Id = 16,
                    Theme = "childhood",
                    Brand = "Shiseido",
                    Budget = 450,
                    TimeFrame = 120,
                    Difficulty = 3,
                    CompId = comp8.Id,
                };

                Looks look17 = new Looks()
                {
                    Id = 17,
                    Theme = "beach",
                    Brand = "Chanel",
                    Budget = 1000,
                    TimeFrame = 180,
                    Difficulty = 3,
                    CompId = comp8.Id,
                };

                Looks look18 = new Looks()
                {
                    Id = 18,
                    Theme = "school",
                    Brand = "Too Faced",
                    Budget = 600,
                    TimeFrame = 120,
                    Difficulty = 3,
                    CompId = comp9.Id,
                };

                Looks look19 = new Looks()
                {
                    Id = 19,
                    Theme = "mirrors",
                    Brand = "Fenti",
                    Budget = 780,
                    TimeFrame = 90,
                    Difficulty = 2,
                    CompId = comp10.Id,
                };

                Looks look20 = new Looks()
                {
                    Id = 20,
                    Theme = "horror",
                    Brand = "Bobbi Brown",
                    Budget = 540,
                    TimeFrame = 180,
                    Difficulty = 4,
                    CompId = comp10.Id,
                };

                Looks look21 = new Looks()
                {
                    Id = 21,
                    Theme = "ice and snow",
                    Brand = "Guerlain",
                    Budget = 900,
                    TimeFrame = 200,
                    Difficulty = 5,
                    CompId = comp11.Id,
                };

                Looks look22 = new Looks()
                {
                    Id = 22,
                    Theme = "christmas",
                    Brand = "Sisley",
                    Budget = 500,
                    TimeFrame = 180,
                    Difficulty = 4,
                    CompId = comp11.Id,
                };

                MUAs mua1 = new MUAs()
                {
                    Id = 1,
                    Name = "Attila Kovács",
                    Gender = "M",
                    Country = "Hungary",
                    ExperienceLvl = 8,
                    Phone = 4512587,
                    Email = "akovacsmua@gmail.com",
                    Sponsor = "Audi",
                    NumOfModels = 3,
                    Points = 176,
                };

                MUAs mua2 = new MUAs()
                {
                    Id = 2,
                    Name = "Felicia Snow",
                    Gender = "F",
                    Country = "Sweden",
                    ExperienceLvl = 5,
                    Phone = 620230870,
                    Email = "fsnowmua@gmail.com",
                    Sponsor = "Louis Vuitton",
                    NumOfModels = 2,
                    Points = 136,
                };

                MUAs mua3 = new MUAs()
                {
                    Id = 3,
                    Name = "Jane Smith",
                    Gender = "F",
                    Country = "Canada",
                    ExperienceLvl = 7,
                    Phone = 878548008,
                    Email = "jsmithmua@gmail.com",
                    Sponsor = "Clinique",
                    NumOfModels = 1,
                    Points = 153,
                };

                MUAs mua4 = new MUAs()
                {
                    Id = 4,
                    Name = "Wang Xiu Ying",
                    Gender = "F",
                    Country = "China",
                    ExperienceLvl = 9,
                    Phone = 7893567969,
                    Email = "wxiuyingmua@gmail.com",
                    Sponsor = "Huawei",
                    NumOfModels = 3,
                    Points = 197,
                };

                MUAs mua5 = new MUAs()
                {
                    Id = 5,
                    Name = "Sam Green",
                    Gender = "N",
                    Country = "USA",
                    ExperienceLvl = 5,
                    Phone = 267800600,
                    Email = "sgreenmua@gmail.com",
                    Sponsor = "McDonalds",
                    NumOfModels = 2,
                    Points = 140,
                };

                MUAs mua6 = new MUAs()
                {
                    Id = 6,
                    Name = "Aadrik Ramesh",
                    Gender = "M",
                    Country = "India",
                    ExperienceLvl = 6,
                    Phone = 3835736967,
                    Email = "arameshmua@gmail.com",
                    Sponsor = "Burberry",
                    NumOfModels = 2,
                    Points = 148,
                };

                MUAs mua7 = new MUAs()
                {
                    Id = 7,
                    Name = "Dmitri Ivanov",
                    Gender = "M",
                    Country = "Russia",
                    ExperienceLvl = 10,
                    Phone = 8434554913,
                    Email = "divanovmua@gmail.com",
                    Sponsor = "Nikon",
                    NumOfModels = 3,
                    Points = 203,
                };

                MUAs mua8 = new MUAs()
                {
                    Id = 8,
                    Name = "Isabella van den Berg",
                    Gender = "F",
                    Country = "The Neatherlands",
                    ExperienceLvl = 8,
                    Phone = 518551273,
                    Email = "ivandenbergmua@gmail.com",
                    Sponsor = "Adidas",
                    NumOfModels = 2,
                    Points = 186,
                };

                MUAs mua9 = new MUAs()
                {
                    Id = 9,
                    Name = "Juan Gomez",
                    Gender = "M",
                    Country = "Argentina",
                    ExperienceLvl = 6,
                    Phone = 201069588,
                    Email = "jgomezmua@gmail.com",
                    Sponsor = "Microsoft",
                    NumOfModels = 1,
                    Points = 124,
                };

                MUAs mua10 = new MUAs()
                {
                    Id = 10,
                    Name = "Ava Williams",
                    Gender = "F",
                    Country = "Australia",
                    ExperienceLvl = 3,
                    Phone = 940745971,
                    Email = "awilliamsmua@gmail.com",
                    Sponsor = "Nike",
                    NumOfModels = 1,
                    Points = 104,
                };

                MUAs mua11 = new MUAs()
                {
                    Id = 11,
                    Name = "Ines Martin",
                    Gender = "F",
                    Country = "France",
                    ExperienceLvl = 9,
                    Phone = 2016068,
                    Email = "imartinmua@gmail.com",
                    Sponsor = "Samsung",
                    NumOfModels = 3,
                    Points = 201,
                };

                MUAs mua12 = new MUAs()
                {
                    Id = 12,
                    Name = "Hugo García",
                    Gender = "M",
                    Country = "Hungary",
                    ExperienceLvl = 5,
                    Phone = 4230982,
                    Email = "hgarciamua@gmail.com",
                    Sponsor = "Lego",
                    NumOfModels = 2,
                    Points = 132,
                };

                MUAs mua13 = new MUAs()
                {
                    Id = 13,
                    Name = "Enzokuhle Khumalo",
                    Gender = "N",
                    Country = "South Africa",
                    ExperienceLvl = 4,
                    Phone = 6642295,
                    Email = "ekhumalomua@gmail.com",
                    Sponsor = "Google",
                    NumOfModels = 2,
                    Points = 117,
                };

                MUAs mua14 = new MUAs()
                {
                    Id = 14,
                    Name = "Maria Santos",
                    Gender = "F",
                    Country = "Brazil",
                    ExperienceLvl = 7,
                    Phone = 8049523426,
                    Email = "msantosmua@gmail.com",
                    Sponsor = "Starbucks",
                    NumOfModels = 2,
                    Points = 148,
                };

                MUAs mua15 = new MUAs()
                {
                    Id = 15,
                    Name = "Ben Müller",
                    Gender = "M",
                    Country = "Germany",
                    ExperienceLvl = 9,
                    Phone = 4894680,
                    Email = "bmullermua@gmail.com",
                    Sponsor = "DKNY",
                    NumOfModels = 2,
                    Points = 195,
                };

                MUAs mua16 = new MUAs()
                {
                    Id = 16,
                    Name = "Miray Adin",
                    Gender = "F",
                    Country = "Turkey",
                    ExperienceLvl = 7,
                    Phone = 4200347,
                    Email = "madinmua@gmail.com",
                    Sponsor = "Disney",
                    NumOfModels = 2,
                    Points = 163,
                };

                MUAs mua17 = new MUAs()
                {
                    Id = 17,
                    Name = "River Jones",
                    Gender = "N",
                    Country = "England",
                    ExperienceLvl = 6,
                    Phone = 6536043,
                    Email = "rjonesmua@gmail.com",
                    Sponsor = "Ebay",
                    NumOfModels = 3,
                    Points = 174,
                };

                MUAs mua18 = new MUAs()
                {
                    Id = 18,
                    Name = "Sofia Russo",
                    Gender = "F",
                    Country = "Italy",
                    ExperienceLvl = 2,
                    Phone = 167435405,
                    Email = "srussomua@gmail.com",
                    Sponsor = "Starbucks",
                    NumOfModels = 1,
                    Points = 0,
                };

                Connector conn1 = new Connector()
                { CCMId = 1, CompetitionId = comp1.Id, MUAsId = mua1.Id };

                Connector conn2 = new Connector()
                { CCMId = 2, CompetitionId = comp1.Id, MUAsId = mua2.Id };

                Connector conn3 = new Connector()
                { CCMId = 3, CompetitionId = comp1.Id, MUAsId = mua3.Id };

                Connector conn4 = new Connector()
                { CCMId = 4, CompetitionId = comp1.Id, MUAsId = mua4.Id };

                Connector conn5 = new Connector()
                { CCMId = 5, CompetitionId = comp1.Id, MUAsId = mua5.Id };

                Connector conn6 = new Connector()
                { CCMId = 6, CompetitionId = comp1.Id, MUAsId = mua6.Id };

                Connector conn7 = new Connector()
                { CCMId = 7, CompetitionId = comp1.Id, MUAsId = mua7.Id };

                Connector conn8 = new Connector()
                { CCMId = 8, CompetitionId = comp1.Id, MUAsId = mua8.Id };

                Connector conn9 = new Connector()
                { CCMId = 9, CompetitionId = comp1.Id, MUAsId = mua9.Id };

                Connector conn10 = new Connector()
                { CCMId = 10, CompetitionId = comp1.Id, MUAsId = mua11.Id };

                Connector conn11 = new Connector()
                { CCMId = 11, CompetitionId = comp1.Id, MUAsId = mua12.Id };

                Connector conn12 = new Connector()
                { CCMId = 12, CompetitionId = comp1.Id, MUAsId = mua13.Id };

                Connector conn13 = new Connector()
                { CCMId = 13, CompetitionId = comp1.Id, MUAsId = mua14.Id };

                Connector conn14 = new Connector()
                { CCMId = 14, CompetitionId = comp1.Id, MUAsId = mua15.Id };

                Connector conn15 = new Connector()
                { CCMId = 15, CompetitionId = comp1.Id, MUAsId = mua16.Id };

                Connector conn16 = new Connector()
                { CCMId = 16, CompetitionId = comp1.Id, MUAsId = mua17.Id };

                Connector conn17 = new Connector()
                { CCMId = 17, CompetitionId = comp2.Id, MUAsId = mua1.Id };

                Connector conn18 = new Connector()
                { CCMId = 18, CompetitionId = comp2.Id, MUAsId = mua2.Id };

                Connector conn19 = new Connector()
                { CCMId = 19, CompetitionId = comp2.Id, MUAsId = mua4.Id };

                Connector conn20 = new Connector()
                { CCMId = 20, CompetitionId = comp2.Id, MUAsId = mua5.Id };

                Connector conn21 = new Connector()
                { CCMId = 21, CompetitionId = comp2.Id, MUAsId = mua6.Id };

                Connector conn22 = new Connector()
                { CCMId = 22, CompetitionId = comp2.Id, MUAsId = mua7.Id };

                Connector conn23 = new Connector()
                { CCMId = 23, CompetitionId = comp2.Id, MUAsId = mua8.Id };

                Connector conn24 = new Connector()
                { CCMId = 24, CompetitionId = comp2.Id, MUAsId = mua9.Id };

                Connector conn25 = new Connector()
                { CCMId = 25, CompetitionId = comp2.Id, MUAsId = mua11.Id };

                Connector conn26 = new Connector()
                { CCMId = 26, CompetitionId = comp2.Id, MUAsId = mua12.Id };

                Connector conn27 = new Connector()
                { CCMId = 27, CompetitionId = comp2.Id, MUAsId = mua13.Id };

                Connector conn28 = new Connector()
                { CCMId = 28, CompetitionId = comp2.Id, MUAsId = mua14.Id };

                Connector conn29 = new Connector()
                { CCMId = 29, CompetitionId = comp2.Id, MUAsId = mua15.Id };

                Connector conn30 = new Connector()
                { CCMId = 30, CompetitionId = comp2.Id, MUAsId = mua16.Id };

                Connector conn31 = new Connector()
                { CCMId = 31, CompetitionId = comp2.Id, MUAsId = mua17.Id };

                Connector conn32 = new Connector()
                { CCMId = 32, CompetitionId = comp3.Id, MUAsId = mua1.Id };

                Connector conn33 = new Connector()
                { CCMId = 33, CompetitionId = comp3.Id, MUAsId = mua2.Id };

                Connector conn34 = new Connector()
                { CCMId = 34, CompetitionId = comp3.Id, MUAsId = mua3.Id };

                Connector conn35 = new Connector()
                { CCMId = 35, CompetitionId = comp3.Id, MUAsId = mua4.Id };

                Connector conn36 = new Connector()
                { CCMId = 36, CompetitionId = comp3.Id, MUAsId = mua5.Id };

                Connector conn37 = new Connector()
                { CCMId = 37, CompetitionId = comp3.Id, MUAsId = mua6.Id };

                Connector conn38 = new Connector()
                { CCMId = 38, CompetitionId = comp3.Id, MUAsId = mua7.Id };

                Connector conn39 = new Connector()
                { CCMId = 39, CompetitionId = comp3.Id, MUAsId = mua8.Id };

                Connector conn40 = new Connector()
                { CCMId = 40, CompetitionId = comp3.Id, MUAsId = mua9.Id };

                Connector conn41 = new Connector()
                { CCMId = 41, CompetitionId = comp3.Id, MUAsId = mua10.Id };

                Connector conn42 = new Connector()
                { CCMId = 42, CompetitionId = comp3.Id, MUAsId = mua11.Id };

                Connector conn43 = new Connector()
                { CCMId = 43, CompetitionId = comp3.Id, MUAsId = mua12.Id };

                Connector conn44 = new Connector()
                { CCMId = 44, CompetitionId = comp3.Id, MUAsId = mua13.Id };

                Connector conn45 = new Connector()
                { CCMId = 45, CompetitionId = comp3.Id, MUAsId = mua15.Id };

                Connector conn46 = new Connector()
                { CCMId = 46, CompetitionId = comp3.Id, MUAsId = mua16.Id };

                Connector conn47 = new Connector()
                { CCMId = 47, CompetitionId = comp3.Id, MUAsId = mua17.Id };

                Connector conn48 = new Connector()
                { CCMId = 48, CompetitionId = comp4.Id, MUAsId = mua1.Id };

                Connector conn49 = new Connector()
                { CCMId = 49, CompetitionId = comp4.Id, MUAsId = mua2.Id };

                Connector conn50 = new Connector()
                { CCMId = 50, CompetitionId = comp4.Id, MUAsId = mua3.Id };

                Connector conn51 = new Connector()
                { CCMId = 51, CompetitionId = comp4.Id, MUAsId = mua4.Id };

                Connector conn52 = new Connector()
                { CCMId = 52, CompetitionId = comp4.Id, MUAsId = mua5.Id };

                Connector conn53 = new Connector()
                { CCMId = 53, CompetitionId = comp4.Id, MUAsId = mua6.Id };

                Connector conn54 = new Connector()
                { CCMId = 54, CompetitionId = comp4.Id, MUAsId = mua7.Id };

                Connector conn55 = new Connector()
                { CCMId = 55, CompetitionId = comp4.Id, MUAsId = mua8.Id };

                Connector conn56 = new Connector()
                { CCMId = 56, CompetitionId = comp4.Id, MUAsId = mua9.Id };

                Connector conn57 = new Connector()
                { CCMId = 57, CompetitionId = comp4.Id, MUAsId = mua10.Id };

                Connector conn58 = new Connector()
                { CCMId = 58, CompetitionId = comp4.Id, MUAsId = mua11.Id };

                Connector conn59 = new Connector()
                { CCMId = 59, CompetitionId = comp4.Id, MUAsId = mua12.Id };

                Connector conn60 = new Connector()
                { CCMId = 60, CompetitionId = comp4.Id, MUAsId = mua13.Id };

                Connector conn61 = new Connector()
                { CCMId = 61, CompetitionId = comp4.Id, MUAsId = mua14.Id };

                Connector conn62 = new Connector()
                { CCMId = 62, CompetitionId = comp4.Id, MUAsId = mua15.Id };

                Connector conn63 = new Connector()
                { CCMId = 63, CompetitionId = comp4.Id, MUAsId = mua16.Id };

                Connector conn64 = new Connector()
                { CCMId = 64, CompetitionId = comp4.Id, MUAsId = mua17.Id };

                Connector conn65 = new Connector()
                { CCMId = 65, CompetitionId = comp5.Id, MUAsId = mua1.Id };

                Connector conn66 = new Connector()
                { CCMId = 66, CompetitionId = comp5.Id, MUAsId = mua2.Id };

                Connector conn67 = new Connector()
                { CCMId = 67, CompetitionId = comp5.Id, MUAsId = mua3.Id };

                Connector conn68 = new Connector()
                { CCMId = 68, CompetitionId = comp5.Id, MUAsId = mua4.Id };

                Connector conn69 = new Connector()
                { CCMId = 69, CompetitionId = comp5.Id, MUAsId = mua5.Id };

                Connector conn70 = new Connector()
                { CCMId = 70, CompetitionId = comp5.Id, MUAsId = mua6.Id };

                Connector conn71 = new Connector()
                { CCMId = 71, CompetitionId = comp5.Id, MUAsId = mua7.Id };

                Connector conn72 = new Connector()
                { CCMId = 72, CompetitionId = comp5.Id, MUAsId = mua8.Id };

                Connector conn73 = new Connector()
                { CCMId = 73, CompetitionId = comp5.Id, MUAsId = mua10.Id };

                Connector conn74 = new Connector()
                { CCMId = 74, CompetitionId = comp5.Id, MUAsId = mua11.Id };

                Connector conn75 = new Connector()
                { CCMId = 75, CompetitionId = comp5.Id, MUAsId = mua12.Id };

                Connector conn76 = new Connector()
                { CCMId = 76, CompetitionId = comp5.Id, MUAsId = mua13.Id };

                Connector conn77 = new Connector()
                { CCMId = 77, CompetitionId = comp5.Id, MUAsId = mua14.Id };

                Connector conn78 = new Connector()
                { CCMId = 78, CompetitionId = comp5.Id, MUAsId = mua15.Id };

                Connector conn79 = new Connector()
                { CCMId = 79, CompetitionId = comp5.Id, MUAsId = mua16.Id };

                Connector conn80 = new Connector()
                { CCMId = 80, CompetitionId = comp5.Id, MUAsId = mua17.Id };

                Connector conn81 = new Connector()
                { CCMId = 81, CompetitionId = comp6.Id, MUAsId = mua1.Id };

                Connector conn82 = new Connector()
                { CCMId = 82, CompetitionId = comp6.Id, MUAsId = mua3.Id };

                Connector conn83 = new Connector()
                { CCMId = 83, CompetitionId = comp6.Id, MUAsId = mua4.Id };

                Connector conn84 = new Connector()
                { CCMId = 84, CompetitionId = comp6.Id, MUAsId = mua5.Id };

                Connector conn85 = new Connector()
                { CCMId = 85, CompetitionId = comp6.Id, MUAsId = mua6.Id };

                Connector conn86 = new Connector()
                { CCMId = 86, CompetitionId = comp6.Id, MUAsId = mua7.Id };

                Connector conn87 = new Connector()
                { CCMId = 87, CompetitionId = comp6.Id, MUAsId = mua8.Id };

                Connector conn88 = new Connector()
                { CCMId = 88, CompetitionId = comp6.Id, MUAsId = mua9.Id };

                Connector conn89 = new Connector()
                { CCMId = 89, CompetitionId = comp6.Id, MUAsId = mua11.Id };

                Connector conn90 = new Connector()
                { CCMId = 90, CompetitionId = comp6.Id, MUAsId = mua12.Id };

                Connector conn91 = new Connector()
                { CCMId = 91, CompetitionId = comp6.Id, MUAsId = mua13.Id };

                Connector conn92 = new Connector()
                { CCMId = 92, CompetitionId = comp6.Id, MUAsId = mua14.Id };

                Connector conn93 = new Connector()
                { CCMId = 93, CompetitionId = comp6.Id, MUAsId = mua15.Id };

                Connector conn94 = new Connector()
                { CCMId = 94, CompetitionId = comp6.Id, MUAsId = mua16.Id };

                Connector conn95 = new Connector()
                { CCMId = 95, CompetitionId = comp6.Id, MUAsId = mua17.Id };

                Connector conn96 = new Connector()
                { CCMId = 96, CompetitionId = comp7.Id, MUAsId = mua1.Id };

                Connector conn97 = new Connector()
                { CCMId = 97, CompetitionId = comp7.Id, MUAsId = mua2.Id };

                Connector conn98 = new Connector()
                { CCMId = 98, CompetitionId = comp7.Id, MUAsId = mua3.Id };

                Connector conn99 = new Connector()
                { CCMId = 99, CompetitionId = comp7.Id, MUAsId = mua4.Id };

                Connector conn100 = new Connector()
                { CCMId = 100, CompetitionId = comp7.Id, MUAsId = mua5.Id };

                Connector conn101 = new Connector()
                { CCMId = 101, CompetitionId = comp7.Id, MUAsId = mua6.Id };

                Connector conn102 = new Connector()
                { CCMId = 102, CompetitionId = comp7.Id, MUAsId = mua7.Id };

                Connector conn103 = new Connector()
                { CCMId = 103, CompetitionId = comp7.Id, MUAsId = mua8.Id };

                Connector conn104 = new Connector()
                { CCMId = 104, CompetitionId = comp7.Id, MUAsId = mua9.Id };

                Connector conn105 = new Connector()
                { CCMId = 105, CompetitionId = comp7.Id, MUAsId = mua10.Id };

                Connector conn106 = new Connector()
                { CCMId = 106, CompetitionId = comp7.Id, MUAsId = mua11.Id };

                Connector conn107 = new Connector()
                { CCMId = 107, CompetitionId = comp7.Id, MUAsId = mua12.Id };

                Connector conn108 = new Connector()
                { CCMId = 108, CompetitionId = comp7.Id, MUAsId = mua13.Id };

                Connector conn109 = new Connector()
                { CCMId = 109, CompetitionId = comp7.Id, MUAsId = mua14.Id };

                Connector conn110 = new Connector()
                { CCMId = 110, CompetitionId = comp7.Id, MUAsId = mua15.Id };

                Connector conn111 = new Connector()
                { CCMId = 111, CompetitionId = comp7.Id, MUAsId = mua16.Id };

                Connector conn112 = new Connector()
                { CCMId = 112, CompetitionId = comp7.Id, MUAsId = mua17.Id };

                Connector conn113 = new Connector()
                { CCMId = 113, CompetitionId = comp8.Id, MUAsId = mua1.Id };

                Connector conn114 = new Connector()
                { CCMId = 114, CompetitionId = comp8.Id, MUAsId = mua2.Id };

                Connector conn115 = new Connector()
                { CCMId = 115, CompetitionId = comp8.Id, MUAsId = mua3.Id };

                Connector conn116 = new Connector()
                { CCMId = 116, CompetitionId = comp8.Id, MUAsId = mua4.Id };

                Connector conn117 = new Connector()
                { CCMId = 117, CompetitionId = comp8.Id, MUAsId = mua5.Id };

                Connector conn118 = new Connector()
                { CCMId = 118, CompetitionId = comp8.Id, MUAsId = mua6.Id };

                Connector conn119 = new Connector()
                { CCMId = 119, CompetitionId = comp8.Id, MUAsId = mua7.Id };

                Connector conn120 = new Connector()
                { CCMId = 120, CompetitionId = comp8.Id, MUAsId = mua8.Id };

                Connector conn121 = new Connector()
                { CCMId = 121, CompetitionId = comp8.Id, MUAsId = mua10.Id };

                Connector conn122 = new Connector()
                { CCMId = 122, CompetitionId = comp8.Id, MUAsId = mua11.Id };

                Connector conn123 = new Connector()
                { CCMId = 123, CompetitionId = comp8.Id, MUAsId = mua12.Id };

                Connector conn124 = new Connector()
                { CCMId = 124, CompetitionId = comp8.Id, MUAsId = mua14.Id };

                Connector conn125 = new Connector()
                { CCMId = 125, CompetitionId = comp8.Id, MUAsId = mua15.Id };

                Connector conn126 = new Connector()
                { CCMId = 126, CompetitionId = comp8.Id, MUAsId = mua16.Id };

                Connector conn127 = new Connector()
                { CCMId = 127, CompetitionId = comp8.Id, MUAsId = mua17.Id };

                Connector conn128 = new Connector()
                { CCMId = 128, CompetitionId = comp9.Id, MUAsId = mua1.Id };

                Connector conn129 = new Connector()
                { CCMId = 129, CompetitionId = comp9.Id, MUAsId = mua2.Id };

                Connector conn130 = new Connector()
                { CCMId = 130, CompetitionId = comp9.Id, MUAsId = mua3.Id };

                Connector conn131 = new Connector()
                { CCMId = 131, CompetitionId = comp9.Id, MUAsId = mua4.Id };

                Connector conn132 = new Connector()
                { CCMId = 132, CompetitionId = comp9.Id, MUAsId = mua5.Id };

                Connector conn133 = new Connector()
                { CCMId = 133, CompetitionId = comp9.Id, MUAsId = mua6.Id };

                Connector conn134 = new Connector()
                { CCMId = 134, CompetitionId = comp9.Id, MUAsId = mua7.Id };

                Connector conn135 = new Connector()
                { CCMId = 135, CompetitionId = comp9.Id, MUAsId = mua8.Id };

                Connector conn136 = new Connector()
                { CCMId = 136, CompetitionId = comp9.Id, MUAsId = mua9.Id };

                Connector conn137 = new Connector()
                { CCMId = 137, CompetitionId = comp9.Id, MUAsId = mua10.Id };

                Connector conn138 = new Connector()
                { CCMId = 138, CompetitionId = comp9.Id, MUAsId = mua11.Id };

                Connector conn139 = new Connector()
                { CCMId = 139, CompetitionId = comp9.Id, MUAsId = mua13.Id };

                Connector conn140 = new Connector()
                { CCMId = 140, CompetitionId = comp9.Id, MUAsId = mua14.Id };

                Connector conn141 = new Connector()
                { CCMId = 141, CompetitionId = comp9.Id, MUAsId = mua15.Id };

                Connector conn142 = new Connector()
                { CCMId = 142, CompetitionId = comp9.Id, MUAsId = mua16.Id };

                Connector conn143 = new Connector()
                { CCMId = 143, CompetitionId = comp9.Id, MUAsId = mua17.Id };

                Connector conn144 = new Connector()
                { CCMId = 144, CompetitionId = comp10.Id, MUAsId = mua1.Id };

                Connector conn145 = new Connector()
                { CCMId = 145, CompetitionId = comp10.Id, MUAsId = mua3.Id };

                Connector conn146 = new Connector()
                { CCMId = 146, CompetitionId = comp10.Id, MUAsId = mua4.Id };

                Connector conn147 = new Connector()
                { CCMId = 147, CompetitionId = comp10.Id, MUAsId = mua5.Id };

                Connector conn148 = new Connector()
                { CCMId = 148, CompetitionId = comp10.Id, MUAsId = mua6.Id };

                Connector conn149 = new Connector()
                { CCMId = 149, CompetitionId = comp10.Id, MUAsId = mua7.Id };

                Connector conn150 = new Connector()
                { CCMId = 150, CompetitionId = comp10.Id, MUAsId = mua8.Id };

                Connector conn151 = new Connector()
                { CCMId = 151, CompetitionId = comp10.Id, MUAsId = mua9.Id };

                Connector conn152 = new Connector()
                { CCMId = 152, CompetitionId = comp10.Id, MUAsId = mua10.Id };

                Connector conn153 = new Connector()
                { CCMId = 153, CompetitionId = comp10.Id, MUAsId = mua11.Id };

                Connector conn154 = new Connector()
                { CCMId = 154, CompetitionId = comp10.Id, MUAsId = mua12.Id };

                Connector conn155 = new Connector()
                { CCMId = 155, CompetitionId = comp10.Id, MUAsId = mua13.Id };

                Connector conn156 = new Connector()
                { CCMId = 156, CompetitionId = comp10.Id, MUAsId = mua14.Id };

                Connector conn157 = new Connector()
                { CCMId = 157, CompetitionId = comp10.Id, MUAsId = mua15.Id };

                Connector conn158 = new Connector()
                { CCMId = 158, CompetitionId = comp10.Id, MUAsId = mua16.Id };

                Connector conn159 = new Connector()
                { CCMId = 159, CompetitionId = comp10.Id, MUAsId = mua17.Id };

                Connector conn160 = new Connector()
                { CCMId = 160, CompetitionId = comp11.Id, MUAsId = mua1.Id };

                Connector conn161 = new Connector()
                { CCMId = 161, CompetitionId = comp11.Id, MUAsId = mua2.Id };

                Connector conn162 = new Connector()
                { CCMId = 162, CompetitionId = comp11.Id, MUAsId = mua3.Id };

                Connector conn163 = new Connector()
                { CCMId = 163, CompetitionId = comp11.Id, MUAsId = mua4.Id };

                Connector conn164 = new Connector()
                { CCMId = 164, CompetitionId = comp11.Id, MUAsId = mua5.Id };

                Connector conn165 = new Connector()
                { CCMId = 165, CompetitionId = comp11.Id, MUAsId = mua6.Id };

                Connector conn166 = new Connector()
                { CCMId = 166, CompetitionId = comp11.Id, MUAsId = mua7.Id };

                Connector conn167 = new Connector()
                { CCMId = 167, CompetitionId = comp11.Id, MUAsId = mua8.Id };

                Connector conn168 = new Connector()
                { CCMId = 168, CompetitionId = comp11.Id, MUAsId = mua9.Id };

                Connector conn169 = new Connector()
                { CCMId = 169, CompetitionId = comp11.Id, MUAsId = mua10.Id };

                Connector conn170 = new Connector()
                { CCMId = 170, CompetitionId = comp11.Id, MUAsId = mua11.Id };

                Connector conn171 = new Connector()
                { CCMId = 171, CompetitionId = comp11.Id, MUAsId = mua12.Id };

                Connector conn172 = new Connector()
                { CCMId = 172, CompetitionId = comp11.Id, MUAsId = mua14.Id };

                Connector conn173 = new Connector()
                { CCMId = 173, CompetitionId = comp11.Id, MUAsId = mua15.Id };

                Connector conn174 = new Connector()
                { CCMId = 174, CompetitionId = comp11.Id, MUAsId = mua17.Id };

                modelBuilder.Entity<Competitions>().HasData(comp1, comp2, comp3, comp4, comp5, comp6, comp7, comp8, comp9, comp10, comp11);
                modelBuilder.Entity<Looks>().HasData(look1, look2, look3, look4, look5, look6, look7, look8, look9, look10, look11, look12, look13, look14, look15, look16, look17, look18, look19, look20, look21, look22);
                modelBuilder.Entity<MUAs>().HasData(mua1, mua2, mua3, mua4, mua5, mua6, mua7, mua8, mua9, mua10, mua11, mua12, mua13, mua14, mua15, mua16, mua17, mua18);
                modelBuilder.Entity<Connector>().HasData(conn1, conn2, conn3, conn4, conn5, conn6, conn7, conn8, conn9, conn10, conn11, conn12, conn13, conn14, conn15, conn16, conn17, conn18, conn19, conn20, conn21, conn22, conn23, conn24, conn25, conn26, conn27, conn28, conn29, conn30, conn31, conn32, conn33, conn34, conn35, conn36, conn37, conn38, conn39, conn40, conn41, conn42, conn43, conn44, conn45, conn46, conn47, conn48, conn49, conn50, conn51, conn52, conn53, conn54, conn55, conn56, conn57, conn58, conn59, conn60, conn61, conn62, conn63, conn64, conn65, conn66, conn67, conn68, conn69, conn70, conn71, conn72, conn73, conn74, conn75, conn76, conn77, conn78, conn79, conn80, conn81, conn82, conn83, conn84, conn85, conn86, conn87, conn88, conn89, conn90, conn91, conn92, conn93, conn94, conn95, conn96, conn97, conn98, conn99, conn100, conn101, conn102, conn103, conn104, conn105, conn106, conn107, conn108, conn109, conn110, conn111, conn112, conn113, conn114, conn115, conn116, conn117, conn118, conn119, conn120, conn121, conn122, conn123, conn124, conn125, conn126, conn127, conn128, conn129, conn130, conn131, conn132, conn133, conn134, conn135, conn136, conn137, conn138, conn139, conn140, conn141, conn142, conn143, conn144, conn145, conn146, conn147, conn148, conn149, conn150, conn151, conn152, conn153, conn154, conn155, conn156, conn157, conn158, conn159, conn160, conn161, conn162, conn163, conn164, conn165, conn166, conn167, conn168, conn169, conn170, conn171, conn172, conn173, conn174);
            }
            else
            {
                throw new Exception("The modelBuilder can't be null!");
            }
        }
    }
 }
    
