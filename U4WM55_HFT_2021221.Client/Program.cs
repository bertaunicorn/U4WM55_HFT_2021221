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


        }
    }
}
