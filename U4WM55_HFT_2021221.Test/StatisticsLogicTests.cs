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
    /// Testing GetOne and GetAll methods form the StatisticsLogic.
    /// </summary>
    [TestFixture]
    public class StatisticsLogicTests
    {
        /// <summary>
        /// Testing GetAllComps method as a test for the GetAll CRUD methods.
        /// </summary>
        [Test]
        public void TestGetAllComps()
        {
            Mock<ICompetitionsRepository> mockedCompRepo = new Mock<ICompetitionsRepository>(MockBehavior.Loose);
            Mock<IMUAsRepository> mockedMuaRepo = new Mock<IMUAsRepository>();
            Mock<ILooksRepository> mockedLookRepo = new Mock<ILooksRepository>();
            Mock<IConnectorRepository> mockedConnRepo = new Mock<IConnectorRepository>();

            List<Competitions> competitions = new List<Competitions>()
            {
                new Competitions() { Id = 1, Place = "Hungary", Difficulty = 5, CompDate = new DateTime(2020, 01, 11), HowManyJudges = 3, HeadOfJury = "Tombor Sarolta" },
                new Competitions() { Id = 2, Place = "Argentina", Difficulty = 2, CompDate = new DateTime(2020, 02, 08), HowManyJudges = 5, HeadOfJury = "Eva De Dominici" },
                new Competitions() { Id = 3, Place = "The Neatherlands", Difficulty = 7, CompDate = new DateTime(2020, 03, 14), HowManyJudges = 3, HeadOfJury = "Nikkie de Jager" },
                new Competitions() { Id = 4, Place = "France", Difficulty = 8, CompDate = new DateTime(2020, 04, 11), HowManyJudges = 7, HeadOfJury = "Jeanne Damas" },
                new Competitions() { Id = 5, Place = "Sweden", Difficulty = 4, CompDate = new DateTime(2020, 05, 09), HowManyJudges = 5, HeadOfJury = "Evelina Forsell" },
            };

            List<Competitions> expectedCompetitions = new List<Competitions>() { competitions[0], competitions[1], competitions[2], competitions[3], competitions[4] };
            mockedCompRepo.Setup(repo => repo.GetAll()).Returns(competitions.AsQueryable());

            StatisticsLogic logic = new StatisticsLogic(mockedCompRepo.Object, mockedLookRepo.Object, mockedMuaRepo.Object, mockedConnRepo.Object);

            var result = logic.GetAllComps();

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result.Select(x => x.Id), Does.Contain(1));
            Assert.That(result.Select(x => x.Id), Does.Contain(2));
            Assert.That(result.Select(x => x.Id), Does.Contain(3));
            Assert.That(result.Select(x => x.Id), Does.Contain(4));
            Assert.That(result.Select(x => x.Id), Does.Contain(5));
            Assert.That(result, Is.EquivalentTo(expectedCompetitions));

            mockedCompRepo.Verify(repo => repo.GetAll(), Times.Once);
            mockedCompRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Testing GetOneMUA method as a test for the GetOne  CRUD methods.
        /// </summary>
        [Test]
        public void TestGetOneMUA()
        {
            Mock<ICompetitionsRepository> mockedCompRepo = new Mock<ICompetitionsRepository>(MockBehavior.Loose);
            Mock<IMUAsRepository> mockedMuaRepo = new Mock<IMUAsRepository>();
            Mock<ILooksRepository> mockedLookRepo = new Mock<ILooksRepository>();
            Mock<IConnectorRepository> mockedConnRepo = new Mock<IConnectorRepository>();

            const int mockedId = 10;

            MUAs mockedMua = new MUAs()
            {
                Id = 10,
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

            mockedMuaRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns(mockedMua);
            StatisticsLogic logic = new StatisticsLogic(mockedCompRepo.Object, mockedLookRepo.Object, mockedMuaRepo.Object, mockedConnRepo.Object);

            MUAs foundMUA = logic.GetOneMUA(mockedId);
            MUAs testMUA = logic.GetOneMUA(mockedId);

            Assert.That(foundMUA, Is.EqualTo(mockedMua));
            Assert.That(foundMUA, Is.EqualTo(testMUA));

            mockedMuaRepo.Verify(repo => repo.GetOne(mockedId), Times.Exactly(4));
        }

        /// <summary>
        /// Testing GetOneLook method as a test for the GetOne CRUD methods.
        /// </summary>
        [Test]
        public void TestGetOneLook()
        {
            Mock<ICompetitionsRepository> mockedCompRepo = new Mock<ICompetitionsRepository>(MockBehavior.Loose);
            Mock<IMUAsRepository> mockedMuaRepo = new Mock<IMUAsRepository>();
            Mock<ILooksRepository> mockedLookRepo = new Mock<ILooksRepository>();
            Mock<IConnectorRepository> mockedConnRepo = new Mock<IConnectorRepository>();

            const int mockedId = 10;

            Looks mockedLook = new Looks()
            {
                Id = 10,
                Theme = "fires of hell",
                Brand = "Morphe",
                Budget = 400,
                TimeFrame = 90,
                Difficulty = 3,
                CompId = 4,
            };

            mockedLookRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns(mockedLook);
            StatisticsLogic logic = new StatisticsLogic(mockedCompRepo.Object, mockedLookRepo.Object, mockedMuaRepo.Object, mockedConnRepo.Object);

            Looks foundLook = logic.GetOneLook(mockedId);
            Looks testLook = logic.GetOneLook(mockedId);

            Assert.That(foundLook, Is.EqualTo(mockedLook));
            Assert.That(foundLook, Is.EqualTo(testLook));

            mockedLookRepo.Verify(repo => repo.GetOne(mockedId), Times.Exactly(4));
        }
    }
}
