using System;
using System.Collections.Generic;
using System.Linq;
using U4WM55_HFT_2021221.Models;
using U4WM55_HFT_2021221.Repository;
using U4WM55_HFT_2021221.Logic;
using Moq;
using NUnit.Framework;

namespace U4WM55_HFT_2021221.Test
{
    /// <summary>
    /// Testing the CreateMUA CRUD method.
    /// </summary>
    [TestFixture]
    public class ParticipantLogicTests
    {
        private Mock<IMUAsRepository> muaRepo;
        private Mock<IConnectorRepository> connRepo;
        private Mock<ICompetitionsRepository> compRepo;
        private List<GendersResult> expectedGendersResult;
        private List<SameCountryResult> expectedSameCountryResult;

        /// <summary>
        /// Testing CreateMUA method as a test for the Create/Insert CRUD methods.
        /// </summary>
        [Test]
        public void TestCreateMUA()
        {
            Mock<IMUAsRepository> mockMuaRepo = new Mock<IMUAsRepository>();
            Mock<IConnectorRepository> mockConnRepo = new Mock<IConnectorRepository>();
            Mock<ICompetitionsRepository> mockCompRepo = new Mock<ICompetitionsRepository>();

            mockMuaRepo.Setup(repo => repo.Insert(It.IsAny<MUAs>()));

            ParticipantLogic logic = new ParticipantLogic(mockMuaRepo.Object, mockConnRepo.Object, mockCompRepo.Object);

            MUAs newMua = new MUAs()
            {
                Id = 19,
                Name = "Berta Mach",
                Gender = "F",
                Country = "Hungary",
                ExperienceLvl = 8,
                Phone = 06204891245,
                Email = "bmachmua@gmail.com",
                Sponsor = "Guerlain",
                NumOfModels = 3,
                Points = 120,
            };

            logic.CreateMUA(
                newMua.Name,
                newMua.Gender,
                newMua.Country,
                newMua.ExperienceLvl,
                newMua.Phone,
                newMua.Email,
                newMua.Sponsor,
                newMua.NumOfModels,
                newMua.Points);
            logic.CreateMUA("Timothy Test", "M", "USA", 6, 45792417942, "ttestmua@gmail.com", "MAC", 2, 115);
            logic.CreateMUA("Sam Smith", "N", "Sweden", 5, 87533571900, "ssmithmua@gmail.com", "Lego", 1, 134);

            mockMuaRepo.Verify(repo => repo.Insert(It.IsAny<MUAs>()), Times.Exactly(3));
        }

