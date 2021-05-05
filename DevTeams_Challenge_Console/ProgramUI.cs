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
            SeedContent();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            //Start with the main menu here
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option: \n" +
                         "1: Create new Developer\n" +
                         "2: View all Developer\n" +
                         "3: Update Developers\n" +
                         "4: Delete Developers\n" +
                         "5: Exit\n");
                
                switch(Console.ReadLine().ToLower())
                {
                    case "1":
                    case "one":
                        CreateDeveloper();
                            break;
                    case "2":
                    case "two":
                        ReadDeveloper();
                        break;
                    case "3":
                    case "three":
                        UpdateDeveloper();
                        break;
                    case "4":
                    case "four":
                        DeleteDeveloper();
                        break;
                    case "5":
                    case "five":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Try Again.");
                        break;
                }
            }
        }
        private void CreateDeveloper()
        {
            Console.Clear();
            Developer newdev = new Developer();

            Console.WriteLine("What is the developer's ID?");
            newdev.DevID = Convert.ToInt32(Console.ReadLine());

            // Asking the user for the developers first name and putting it in newDev object
            Console.WriteLine("What is the developer's first name?");
            newdev.FirstName = Console.ReadLine();

            Console.WriteLine("What is the developer's last name?");
            newdev.LastName = Console.ReadLine();

            // all devs have access to Pluralsight
            newdev.haveAccessed = true;

            Console.WriteLine("What is the developers assignement?\n" +
                "1. FrontEnd \n" +
                "2. BackEnd\n" +
                "3. Testing\n");

            newdev.assignment = (TeamAssignment)Convert.ToInt32(Console.ReadLine());

            bool wasAddedCorrectly = _repo.AddDevelopertoDirectory(newdev);

            if (wasAddedCorrectly)
                Console.WriteLine(newdev.FirstName +" "+ newdev.LastName+" was added correctly to the Repository.");
            else
                Console.WriteLine("Could not add the content.");
        }

        private void ReadDeveloper()
        {
            Console.Clear();
            List<Developer> AllDevs = _repo.GetDevelopers();

            foreach(Developer devs in AllDevs)
            {
                Console.WriteLine($"Developer ID: {devs.DevID}");
                Console.WriteLine($"Name: {devs.FirstName} {devs.LastName}");
                Console.WriteLine($"Has Pluralsight: {devs.haveAccessed}");
                Console.WriteLine($"Dev Assignment: {devs.assignment}");
            }
        }

        private void UpdateDeveloper()
        {
            Console.Clear();
            ReadDeveloper();

            Developer newdev = new Developer();

            Console.WriteLine("What is the new developer's old ID?");
            int oldId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the new developer's ID?");
            newdev.DevID = Convert.ToInt32(Console.ReadLine());

            // Asking the user for the developers first name and putting it in newDev object
            Console.WriteLine("What is the new developer's first name?");
            newdev.FirstName = Console.ReadLine();

            Console.WriteLine("What is the new developer's last name?");
            newdev.LastName = Console.ReadLine();

            // all devs have access to Pluralsight
            newdev.haveAccessed = true;

            Console.WriteLine("What is the developers new assignement?\n" +
                "1. FrontEnd \n" +
                "2. BackEnd\n" +
                "3. Testing\n");

            newdev.assignment = (TeamAssignment)Convert.ToInt32(Console.ReadLine());

            bool isUpdated = _repo.UpdateDevList(oldId, newdev);

            if(isUpdated)
                Console.WriteLine("Success!!");
            else
                Console.WriteLine("Update failed.");

        }

        private void DeleteDeveloper()
        {
            Console.Clear();
            ReadDeveloper();

            Console.WriteLine("Enter the Id of the Developer you want to Delete: ");
            bool wasDeleted = _repo.DeleteDev(Convert.ToInt32(Console.ReadLine()));

            if(wasDeleted)
            {
                Console.WriteLine("developer was deleted successfully.");
            }
            else
                Console.WriteLine("developer could not be deleted.");
        }

        private void SeedContent()
        {
            Developer dev1 = new Developer(12345, "Darth", "Vader", true, TeamAssignment.Testing);
            Developer dev2 = new Developer(16572, "Luke", "Skywalker", true, TeamAssignment.FrontEnd);
            Developer dev3 = new Developer(46582, "JarJar", "Binks", true, TeamAssignment.BackEnd);

            _repo.AddDevelopertoDirectory(dev1);
            _repo.AddDevelopertoDirectory(dev2);
            _repo.AddDevelopertoDirectory(dev3);
        }
    }
}
