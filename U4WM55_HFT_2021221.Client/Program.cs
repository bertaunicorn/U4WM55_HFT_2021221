using ConsoleTools;
using System;
using System.Linq;
using U4WM55_HFT_2021221.Models;

namespace U4WM55_HFT_2021221.Client
{
    class Program
    {
        /// <summary>
        /// We will run methods in this.
        /// </summary>
        public static void Main()
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:54726");

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

            //var subMenuJuryChange = new ConsoleMenu()
            //    .Add(">> CHANGE A COMPETITION'S DIFFICULTY", () => ChangeCompDifficulty(juryLogic, statLogic))
            //    .Add(">> CHANGE A LOOK'S DIFFICULTY", () => ChangeLookDifficulty(juryLogic, statLogic))
            //    .Add(">> CHANGE A LOOK'S THEME", () => ChangeTheme(juryLogic, statLogic))
            //    .Add(">> BACK TO JURY MENU", ConsoleMenu.Close);

            //var subMenuJuryDelete = new ConsoleMenu()
            //    .Add(">> DELETE A COMPETITION", () => DeleteComp(juryLogic, statLogic))
            //    .Add(">> DELETE A MUA", () => DeleteMUA(juryLogic, statLogic))
            //    .Add(">> DELETE A MAKEUP LOOK", () => DeleteLook(juryLogic, statLogic))
            //    .Add(">> BACK TO JURY MENU", ConsoleMenu.Close);

            //var subMenuJuryCreate = new ConsoleMenu()
            //    .Add(">> CREATE A NEW COMPETITION", () => rest.Post<Competitions>(new Competitions(), "comp14")) //ez hogy lesz nem fixen 14 hanem beírt?
            //    .Add(">> CREATE A NEW MAKEUP LOOK", () => CreateLook(juryLogic))
            //    .Add(">> BACK TO JURY MENU", ConsoleMenu.Close);

            //var subMenuJury = new ConsoleMenu()
            //    .Add(">> DELETE", () => subMenuJuryDelete.Show())
            //    .Add(">> CHANGE", () => subMenuJuryChange.Show())
            //    .Add(">> CREATE", () => subMenuJuryCreate.Show())
            //    .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            //var subMenuParticipants = new ConsoleMenu()
            //    .Add(">> CHANGE A MUA'S NUMBER OF MODELS", () => ChangeNumOfModels(partLogic, statLogic))
            //    .Add(">> CHANGE A MUA'S EXPERIENCE LEVEL", () => UpgradeMUA(partLogic, statLogic))
            //    .Add(">> REGISTER NEW MUA", () => CreateMUA(partLogic))
            //    .Add(">> CREATE A NEW CONNECTION (adding a mua to a competition)", () => CreateConn(partLogic))
            //    .Add(">> DELETE A CONNECTION", () => DeleteConn(partLogic, statLogic))
            //    .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            //var subMenuQuerys = new ConsoleMenu()
            //    .Add(">> SAME COUNTRY FINDER", () => SameCountry(partLogic))
            //    .Add(">> GENDERS EVALUATION", () => Genders(partLogic))
            //    .Add(">> LOOK AT BRANDS", () => SponsorBrands(juryLogic))
            //    .Add(">> HOW MANY LOOKS", () => HowManyLooks(juryLogic))
            //    .Add(">> BACK TO MAIN MENU", ConsoleMenu.Close);

            //var menu = new ConsoleMenu()
            //    .Add("LIST ALL...", () => subMenuListAll.Show())
            //    .Add("FIND ONE...", () => subMenuFindOne.Show())
            //    .Add("OPTIONS FOR JURY MEMBERS", () => subMenuJury.Show())
            //    .Add("OPTIONS FOR PARTICIPANTS", () => subMenuParticipants.Show())
            //    .Add("INTERESTING STATS", () => subMenuQuerys.Show())
            //    .Add(">> FINISH", ConsoleMenu.Close);

            //menu.Show();

            //rest.Post<Brand>(new Brand()
            //{
            //    Name = "Peugeot"
            //}, "brand");

            //double avgprice = rest.GetSingle<double>("stat/avgprice");

            

            //var avgpricebybrands = rest
            //    .Get<KeyValuePair<string, double>>("stat/avgpricebybrands");

        }
    }
}
