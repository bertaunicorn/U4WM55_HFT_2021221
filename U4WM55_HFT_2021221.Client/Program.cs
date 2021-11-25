using ConsoleTools;
using System;
using System.Linq;
using U4WM55_HFT_2021221.Models;
using U4WM55_HFT_2021221.Repository;
using U4WM55_HFT_2021221.Logic;

namespace U4WM55_HFT_2021221.Client
{
    class Program
    {
        /// <summary>
        /// We will run methods in this.
        /// </summary>
        public static void Main()
        {
            MakeupCompDbContext context = new MakeupCompDbContext();
            CompetitionRepository compRepo = new CompetitionRepository(context);
            LooksRepository looksRepo = new LooksRepository(context);
            MUAsRepository muaRepo = new MUAsRepository(context);
            ConnectorRepository connRepo = new ConnectorRepository(context);
            StatisticsLogic statLogic = new StatisticsLogic(compRepo, looksRepo, muaRepo, connRepo);
            JuryLogic juryLogic = new JuryLogic(looksRepo, compRepo, muaRepo, connRepo);
            ParticipantLogic partLogic = new ParticipantLogic(muaRepo, connRepo, compRepo);

            var subMenuListAll = new ConsoleMenu()
                .Add(">> LIST ALL COMPETITIONS", () => GetAllComps(statLogic))
                .Add(">> LIST ALL LOOKS", () => GetAllLooks(statLogic))
                .Add(">> LIST ALL MUAs", () => GetAllMUAs(statLogic))
                .Add(">> LIST ALL CONNECTIONS", () => GetAllConn(statLogic))
                .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            var subMenuFindOne = new ConsoleMenu()
                .Add(">> FIND ONE COMPETITION", () => GetOneComp(statLogic))
                .Add(">> FIND ONE LOOK", () => GetOneLook(statLogic))
                .Add(">> FIND ONE MUA", () => GetOneMUA(statLogic))
                .Add(">> FIND ONE CONNECTION", () => GetOneConn(statLogic))
                .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            var subMenuJuryChange = new ConsoleMenu()
                .Add(">> CHANGE A COMPETITION'S DIFFICULTY", () => ChangeCompDifficulty(juryLogic, statLogic))
                .Add(">> CHANGE A LOOK'S DIFFICULTY", () => ChangeLookDifficulty(juryLogic, statLogic))
                .Add(">> CHANGE A LOOK'S THEME", () => ChangeTheme(juryLogic, statLogic))
                .Add(">> BACK TO JURY MENU", ConsoleMenu.Close);

            var subMenuJuryDelete = new ConsoleMenu()
                .Add(">> DELETE A COMPETITION", () => DeleteComp(juryLogic, statLogic))
                .Add(">> DELETE A MUA", () => DeleteMUA(juryLogic, statLogic))
                .Add(">> DELETE A MAKEUP LOOK", () => DeleteLook(juryLogic, statLogic))
                .Add(">> BACK TO JURY MENU", ConsoleMenu.Close);

            var subMenuJuryCreate = new ConsoleMenu()
                .Add(">> CREATE A NEW COMPETITION", () => CreateComp(juryLogic))
                .Add(">> CREATE A NEW MAKEUP LOOK", () => CreateLook(juryLogic))
                .Add(">> BACK TO JURY MENU", ConsoleMenu.Close);

            var subMenuJury = new ConsoleMenu()
                .Add(">> DELETE", () => subMenuJuryDelete.Show())
                .Add(">> CHANGE", () => subMenuJuryChange.Show())
                .Add(">> CREATE", () => subMenuJuryCreate.Show())
                .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            var subMenuParticipants = new ConsoleMenu()
                .Add(">> CHANGE A MUA'S NUMBER OF MODELS", () => ChangeNumOfModels(partLogic, statLogic))
                .Add(">> CHANGE A MUA'S EXPERIENCE LEVEL", () => UpgradeMUA(partLogic, statLogic))
                .Add(">> REGISTER NEW MUA", () => CreateMUA(partLogic))
                .Add(">> CREATE A NEW CONNECTION (adding a mua to a competition)", () => CreateConn(partLogic))
                .Add(">> DELETE A CONNECTION", () => DeleteConn(partLogic, statLogic))
                .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            var subMenuQuerysAsync = new ConsoleMenu()
                .Add(">> SAME COUNTRY FINDER", () => SameCountryAsync(partLogic))
                .Add(">> GENDERS EVALUATION", () => GendersAsync(partLogic))
                .Add(">> LOOK AT BRANDS", () => SponsorBrandsAsync(juryLogic))
                .Add(">> HOW MANY LOOKS", () => HowManyLooksAsync(juryLogic))
                .Add(">> BACK TO STATS MENU", ConsoleMenu.Close);

            var subMenuQuerysNormal = new ConsoleMenu()
                .Add(">> SAME COUNTRY FINDER", () => SameCountry(partLogic))
                .Add(">> GENDERS EVALUATION", () => Genders(partLogic))
                .Add(">> LOOK AT BRANDS", () => SponsorBrands(juryLogic))
                .Add(">> HOW MANY LOOKS", () => HowManyLooks(juryLogic))
                .Add(">> BACK TO STATS MENU", ConsoleMenu.Close);

            var subMenuQuerys = new ConsoleMenu()
                .Add(">> NORMAL VERSIONS", () => subMenuQuerysNormal.Show())
                .Add(">> ASYNC VERSIONS", () => subMenuQuerysAsync.Show())
                .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            var menu = new ConsoleMenu()
                .Add("LIST ALL...", () => subMenuListAll.Show())
                .Add("FIND ONE...", () => subMenuFindOne.Show())
                .Add("OPTIONS FOR JURY MEMBERS", () => subMenuJury.Show())
                .Add("OPTIONS FOR PARTICIPANTS", () => subMenuParticipants.Show())
                .Add("INTERESTING STATS", () => subMenuQuerys.Show())
                .Add(">> FINISH", ConsoleMenu.Close);

            menu.Show();
        }

