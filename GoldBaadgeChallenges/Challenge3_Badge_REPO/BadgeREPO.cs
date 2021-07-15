
using Challenge3_Badge_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Badge_REPO
{
    public class BadgeREPO
    {

        public readonly List<Badges> _badges = new List<Badges>();
        public readonly IDictionary<int, List<DoorList>> _doorAssignments = new Dictionary<int, List<DoorList>>();

        //Create


        public bool AddNewBadgeToList(Badges badge)
        {
            int sizeBefore = _badges.Count();
            _badges.Add(badge);
            int sizeAfter = _badges.Count();

            if (sizeAfter == (sizeAfter + 1))
            {
                return true;
            }
            return false;


        }

        public bool AddBadgeToDictionary(int badgeID, List<DoorList> doors)
        {
            //check to see if badge is already in the dictionary
            if (_doorAssignments.ContainsKey(badgeID))
            {
                return false;
            }
            else
            {
                _doorAssignments.Add(badgeID, doors);
                if (_doorAssignments.ContainsKey(badgeID))
                {
                    return true;
                }
            }
            return false;
        }

        //Read

        public List<Badges> GetAllBadgesFromList()
        {
            return _badges;
        }

       /* public string GetStringDoorsFromDictionary(int badgeID)
        {
            List<DoorList> _doors = _doorAssignments[badgeID];
            if (_doorAssignments.ContainsKey(badgeID))
            {
                string doorStr = "";
                foreach (DoorList doors in _doors)
                {

                    doorStr = doorStr + ", " + doors;

                }
                return doorStr;
            }
            return null;
        }*/

        public Dictionary<int, DoorList> ReturnDicitionary()
        {
            
            return (Dictionary<int, DoorList>)_doorAssignments;
        }

        public List<DoorList> GetListOfDoorsByKey(int badgeID)
        {
            if (_doorAssignments.ContainsKey(badgeID))
            {
                List<DoorList> _doors = _doorAssignments[badgeID];

                if (_doors != null)
                {
                    return _doors;
                }
                else
                {
                    return null;
                }
            }

            return null;

        }

        public Badges GetBadgeByBadgeID(int badgeID)
        {
            foreach (var badge in _badges)
            {
                if (badge.BadgeID == badgeID)
                {
                    return badge;
                }

            }
            return null;
        }

        //Update
        public void UpdateBadgeName(int badgeID, string fName, string lName)
        {
            Badges badge = GetBadgeByBadgeID(badgeID);
            badge.FirstName = fName;
            badge.LastName = lName;
        }

        public void UpdateDoorBadgeDoors(int badgeID, List<DoorList> doors)
        {
            Badges badge = GetBadgeByBadgeID(badgeID);
            badge.Doors = doors;

        }

        public bool UpdateBadgeDic(int badgeID, List<DoorList> doors)
        {
            if (_doorAssignments.ContainsKey(badgeID))
            {
                _doorAssignments[badgeID] = doors;
                return true;
            }
            return false;
        }

        public void RemoveAllDoorsFromDictKey(int badgeID)
        {
            _doorAssignments[badgeID] = null;
        }

        public void RemoveAllDoorsFromBadge(int badgeID)
        {
            Badges badge = GetBadgeByBadgeID(badgeID);
            badge.Doors = null;

        }
        


       
    }
}
