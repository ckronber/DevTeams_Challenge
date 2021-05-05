using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeamsRepo
    {
        //This is our Repository class that will hold our directory (which will act as our database) and methods that will directly talk to our directory.

        private List<Developer> _devDirectory = new List<Developer>();
        
        //Create function
        public bool AddDevelopertoDirectory(Developer newDeveloper)
        {
            int startingCount = _devDirectory.Count;
            _devDirectory.Add(newDeveloper);

            bool wasAdded = (_devDirectory.Count > startingCount) ? true : false;

            return wasAdded;
        }

        //Read function
        public List<Developer> GetDevelopers()
        {
            return _devDirectory;
        }

        //Get by Develper
        public Developer getDeveloperByID(int ID)
        {
            foreach(Developer dev in _devDirectory)
            {
                if (dev.DevID == ID)
                    return dev;
            }
            return null;
        }

        //Update Function
        public bool UpdateDevList(int devID,Developer devOld)
        {
            Developer devUpdated = getDeveloperByID(devID);

            if(devOld != null)
            {
                devUpdated.DevID = devOld.DevID;
                devUpdated.FirstName = devOld.FirstName;
                devUpdated.LastName = devOld.LastName;
                devUpdated.haveAccessed = devOld.haveAccessed;
                devUpdated.assignment = devOld.assignment;
                return true;
            }
            return false;
        }

        //Delete Function
        public bool DeleteDev(int ID)
        {
            Developer devToDelete = getDeveloperByID(ID);
            if(devToDelete == null)
                return false;
            else
            {
                _devDirectory.Remove(devToDelete);
                return true;
            }

        }
    }
}
