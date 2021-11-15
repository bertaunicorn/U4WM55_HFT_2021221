using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using U4WM55_HFT_2021221.Repository;
using U4WM55_HFT_2021221.Models;
using Moq;
using U4WM55_HFT_2021221.Logic;

namespace U4WM55_HFT_2021221.Test
{
    /// <summary>
    /// Testing DeleteComp and ChangeTheme CRUD methods.
    /// </summary>
    [TestFixture]
    public class JuryLogicTests
    {
        private Mock<IMUAsRepository> muaRepo;
        private Mock<IConnectorRepository> connRepo;
        private Mock<ILooksRepository> lookRepo;
        private Mock<ICompetitionsRepository> compRepo;
        private List<SponsorBrandsResult> expectedSponsorBrandsResult;
        private List<HowManyLooksResult> expectedHowManyLooksResult;

        /// <summary>
        /// Testing DeleteComp method as a test for the Delete CRUD methods.
        /// </summary>
        [Test]
        public void TestDeleteComp()
        {
            Mock<ICompetitionsRepository> mockedCompRepo = new Mock<ICompetitionsRepository>();
            Mock<IMUAsRepository> mockedMuaRepo = new Mock<IMUAsRepository>();
            Mock<ILooksRepository> mockedLookRepo = new Mock<ILooksRepository>();
            Mock<IConnectorRepository> mockedConnRepo = new Mock<IConnectorRepository>();

            List<Competitions> comps = new List<Competitions>()
            {
                new Competitions() { Id = 1, Place = "Hungary", Difficulty = 5, CompDate = new DateTime(2020, 01, 11), HowManyJudges = 3, HeadOfJury = "Tombor Sarolta" },
                new Competitions() { Id = 2, Place = "Argentina", Difficulty = 2, CompDate = new DateTime(2020, 02, 08), HowManyJudges = 5, HeadOfJury = "Eva De Dominici" },
                new Competitions() { Id = 3, Place = "The Neatherlands", Difficulty = 7, CompDate = new DateTime(2020, 03, 14), HowManyJudges = 3, HeadOfJury = "Nikkie de Jager" },
                new Competitions() { Id = 4, Place = "France", Difficulty = 8, CompDate = new DateTime(2020, 04, 11), HowManyJudges = 7, HeadOfJury = "Jeanne Damas" },
                new Competitions() { Id = 5, Place = "Sweden", Difficulty = 4, CompDate = new DateTime(2020, 05, 09), HowManyJudges = 5, HeadOfJury = "Evelina Forsell" },
            };
            mockedCompRepo.Setup(repo => repo.GetAll()).Returns(comps.AsQueryable());
            mockedCompRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns(comps[2]);
            JuryLogic logic = new JuryLogic(mockedLookRepo.Object, mockedCompRepo.Object, mockedMuaRepo.Object, mockedConnRepo.Object);

            logic.DeleteComp(comps[2].Id);

            mockedCompRepo.Verify(repo => repo.Remove(comps[2].Id), Times.Once);
        }

        /// <summary>
        /// Testing ChangeTheme method as a test for the Update CRUD methods.
        /// </summary>
        [Test]
        public void TestChangeTheme()
        {
            Mock<ICompetitionsRepository> mockedCompRepo = new Mock<ICompetitionsRepository>();
            Mock<IMUAsRepository> mockedMuaRepo = new Mock<IMUAsRepository>();
            Mock<ILooksRepository> mockedLookRepo = new Mock<ILooksRepository>();
            Mock<IConnectorRepository> mockedConnRepo = new Mock<IConnectorRepository>();

            mockedLookRepo.Setup(repo => repo.ChangeTheme(It.IsAny<int>(), It.IsAny<string>()));
            JuryLogic logic = new JuryLogic(mockedLookRepo.Object, mockedCompRepo.Object, mockedMuaRepo.Object, mockedConnRepo.Object);
            logic.ChangeTheme(It.IsAny<int>(), "mockTheme");

            mockedLookRepo.Verify(repo => repo.ChangeTheme(It.IsAny<int>(), "mockTheme"), Times.Once);
        }

