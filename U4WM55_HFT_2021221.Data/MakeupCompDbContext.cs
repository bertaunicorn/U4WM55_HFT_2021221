using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4WM55_HFT_2021221.Models
{
    class MakeupCompDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MakeupCompetitionDatabaseContext"/> class.
        /// </summary>
        public MakeupCompDbContext()
        {
            this.Database.EnsureCreated();
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
            }
        }
    }
}
