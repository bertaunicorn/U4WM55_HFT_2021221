using ConsoleTools;
using System;
using System.Linq;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Client
{
    class Program
    {
        public static RestService rest = new RestService("http://localhost:54726");

        /// <summary>
        /// We will run methods in this.
        /// </summary>
        public static void Main()
        {
            System.Threading.Thread.Sleep(8000);

            var subMenuListAll = new ConsoleMenu()
                .Add(">> LIST ALL COMPETITIONS", () => rest.Get<Competitions>("comps"))
                .Add(">> LIST ALL LOOKS", () => rest.Get<Looks>("looks"))
                .Add(">> LIST ALL MUAs", () => rest.Get<MUAs>("muas"))
                .Add(">> LIST ALL CONNECTIONS", () => rest.Get<Connector>("conns"))
                .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            var subMenuFindOne = new ConsoleMenu()
                .Add(">> FIND ONE COMPETITION", () => rest.GetSingle<Competitions>("comp"))
                .Add(">> FIND ONE LOOK", () => rest.GetSingle<Looks>("look"))
                .Add(">> FIND ONE MUA", () => rest.GetSingle<MUAs>("mua"))
                .Add(">> FIND ONE CONNECTION", () => rest.GetSingle<Connector>("conn"))
                .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            var subMenuJuryChange = new ConsoleMenu()
                //.Add(">> CHANGE A COMPETITION'S DIFFICULTY", () => ChangeCompDifficulty())
                //.Add(">> CHANGE A LOOK'S DIFFICULTY", () => ChangeLookDifficulty())
                //.Add(">> CHANGE A LOOK'S THEME", () => ChangeTheme())
                .Add(">> BACK TO JURY MENU", ConsoleMenu.Close);

            var subMenuJuryDelete = new ConsoleMenu()
                .Add(">> DELETE A COMPETITION", () => DeleteComp())
                .Add(">> DELETE A MUA", () => DeleteMUA())
                .Add(">> DELETE A MAKEUP LOOK", () => DeleteLook())
                .Add(">> BACK TO JURY MENU", ConsoleMenu.Close);

            var subMenuJuryCreate = new ConsoleMenu()
                .Add(">> CREATE A NEW COMPETITION", () => CreateComp())
                .Add(">> CREATE A NEW MAKEUP LOOK", () => CreateLook())
                .Add(">> BACK TO JURY MENU", ConsoleMenu.Close);

            var subMenuJury = new ConsoleMenu()
                .Add(">> DELETE", () => subMenuJuryDelete.Show())
                .Add(">> CHANGE", () => subMenuJuryChange.Show())
                .Add(">> CREATE", () => subMenuJuryCreate.Show())
                .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            var subMenuParticipants = new ConsoleMenu()
                //.Add(">> CHANGE A MUA'S NUMBER OF MODELS", () => ChangeNumOfModels())
                //.Add(">> CHANGE A MUA'S EXPERIENCE LEVEL", () => UpgradeMUA())
                .Add(">> REGISTER NEW MUA", () => CreateMUA())
                .Add(">> CREATE A NEW CONNECTION (adding a mua to a competition)", () => CreateConn())
                .Add(">> DELETE A CONNECTION", () => DeleteConn())
                .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            var subMenuQuerys = new ConsoleMenu()
                //.Add(">> SAME COUNTRY FINDER", () => SameCountry())
                //.Add(">> GENDERS EVALUATION", () => Genders())
                //.Add(">> LOOK AT BRANDS", () => SponsorBrands())
                //.Add(">> HOW MANY LOOKS", () => HowManyLooks())
                .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            var menu = new ConsoleMenu()
                .Add("LIST ALL...", () => subMenuListAll.Show())
                .Add("FIND ONE...", () => subMenuFindOne.Show())
                .Add("OPTIONS FOR JURY MEMBERS", () => subMenuJury.Show())
                .Add("OPTIONS FOR PARTICIPANTS", () => subMenuParticipants.Show())
                .Add("INTERESTING STATS", () => subMenuQuerys.Show())
                .Add(">> FINISH", ConsoleMenu.Close);

            menu.Show();

            //double avgprice = rest.GetSingle<double>("stat/avgprice");

        }

        //private static void ChangeCompDifficulty()
        //{
        //    Console.WriteLine("\n:: CHANGE THE DIFFICULTY OF A COMPETITION ::\n");

        //    Console.WriteLine("Which competition's difficulty do you want to change? Give me an ID number!");
        //    try
        //    {
        //        int id = int.Parse(Console.ReadLine());
        //        Console.WriteLine("What do you want the new difficulty to be? It must be between 1 and 10! (Can be 1 and 10 as well)");
        //        int newCompDiff = int.Parse(Console.ReadLine());
        //        juryLogic.ChangeCompDifficulty(id, newCompDiff);
        //        Console.WriteLine(statisticsLogic.GetOneComp(id).ToString());
        //        Console.ReadLine();
        //    }
        //    catch (InvalidOperationException invalid)
        //    {
        //        Console.WriteLine(invalid.Message);
        //        Console.WriteLine("Try again!");
        //        Console.ReadLine();
        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.ReadLine();
        //    }
        //}

        //private static void ChangeLookDifficulty()
        //{
        //    Console.WriteLine("\n:: CHANGE THE DIFFICULTY OF A LOOK ::\n");
        //    try
        //    {
        //        Console.WriteLine("Which look's difficulty do you want to change? Give me an ID number!");
        //        int id = int.Parse(Console.ReadLine());
        //        Console.WriteLine("What do you want the new difficulty to be? It must be between 1 and 5!  (Can be 1 and 5 as well)");
        //        int newLookDiff = int.Parse(Console.ReadLine());
        //        juryLogic.ChangeLookDifficulty(id, newLookDiff);
        //        Console.WriteLine(statisticsLogic.GetOneLook(id).ToString());
        //        Console.ReadLine();
        //    }
        //    catch (InvalidOperationException invalid)
        //    {
        //        Console.WriteLine(invalid.Message);
        //        Console.WriteLine("Try again!");
        //        Console.ReadLine();
        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.ReadLine();
        //    }
        //}

        //private static void ChangeTheme()
        //{
        //    Console.WriteLine("\n:: CHANGE THE THEME OF A LOOK ::\n");

        //    try
        //    {
        //        Console.WriteLine("Which look's theme do you want to change? Give me an ID number!");
        //        int id = int.Parse(Console.ReadLine());
        //        Console.WriteLine("What do you want the new theme to be?");
        //        string newTheme = Console.ReadLine();
        //        juryLogic.ChangeTheme(id, newTheme);
        //        Console.WriteLine(statisticsLogic.GetOneLook(id).ToString());
        //        Console.ReadLine();
        //    }
        //    catch (InvalidOperationException invalid)
        //    {
        //        Console.WriteLine(invalid.Message);
        //        Console.WriteLine("Try again!");
        //        Console.ReadLine();
        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.ReadLine();
        //    }
        //}

        private static void DeleteComp()
        {
            Console.WriteLine("\n:: DELETE AN UNWANTED COMPETITION ::\n");

            Console.WriteLine("Please give me the ID of the competition you wish to delete!");
            int deleteId = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine("This is the competition you wish to delete: " + deleteId.ToString()
                + " Are you sure you want to DELETE it? Please press y/n to indicate!");
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    rest.Delete(deleteId, "compToDelete");
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

        private static void DeleteMUA()
        {
            Console.WriteLine("\n:: DELETE AN UNWANTED PARTICIPANT ::\n");

            Console.WriteLine("Please give me the ID of the MUA you wish to delete!");
            int deleteId = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine("This is the MUA you wish to delete: " + deleteId.ToString()
               + " Are you sure you want to DELETE them? Please press y/n to indicate!");
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    rest.Delete(deleteId, "muaToDelete");
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

        private static void DeleteLook()
        {
            Console.WriteLine("\n:: DELETE AN UNWANTED MAKEUP LOOK ::\n");

            Console.WriteLine("Please give me the ID of the makeup look you wish to delete!");
            int deleteId = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine("This is the makeup look you wish to delete: " + deleteId.ToString()
                + " Are you sure you want to DELETE it? Please press y/n to indicate!");
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    rest.Delete(deleteId, "lookToDelete");
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

        private static void CreateComp()
        {
            Console.WriteLine("\n:: ADD A NEW COMPETITION ::\n");

            Competitions newComp = new Competitions();

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

            newComp.Place = place;
            newComp.Difficulty = difficulty;
            newComp.CompDate = compDate;
            newComp.HowManyJudges = howManyJudges;
            newComp.HeadOfJury = headOfJury;

            try
            {
                rest.Post<Competitions>(newComp, "newComp");
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

        private static void CreateLook()
        {
            Console.WriteLine("\n:: CREATE A NEW MAKEUP LOOK ::\n");

            Looks newLook = new Looks();

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

            newLook.Theme = theme;
            newLook.Brand = brand;
            newLook.Budget = budget;
            newLook.TimeFrame = timeFrame;
            newLook.Difficulty = difficulty;
            newLook.CompId = compId;

            try
            {
                rest.Post<Looks>(newLook, "newLook");
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

        //private static void ChangeNumOfModels()
        //{
        //    Console.WriteLine("\n:: CHANGE THE NUMBER OF MODELS FOR A PARTICIPANT ::\n");

        //    Console.WriteLine("Which MUA's numer of models do you want to change? Give me an ID number!");
        //    try
        //    {
        //        int id = int.Parse(Console.ReadLine());
        //        Console.WriteLine("What do you want the new number of models to be? It can be 1, 2 or 3.");
        //        int newNum = int.Parse(Console.ReadLine());
        //        participantLogic.ChangeNumOfModels(id, newNum);
        //        Console.WriteLine(statisticsLogic.GetOneMUA(id).ToString());
        //        Console.ReadLine();
        //    }
        //    catch (InvalidOperationException invalid)
        //    {
        //        Console.WriteLine(invalid.Message);
        //        Console.WriteLine("Try again!");
        //        Console.ReadLine();
        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.ReadLine();
        //    }
        //}

        //private static void UpgradeMUA()
        //{
        //    Console.WriteLine("\n:: CHANGE THE EXPERIENCE LEVEL OF A PARTICIPANT ::\n");

        //    Console.WriteLine("Which MUA's experience level do you want to upgrade? Give me an ID number!");
        //    try
        //    {
        //        int id = int.Parse(Console.ReadLine());
        //        Console.WriteLine("What do you want the new experience level to be? It must be between 1 and 10! (Can be 1 and 10 as well)");
        //        int newLvl = int.Parse(Console.ReadLine());
        //        participantLogic.UpgradeMUA(id, newLvl);
        //        Console.WriteLine(statisticsLogic.GetOneMUA(id).ToString());
        //        Console.ReadLine();
        //    }
        //    catch (InvalidOperationException invalid)
        //    {
        //        Console.WriteLine(invalid.Message);
        //        Console.WriteLine("Try again!");
        //        Console.ReadLine();
        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.ReadLine();
        //    }
        //}

        private static void CreateMUA()
        {
            Console.WriteLine("\n:: REGISTER A NEW PARTICIPANT ::\n");

            MUAs newMUA = new MUAs();

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

            newMUA.Name = name;
            newMUA.Gender = gender;
            newMUA.Country = country;
            newMUA.ExperienceLvl = experienceLvl;
            newMUA.Phone = phone;
            newMUA.Email = email;
            newMUA.Sponsor = sponsor;
            newMUA.NumOfModels = numOfModels;
            newMUA.Points = initialPoints;

            try
            {
                rest.Post<MUAs>(newMUA, "newMUA");
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

        private static void CreateConn()
        {
            Console.WriteLine("\n:: CREATE A NEW CONNECTION (ADDING MUA TO COMPETITION) ::\n");

            Connector newConn = new Connector();

            Console.WriteLine("Please tell me the ID of the competition to which you want to add a MUA to!");
            int compId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please tell me the ID of the MUA who you want to add to the competition!");
            int muaId = int.Parse(Console.ReadLine());

            newConn.CompetitionId = compId;
            newConn.MUAsId = muaId;

            try
            {
                rest.Post<Connector>(newConn, "newConn");
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

        private static void DeleteConn()
        {
            Console.WriteLine("\n:: DELETE AN UNWANTED CONNECTION ::\n");

            Console.WriteLine("Please give me the ID of the connection you wish to delete!");
            int deleteId = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine("This is the connection you wish to delete: " + deleteId.ToString()
                + " Are you sure you want to DELETE it? Please press y/n to indicate!");
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    rest.Delete(deleteId, "connToDelete");
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

        //var avgpricebybrands = rest
        //    .Get<KeyValuePair<string, double>>("stat/avgpricebybrands");

        //private static void SameCountry()
        //{
        //    Console.WriteLine("\n:: IS THERE A MUA FROM CURRENT COUNTRY ::\n");
        //    foreach (var item in rest.)
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ReadLine();
        //}

        //private static void Genders()
        //{
        //    Console.WriteLine("\n:: LISTING BY GENDER ::\n");
        //    foreach (var item in participantLogic.Genders())
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ReadLine();
        //}

        //private static void SponsorBrands()
        //{
        //    Console.WriteLine("\n:: BRANDS THAT ARE SPONSORING A LOOK AND A MUA ::\n");
        //    foreach (var item in juryLogic.SponsorBrands())
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ReadLine();
        //}

        //private static void HowManyLooks()
        //{
        //    Console.WriteLine("\n:: HOW MANY LOOKS ARE AT THE COMPETITIONS ::\n");
        //    foreach (var item in juryLogic.HowManyLooks())
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ReadLine();
        //}

    }
}