        private static void GetAllComps(StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: LIST ALL ELEMENTS ::\n");
            statisticsLogic.GetAllComps().ToList().ForEach(x => Console.WriteLine(x.ToString() + "\n"));
            Console.ReadLine();
        }

        private static void GetAllLooks(StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: LIST ALL ELEMENTS ::\n");
            statisticsLogic.GetAllLooks().ToList().ForEach(x => Console.WriteLine(x.ToString() + "\n"));
            Console.ReadLine();
        }

        private static void GetAllMUAs(StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: LIST ALL ELEMENTS ::\n");
            statisticsLogic.GetAllMUAs().ToList().ForEach(x => Console.WriteLine(x.ToString() + "\n"));
            Console.ReadLine();
        }

        private static void GetAllConn(StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: LIST ALL ELEMENTS ::\n");
            statisticsLogic.GetAllConns().ToList().ForEach(x => Console.WriteLine(x.ToString() + "\n"));
            Console.ReadLine();
        }

        private static void GetOneComp(StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: FIND ONE ELEMENT ::\n");
            Console.WriteLine("Which competition do you want to find? Give me an ID number!");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine(statisticsLogic.GetOneComp(id).ToString());
            }
            catch (InvalidOperationException invalid)
            {
                Console.WriteLine(invalid.Message);
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        private static void GetOneLook(StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: FIND ONE ELEMENT ::\n");
            Console.WriteLine("Which look do you want to find? Give me an ID number!");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine(statisticsLogic.GetOneLook(id).ToString());
            }
            catch (InvalidOperationException invalid)
            {
                Console.WriteLine(invalid.Message);
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        private static void GetOneMUA(StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: FIND ONE ELEMENT ::\n");
            bool done = false;
            do
            {
                Console.WriteLine("Which makeup artist do you want to find? Give me an ID number!");
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine(statisticsLogic.GetOneMUA(id).ToString());
                    done = true;
                }
                catch (InvalidOperationException invalid)
                {
                    Console.WriteLine(invalid.Message);
                    Console.WriteLine("Try again!");
                    Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
            while (!done);

            Console.ReadLine();
        }

        private static void GetOneConn(StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: FIND ONE ELEMENT ::\n");
            bool done = false;
            do
            {
                Console.WriteLine("Which connection do you want to find? Give me an ID number!");
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine(statisticsLogic.GetOneConn(id).ToString());
                    done = true;
                }
                catch (InvalidOperationException invalid)
                {
                    Console.WriteLine(invalid.Message);
                    Console.WriteLine("Try again!");
                    Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
            while (!done);

            Console.ReadLine();
        }

        private static void ChangeLookDifficulty(JuryLogic juryLogic, StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: CHANGE THE DIFFICULTY OF A LOOK ::\n");
            try
            {
                Console.WriteLine("Which look's difficulty do you want to change? Give me an ID number!");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("What do you want the new difficulty to be? It must be between 1 and 5!  (Can be 1 and 5 as well)");
                int newLookDiff = int.Parse(Console.ReadLine());
                juryLogic.ChangeLookDifficulty(id, newLookDiff);
                Console.WriteLine(statisticsLogic.GetOneLook(id).ToString());
                Console.ReadLine();
            }
            catch (InvalidOperationException invalid)
            {
                Console.WriteLine(invalid.Message);
                Console.WriteLine("Try again!");
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void ChangeTheme(JuryLogic juryLogic, StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: CHANGE THE THEME OF A LOOK ::\n");

            try
            {
                Console.WriteLine("Which look's theme do you want to change? Give me an ID number!");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("What do you want the new theme to be?");
                string newTheme = Console.ReadLine();
                juryLogic.ChangeTheme(id, newTheme);
                Console.WriteLine(statisticsLogic.GetOneLook(id).ToString());
                Console.ReadLine();
            }
            catch (InvalidOperationException invalid)
            {
                Console.WriteLine(invalid.Message);
                Console.WriteLine("Try again!");
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void ChangeCompDifficulty(JuryLogic juryLogic, StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: CHANGE THE DIFFICULTY OF A COMPETITION ::\n");

            Console.WriteLine("Which competition's difficulty do you want to change? Give me an ID number!");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("What do you want the new difficulty to be? It must be between 1 and 10! (Can be 1 and 10 as well)");
                int newCompDiff = int.Parse(Console.ReadLine());
                juryLogic.ChangeCompDifficulty(id, newCompDiff);
                Console.WriteLine(statisticsLogic.GetOneComp(id).ToString());
                Console.ReadLine();
            }
            catch (InvalidOperationException invalid)
            {
                Console.WriteLine(invalid.Message);
                Console.WriteLine("Try again!");
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void ChangeNumOfModels(ParticipantLogic participantLogic, StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: CHANGE THE NUMBER OF MODELS FOR A PARTICIPANT ::\n");

            Console.WriteLine("Which MUA's numer of models do you want to change? Give me an ID number!");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("What do you want the new number of models to be? It can be 1, 2 or 3.");
                int newNum = int.Parse(Console.ReadLine());
                participantLogic.ChangeNumOfModels(id, newNum);
                Console.WriteLine(statisticsLogic.GetOneMUA(id).ToString());
                Console.ReadLine();
            }
            catch (InvalidOperationException invalid)
            {
                Console.WriteLine(invalid.Message);
                Console.WriteLine("Try again!");
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void UpgradeMUA(ParticipantLogic participantLogic, StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: CHANGE THE EXPERIENCE LEVEL OF A PARTICIPANT ::\n");

            Console.WriteLine("Which MUA's experience level do you want to upgrade? Give me an ID number!");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("What do you want the new experience level to be? It must be between 1 and 10! (Can be 1 and 10 as well)");
                int newLvl = int.Parse(Console.ReadLine());
                participantLogic.UpgradeMUA(id, newLvl);
                Console.WriteLine(statisticsLogic.GetOneMUA(id).ToString());
                Console.ReadLine();
            }
            catch (InvalidOperationException invalid)
            {
                Console.WriteLine(invalid.Message);
                Console.WriteLine("Try again!");
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void CreateMUA(ParticipantLogic participantLogic)
        {
            Console.WriteLine("\n:: REGISTER A NEW PARTICIPANT ::\n");

            Console.WriteLine("Please give me a full name!");
            string name = Console.ReadLine();
            Console.WriteLine("Please tell me the gender of the person using 1 character! (F = female, M = male, N = non-binary)");
            string gender = Console.ReadLine();
            Console.WriteLine("Please tell me the country where they are from!");
            string country = Console.ReadLine();
            Console.WriteLine("Please give me the experience level! (It has to be a number between 1 and 10, can be 1 and 10 as well.)");
            int experienceLvl = int.Parse(Console.ReadLine());
            Console.WriteLine("Please give me the mua's phone number! Use numbers only please!");
            long phone = long.Parse(Console.ReadLine());
            Console.WriteLine("Please give me the email address! (examplemua@gmail.com)");
            string email = Console.ReadLine();
            Console.WriteLine("Please tell me who is the sponsor of the mua!");
            string sponsor = Console.ReadLine();
            Console.WriteLine("Please tell me how many models does the mua you're registering have! (It can be 1, 2 or 3.) ");
            int numOfModels = int.Parse(Console.ReadLine());

            double initialPoints = 0;
            try
            {
                participantLogic.CreateMUA(name, gender, country, experienceLvl, phone, email, sponsor, numOfModels, initialPoints);
                Console.WriteLine("You registered the mua named " + name + ".");
                Console.ReadLine();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void DeleteMUA(JuryLogic juryLogic, StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: DELETE AN UNWANTED PARTICIPANT ::\n");

            Console.WriteLine("Please give me the ID of the MUA you wish to delete!");
            int deleteId = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine("This is the MUA you wish to delete: " + statisticsLogic.GetOneMUA(deleteId).ToString()
               + " Are you sure you want to DELETE them? Please press y/n to indicate!");
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    juryLogic.DeleteMUA(deleteId);
                    Console.WriteLine("Okay, I deleted mua number " + deleteId + ".");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Okay, I won't delete them.");
                    Console.ReadLine();
                }
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void CreateComp(JuryLogic juryLogic)
        {
            Console.WriteLine("\n:: ADD A NEW COMPETITION ::\n");

            Console.WriteLine("Please give me the country where the competition takes place!");
            string place = Console.ReadLine();
            Console.WriteLine("Please tell me how difficult do you want the competition to be! It must be a number between 1 and 10 (It can be 1 and 10 as well)");
            int difficulty = int.Parse(Console.ReadLine());
            Console.WriteLine("Please tell me when the competition will be! You should use the format (2020, 04, 11) without the parenthesis.");
            DateTime compDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please tell me how many judges will be giving points at this competition! It can be 3, 5 or 7.");
            int howManyJudges = int.Parse(Console.ReadLine());
            Console.WriteLine("Please tell me who will be the head of the jury!");
            string headOfJury = Console.ReadLine();

            try
            {
                juryLogic.CreateComp(place, difficulty, compDate, howManyJudges, headOfJury);
                Console.WriteLine("You created a new competition which will take place at " + place + " on " + compDate + ".");
                Console.ReadLine();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void DeleteComp(JuryLogic juryLogic, StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: DELETE AN UNWANTED COMPETITION ::\n");

            Console.WriteLine("Please give me the ID of the competition you wish to delete!");
            int deleteId = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine("This is the competition you wish to delete: " + statisticsLogic.GetOneComp(deleteId).ToString()
                + " Are you sure you want to DELETE it? Please press y/n to indicate!");
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    juryLogic.DeleteComp(deleteId);
                    Console.WriteLine("Okay, I deleted competition number " + deleteId + ".");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Okay, I won't delete them.");
                    Console.ReadLine();
                }
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void CreateLook(JuryLogic juryLogic)
        {
            Console.WriteLine("\n:: CREATE A NEW MAKEUP LOOK ::\n");

            Console.WriteLine("Please give me the theme of the look!");
            string theme = Console.ReadLine();
            Console.WriteLine("Please tell me the brand of the makeup the muas can use for this look!");
            string brand = Console.ReadLine();
            Console.WriteLine("Please tell me how much money can the muas spend on this look! You can just type in a number, it will be in USD.");
            int budget = int.Parse(Console.ReadLine());
            Console.WriteLine("Please tell me how long the muas can work on this look! You can just type in a number, it will be in minutes.");
            int timeFrame = int.Parse(Console.ReadLine());
            Console.WriteLine("Please tell me how difficult it will be to create this look! This number can be between 1 and 5 (it can be 1 and 5 as well).");
            int difficulty = int.Parse(Console.ReadLine());
            Console.WriteLine("Please tell me at which competition the muas will have to complete this look!  Give me an ID number!");
            int compId = int.Parse(Console.ReadLine());

            try
            {
                juryLogic.CreateLook(theme, brand, budget, timeFrame, difficulty, compId);
                Console.WriteLine("You created a new makeup look which will be in a " + theme + " theme and it will be " + difficulty + "/5 difficulty.");
                Console.ReadLine();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void DeleteLook(JuryLogic juryLogic, StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: DELETE AN UNWANTED MAKEUP LOOK ::\n");

            Console.WriteLine("Please give me the ID of the makeup look you wish to delete!");
            int deleteId = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine("This is the makeup look you wish to delete: " + statisticsLogic.GetOneLook(deleteId).ToString()
                + " Are you sure you want to DELETE it? Please press y/n to indicate!");
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    juryLogic.DeleteLook(deleteId);
                    Console.WriteLine("Okay, I deleted look number " + deleteId + ".");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Okay, I won't delete them.");
                    Console.ReadLine();
                }
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void CreateConn(ParticipantLogic participantLogic)
        {
            Console.WriteLine("\n:: CREATE A NEW CONNECTION (ADDING MUA TO COMPETITION) ::\n");

            Console.WriteLine("Please tell me the ID of the competition to which you want to add a MUA to!");
            int compId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please tell me the ID of the MUA who you want to add to the competition!");
            int muaId = int.Parse(Console.ReadLine());

            try
            {
                participantLogic.CreateConnection(compId, muaId);
                Console.WriteLine("You added the " + muaId + ". MUA to the " + compId + ". competition.");
                Console.ReadLine();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void DeleteConn(ParticipantLogic participantLogic, StatisticsLogic statisticsLogic)
        {
            Console.WriteLine("\n:: DELETE AN UNWANTED CONNECTION ::\n");

            Console.WriteLine("Please give me the ID of the connection you wish to delete!");
            int deleteId = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine("This is the connection you wish to delete: " + statisticsLogic.GetOneLook(deleteId).ToString()
                + " Are you sure you want to DELETE it? Please press y/n to indicate!");
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    participantLogic.DeleteConnection(deleteId);
                }
                else
                {
                    Console.WriteLine("Okay, I won't delete it.");
                    Console.ReadLine();
                }
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void SameCountry(ParticipantLogic participantLogic)
        {
            Console.WriteLine("\n:: IS THERE A MUA FROM CURRENT COUNTRY ::\n");
            foreach (var item in participantLogic.SameCountry())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void SameCountryAsync(ParticipantLogic participantLogic)
        {
            Console.WriteLine("\n:: (ASYNC) IS THERE A MUA FROM CURRENT COUNTRY ::\n");
            foreach (var item in participantLogic.SameCountryAsync().Result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void Genders(ParticipantLogic participantLogic)
        {
            Console.WriteLine("\n:: LISTING BY GENDER ::\n");
            foreach (var item in participantLogic.Genders())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void GendersAsync(ParticipantLogic participantLogic)
        {
            Console.WriteLine("\n:: (ASYNC) LISTING BY GENDER ::\n");
            foreach (var item in participantLogic.GendersAsync().Result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void SponsorBrands(JuryLogic juryLogic)
        {
            Console.WriteLine("\n:: BRANDS THAT ARE SPONSORING A LOOK AND A MUA ::\n");
            foreach (var item in juryLogic.SponsorBrands())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void SponsorBrandsAsync(JuryLogic juryLogic)
        {
            Console.WriteLine("\n:: (ASYNC) BRANDS THAT ARE SPONSORING A LOOK AND A MUA ::\n");
            foreach (var item in juryLogic.SponsorBrandsAsync().Result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void HowManyLooks(JuryLogic juryLogic)
        {
            Console.WriteLine("\n:: HOW MANY LOOKS ARE AT THE COMPETITIONS ::\n");
            foreach (var item in juryLogic.HowManyLooks())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void HowManyLooksAsync(JuryLogic juryLogic)
        {
            Console.WriteLine("\n:: (ASYNC) HOW MANY LOOKS ARE AT THE COMPETITIONS ::\n");
            foreach (var item in juryLogic.HowManyLooksAsync().Result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