        /// <summary>
        /// Testing Genders method as one of the NON-CRUD method tests.
        /// </summary>
        [Test]
        public void TestGenders()
        {
            var logic = this.CreateLogicWithMocks();
            var genders = logic.Genders();

            Assert.That(genders, Is.EquivalentTo(this.expectedGendersResult));
            //this.compRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.muaRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.connRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// Testing SameCountry method as one of the NON-CRUD method tests.
        /// </summary>
        [Test]
        public void TestSameCountry()
        {
            var logic = this.CreateLogicWithMocks();
            var sameCountry = logic.SameCountry();

            Assert.That(sameCountry, Is.EquivalentTo(this.expectedSameCountryResult));
            this.compRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.muaRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.connRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        private ParticipantLogic CreateLogicWithMocks()
        {
            this.muaRepo = new Mock<IMUAsRepository>();
            this.connRepo = new Mock<IConnectorRepository>();
            this.compRepo = new Mock<ICompetitionsRepository>();

            MUAs mua1 = new MUAs() { Id = 1, Name = "Anna Test", Gender = "F", Country = "Hungary", ExperienceLvl = 5, Phone = 0123456789, Email = "example@example.com", Sponsor = "MAC", NumOfModels = 2, Points = 100 };
            MUAs mua2 = new MUAs() { Id = 2, Name = "Bob Test", Gender = "M", Country = "Brazil", ExperienceLvl = 5, Phone = 0123456789, Email = "example@example.com", Sponsor = "MAC", NumOfModels = 2, Points = 100 };
            MUAs mua3 = new MUAs() { Id = 3, Name = "Chloe Test", Gender = "N", Country = "England", ExperienceLvl = 5, Phone = 0123456789, Email = "example@example.com", Sponsor = "MAC", NumOfModels = 2, Points = 100 };
            MUAs mua4 = new MUAs() { Id = 4, Name = "Dixi Test", Gender = "F", Country = "Hungary", ExperienceLvl = 5, Phone = 0123456789, Email = "example@example.com", Sponsor = "MAC", NumOfModels = 2, Points = 100 };
            MUAs mua5 = new MUAs() { Id = 5, Name = "Emmy Test", Gender = "N", Country = "Hungary", ExperienceLvl = 5, Phone = 0123456789, Email = "example@example.com", Sponsor = "MAC", NumOfModels = 2, Points = 100 };

            List<MUAs> muasList = new List<MUAs>() { mua1, mua2, mua3, mua4, mua5 };

            Competitions comp1 = new Competitions() { Id = 1, Place = "Hungary", Difficulty = 1, CompDate = new DateTime(2020, 05, 09), HowManyJudges = 3, HeadOfJury = "Me" };
            Competitions comp2 = new Competitions() { Id = 2, Place = "England", Difficulty = 1, CompDate = new DateTime(2020, 05, 09), HowManyJudges = 3, HeadOfJury = "Me" };
            Competitions comp3 = new Competitions() { Id = 3, Place = "Sweden", Difficulty = 1, CompDate = new DateTime(2020, 05, 09), HowManyJudges = 3, HeadOfJury = "Me" };

            List<Competitions> compsList = new List<Competitions>() { comp1, comp2, comp3 };

            Connector conn1 = new Connector() { CCMId = 1, CompetitionId = comp1.Id, Competitions = comp1, MUAsId = mua1.Id, MUAs = mua1 };
            Connector conn2 = new Connector() { CCMId = 2, CompetitionId = comp1.Id, Competitions = comp1, MUAsId = mua2.Id, MUAs = mua2 };
            Connector conn3 = new Connector() { CCMId = 3, CompetitionId = comp1.Id, Competitions = comp1, MUAsId = mua3.Id, MUAs = mua3 };
            Connector conn4 = new Connector() { CCMId = 4, CompetitionId = comp1.Id, Competitions = comp1, MUAsId = mua4.Id, MUAs = mua4 };
            Connector conn5 = new Connector() { CCMId = 5, CompetitionId = comp2.Id, Competitions = comp2, MUAsId = mua2.Id, MUAs = mua2 };
            Connector conn6 = new Connector() { CCMId = 6, CompetitionId = comp2.Id, Competitions = comp2, MUAsId = mua3.Id, MUAs = mua3 };
            Connector conn7 = new Connector() { CCMId = 7, CompetitionId = comp2.Id, Competitions = comp2, MUAsId = mua5.Id, MUAs = mua5 };
            Connector conn8 = new Connector() { CCMId = 8, CompetitionId = comp3.Id, Competitions = comp3, MUAsId = mua1.Id, MUAs = mua1 };
            Connector conn9 = new Connector() { CCMId = 9, CompetitionId = comp3.Id, Competitions = comp3, MUAsId = mua4.Id, MUAs = mua4 };
            Connector conn10 = new Connector() { CCMId = 10, CompetitionId = comp3.Id, Competitions = comp3, MUAsId = mua5.Id, MUAs = mua5 };

            List<Connector> connList = new List<Connector>() { conn1, conn2, conn3, conn4, conn5, conn6, conn7, conn8, conn9, conn10 };

            this.expectedGendersResult = new List<GendersResult>()
            {
                new GendersResult() { CompetitionID = comp1.Id, Gender = "F", Number = 2 },
                new GendersResult() { CompetitionID = comp1.Id, Gender = "M", Number = 1 },
                new GendersResult() { CompetitionID = comp1.Id, Gender = "N", Number = 1 },
                new GendersResult() { CompetitionID = comp2.Id, Gender = "M", Number = 1 },
                new GendersResult() { CompetitionID = comp2.Id, Gender = "N", Number = 2 },
                new GendersResult() { CompetitionID = comp3.Id, Gender = "F", Number = 2 },
                new GendersResult() { CompetitionID = comp3.Id, Gender = "N", Number = 1 },
            };

            this.expectedSameCountryResult = new List<SameCountryResult>()
            {
                new SameCountryResult() { MUACompID = comp1.Id, CompetitionPlace = "Hungary", MUAPlace = "Hungary", MUAVeryID = mua1.Id, MUAVeryName = "Anna Test" },
                new SameCountryResult() { MUACompID = comp1.Id, CompetitionPlace = "Hungary", MUAPlace = "Hungary", MUAVeryID = mua4.Id, MUAVeryName = "Dixi Test" },
                new SameCountryResult() { MUACompID = comp2.Id, CompetitionPlace = "England", MUAPlace = "England", MUAVeryID = mua3.Id, MUAVeryName = "Chloe Test" },
            };

            this.muaRepo.Setup(repo => repo.GetAll()).Returns(muasList.AsQueryable());
            this.connRepo.Setup(repo => repo.GetAll()).Returns(connList.AsQueryable());
            this.compRepo.Setup(repo => repo.GetAll()).Returns(compsList.AsQueryable());

            return new ParticipantLogic(this.muaRepo.Object, this.connRepo.Object, this.compRepo.Object);
        }
    }
}