        /// <summary>
        /// Testing SponsorBrands method as one of the NON-CRUD method tests.
        /// </summary>
        [Test]
        public void TestSponsorBrands()
        {
            var logic = this.CreateLogicWithMocks();
            var sponsorBrands = logic.SponsorBrands();

            Assert.That(sponsorBrands, Is.EquivalentTo(this.expectedSponsorBrandsResult));
            this.lookRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.muaRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// Testing HowManyLooks method as one of the NON-CRUD method tests.
        /// </summary>
        [Test]
        public void TestHowManyLooks()
        {
            var logic = this.CreateLogicWithMocks();
            var howManyLooks = logic.HowManyLooks();

            Assert.That(howManyLooks, Is.EquivalentTo(this.expectedHowManyLooksResult));
            this.lookRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.compRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        private JuryLogic CreateLogicWithMocks()
        {
            this.muaRepo = new Mock<IMUAsRepository>();
            this.connRepo = new Mock<IConnectorRepository>();
            this.lookRepo = new Mock<ILooksRepository>();
            this.compRepo = new Mock<ICompetitionsRepository>();

            MUAs mua1 = new MUAs() { Id = 1, Name = "Anna Test", Gender = "F", Country = "Hungray", ExperienceLvl = 5, Phone = 0123456789, Email = "example@example.com", Sponsor = "MAC", NumOfModels = 2, Points = 100 };
            MUAs mua2 = new MUAs() { Id = 2, Name = "Betty Test", Gender = "F", Country = "Hungray", ExperienceLvl = 5, Phone = 0123456789, Email = "example@example.com", Sponsor = "YSL", NumOfModels = 2, Points = 100 };
            MUAs mua3 = new MUAs() { Id = 3, Name = "Cameron Test", Gender = "F", Country = "Hungray", ExperienceLvl = 5, Phone = 0123456789, Email = "example@example.com", Sponsor = "Apple", NumOfModels = 2, Points = 100 };

            List<MUAs> muasList = new List<MUAs>() { mua1, mua2, mua3 };

            Competitions comp1 = new Competitions() { Id = 1, Place = "Hungary", Difficulty = 1, CompDate = new DateTime(2020, 05, 09), HowManyJudges = 3, HeadOfJury = "Me" };
            Competitions comp2 = new Competitions() { Id = 2, Place = "Hungary", Difficulty = 1, CompDate = new DateTime(2020, 06, 09), HowManyJudges = 3, HeadOfJury = "Me" };
            Competitions comp3 = new Competitions() { Id = 3, Place = "Hungary", Difficulty = 1, CompDate = new DateTime(2020, 07, 09), HowManyJudges = 3, HeadOfJury = "Me" };

            List<Competitions> compsList = new List<Competitions>() { comp1, comp2, comp3 };

            Looks look1 = new Looks() { Id = 1, Theme = "fun", Brand = "MAC", Budget = 400, TimeFrame = 120, Difficulty = 2, CompId = comp1.Id };
            Looks look2 = new Looks() { Id = 2, Theme = "fun", Brand = "Glossier", Budget = 400, TimeFrame = 120, Difficulty = 2, CompId = comp1.Id };
            Looks look3 = new Looks() { Id = 3, Theme = "fun", Brand = "MAC", Budget = 400, TimeFrame = 120, Difficulty = 2, CompId = comp2.Id };
            Looks look4 = new Looks() { Id = 4, Theme = "fun", Brand = "YSL", Budget = 400, TimeFrame = 120, Difficulty = 2, CompId = comp2.Id };
            Looks look5 = new Looks() { Id = 5, Theme = "fun", Brand = "Bobbi Brown", Budget = 400, TimeFrame = 120, Difficulty = 2, CompId = comp2.Id };
            Looks look6 = new Looks() { Id = 6, Theme = "fun", Brand = "Revolution", Budget = 400, TimeFrame = 120, Difficulty = 2, CompId = comp3.Id };

            List<Looks> looksList = new List<Looks>() { look1, look2, look3, look4, look5, look6 };

            this.expectedHowManyLooksResult = new List<HowManyLooksResult>()
            {
                new HowManyLooksResult() { CompetitionID = comp1.Id, NumberOfLooks = 2 },
                new HowManyLooksResult() { CompetitionID = comp2.Id, NumberOfLooks = 3 },
                new HowManyLooksResult() { CompetitionID = comp3.Id, NumberOfLooks = 1 },
            };

            this.expectedSponsorBrandsResult = new List<SponsorBrandsResult>()
            {
                new SponsorBrandsResult() { MUAId = mua1.Id, MUAName = "Anna Test", MUASpon = "MAC", LookBrand = "MAC", LookID = look1.Id },
                new SponsorBrandsResult() { MUAId = mua1.Id, MUAName = "Anna Test", MUASpon = "MAC", LookBrand = "MAC", LookID = look3.Id },
                new SponsorBrandsResult() { MUAId = mua2.Id, MUAName = "Betty Test", MUASpon = "YSL", LookBrand = "YSL", LookID = look4.Id },
            };

            this.lookRepo.Setup(repo => repo.GetAll()).Returns(looksList.AsQueryable());
            this.compRepo.Setup(repo => repo.GetAll()).Returns(compsList.AsQueryable());
            this.muaRepo.Setup(repo => repo.GetAll()).Returns(muasList.AsQueryable());

            return new JuryLogic(this.lookRepo.Object, this.compRepo.Object, this.muaRepo.Object, this.connRepo.Object);
        }
    }
}
