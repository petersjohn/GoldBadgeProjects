
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

        public List<Badges> GetAllBadgesFromList()
        {
            return _badges;
        }


        public Dictionary<int, string> ReturnDictionary()
        {

            return (Dictionary<int, string>)badgeDictionary;
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


        public void UpdateDoorBadgeDoors(int badgeID, List<string> doors)
        {
            Badges badge = GetBadgeByBadgeID(badgeID);
            badge.Doors = doors;

        }

        public bool UpdateBadgeDic(int badgeID, Badges badge)
        {
            if (CheckDictionary(badgeID) == true)
            {
                badgeDictionary[badgeID] = badge;
                return true;
            }
            return false;
        }

        public void ClearBadgeValue(int badgeID)
        {
            if (CheckDictionary(badgeID) == true)
            {
                badgeDictionary[badgeID] = null;
            }
        }

        public void RemoveAllDoorsFromBadge(int badgeID)
        {
            Badges badge = GetBadgeByBadgeID(badgeID);
            badge.Doors = null;

        }
        //helper methods
        private bool CheckDictionary(int badgeID)
        {
            if (badgeDictionary.ContainsKey(badgeID))
            {
                return true;
            }
            return false;
        }

    }
}
