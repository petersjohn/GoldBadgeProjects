using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Badge_REPO
{
    public static class Doors
    {

        public readonly static List<string> _doorList;

         static Doors()
        {
            _doorList = new List<string>();
        }

        public static void DisplayDoorList()
        {
            foreach(var door in _doorList)
            {
                Console.WriteLine($"{door}");
            }
        }
         

    }
}
