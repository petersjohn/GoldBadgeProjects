using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Badge_POCO
{
    public class Badges
    {
        //public readonly Dictionary<int, List<string>> _doorAssignments = new Dictionary<int, List<string>>();


        public Badges() { }
        public Badges(int badgeID,  List<DoorList> doors)
        {
            BadgeID = badgeID;
            Doors = doors;
        }
        
        public int BadgeID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<DoorList> Doors { get; set; }
  
           
    }

    public enum DoorList
    {
        A1,
        A2,
        A3,
        A4,
        A5,
        B1,
        B2,
        B3,
        B4,
        B5

    }
}
