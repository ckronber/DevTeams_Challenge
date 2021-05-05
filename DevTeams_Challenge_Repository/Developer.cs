using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public enum TeamAssignment { FrontEnd=1, BackEnd, Testing}
    public class Developer
    {
        //This is our POCO class. It will define our properties and constructors of our Developer objects.
        //Developer objects should have the following properties
        //ID
        public int DevID { get; set; }
        //FirstName
        public string FirstName { get; set; }
        //LastName
        public string LastName { get; set; }
        //a bool that shows whether they have access to the online learning tool Pluralsight.
        public bool haveAccessed { get; set; }
        //TeamAssignment - use the enum declared above this class
        public TeamAssignment assignment { get; set; }


        public Developer() { }

        public Developer(int devID, string FirstName, string LastName,bool haveAccessed,TeamAssignment assignment)
        {
            this.DevID = devID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.assignment = assignment;
            this.haveAccessed = haveAccessed;
        }
    }
}
