using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    public class ProgramUI
    {
        //This class will be how we interact with our user through the console. When we need to access our data, we will call methods from our Repo class.

        private DevTeamsRepo _repo = new DevTeamsRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            //Start with the main menu here
        }
    }
}
