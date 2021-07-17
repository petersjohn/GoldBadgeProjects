
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
        public readonly IDictionary<int, Badges> badgeDictionary = new Dictionary<int, Badges>();

        public bool AddNewBadgeToList(Badges badge)
        {
            int sizeBefore = _badges.Count();
            _badges.Add(badge);
            int sizeAfter = _badges.Count();

            if (sizeAfter == (sizeBefore + 1))
            {
                return true;
            }
            return false;

        }

        public bool AddBadgeToDictionary(int badgeID, Badges badge)
        {
            if (CheckDictionary(badgeID) == false)
            {
                badgeDictionary.Add(badgeID, badge);
                return true;
            }
            return false;

        }


        //Read

        public bool CheckDictionary(int badgeID)
        {
            if (badgeDictionary.ContainsKey(badgeID))
            {
                return true;
            }
            return false;
        }


        public List<Badges> GetAllBadgesFromList()
        {
            return _badges;
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

        public bool UpdateBadgeDictionary(int badgeID, Badges badge)
        {

            if (CheckDictionary(badgeID) == true)
            {
                badgeDictionary[badgeID] = badge;
                return true;
            }
            return false;
        }

        public bool RemoveDoorsFromBadge(int badgeID, List<string> doorsToRemove)
        {
            Badges badge = GetBadgeByBadgeID(badgeID);
            int szBefore = badge.Doors.Count;

            for (int idx = 0; idx < doorsToRemove.Count(); idx++)
            {
                badge.Doors.Remove(doorsToRemove[idx]);
            }
            int szAfter = badge.Doors.Count();
            if (szBefore > szAfter)
            {
                return true;
            }
  
            return false;

        }

        public bool AddNewDoorsToBadge(int badgeID, List<string> doorsToAdd)
        {
            Badges badge = GetBadgeByBadgeID(badgeID);

            int szBefore;
            if (badge.Doors == null)
            {
                szBefore = 0;
            }
            else
            {
                szBefore = badge.Doors.Count();
            }

            for (int idx = 0; idx < doorsToAdd.Count(); idx++)
            {
                badge.Doors.Add(doorsToAdd[idx]);
            }
            int szAfter = badge.Doors.Count();
            if (szAfter > szBefore)
            {
                return true;
            }
            return false;
        }

        public bool AddBadgesToNullList(int badgeID, List<string> doors)
        {
            Badges badge = GetBadgeByBadgeID(badgeID);
            int szBefore;
            if (badge.Doors == null)
            {
                szBefore = 0;
            }
            else
            {
                szBefore = badge.Doors.Count();
            }

            badge.Doors = doors;
            int szAfter = badge.Doors.Count();
            if (szAfter > szBefore)
            {
                return true;
            }
            return false;



        }

        public bool RemoveAllDoorsFromBadge(int badgeID)
        {
            Badges badge = GetBadgeByBadgeID(badgeID);
            badge.Doors = null;
            if (badge.Doors == null)
            {
                return true;
            }
            return false;

        }


    }
}
