using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Badge_POCO
{
    public class Badges
    {

        public Badges() { }
        public Badges(int badgeID,  List<string> doors)
        {
            BadgeID = badgeID;
            Doors = doors;
        }
        
        public int BadgeID { get; set; }
        public string BadgeName { get; set; }

        
        public List<string> Doors { get; set; }
  
           
    }

   
}
