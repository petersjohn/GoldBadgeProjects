using Challenge3_Badge_POCO;
using Challenge3_Badge_REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3Badge_Console
{
    class BadgeUI
    {
        bool isRunning = true;

        private readonly BadgeREPO _repo = new BadgeREPO();



        public void Start()
        {
            CreateStartContent();
            RunMenu();

        }

        public void RunMenu()
        {
            while (isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }


        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine("Hello Security Admin, What would you like to do? \n" +
                "1) Create a new Badge \n" +
                "2) Update an existing badge \n" +
                "3) Display All Badges \n" +
                "4) Exit the Badge Admin System");


            string userInput = Console.ReadLine();
            return userInput;
        }
        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {

                case "1":
                    CreateNewBadge();
                    break;
                case "2":
                    UpdateBadge();
                    break;
                case "3":
                    DisplayAllBadges();
                    break;
                case "4":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Please enter a valid selection.");
                    PressAnyKeyToContinue();

                    return;
            }
        }



        private void CreateNewBadge()
        {
            List<string> doorList = new List<string>();
            int badgeID = GetValidIntegers();
            if (badgeID < 1)
            {
                IntegerError();
            }
            DisplayDoors();
            doorList = BuildDoorList();
            Badges badge = new Badges(badgeID, doorList);
            if (_repo.AddBadgeToDictionary(badgeID, badge) && _repo.AddNewBadgeToList(badge))
            {
                Console.WriteLine("Badge was succesfully added");

            }
            else
            {
                Console.WriteLine("Badge creation Failed.");

            }
            PressAnyKeyToContinue();

        }
        public List<string> BuildDoorList()

        {
            List<string> retList = new List<string>();
            bool keepGoing = true;
            int idx = 0;
            string doorValue;
            while (keepGoing)
            {
                idx++;
                if (idx == 1)
                {
                    doorValue = DoorPrompt();
                    if (ValidateAgainstStaticList(doorValue))
                    {
                        retList.Add(doorValue);
                    }
                    else
                    {
                        GenericError();
                    }
                }
                else
                {
                    if (WhileContinue())
                    {
                        doorValue = DoorPrompt();
                        if (!ValidateAgainstStaticList(doorValue) || IsDoorInList(doorValue, retList))
                        {
                            GenericError();
                            keepGoing = false;
                        }
                        else
                        {
                            retList.Add(doorValue);
                        }

                    }
                    else
                    {
                        keepGoing = false;
                    }
                }
            }
            return retList;
        }


        private void UpdateBadge()
        {
            DisplayAllBadges();
            Console.WriteLine("\n");
            int badgeID = GetValidIntegers();
            if (badgeID > 0)
            {
                if (ValidateBadgeID(badgeID))
                {
                    string userInput = UpdateMenu(badgeID);
                    OpenUpdateMenuItem(userInput, badgeID);
                }
            }

        }

        private bool ValidateBadgeID(int badgeID)
        {

            if (!_repo.badgeDictionary.ContainsKey(badgeID))
            {
                GenericError();

            }
            else
            {
                return true;
            }
            return false;

        }

        private string UpdateMenu(int badgeID)
        {
            Console.Clear();
            DisplayCurrentBadgeDoors(badgeID);
            Console.WriteLine("What would you like to do? \n" +
                "1) Remove a Door \n" +
                "2) Remove a ALL Doors from Badge \n" +
                "3) Add a Door \n" +
                "4) Cancel and Return to Main Menu");

            string userInput = Console.ReadLine();
            return userInput;

        }

        private void OpenUpdateMenuItem(string userInput, int badgeID)
        {
            Console.Clear();
            switch (userInput)
            {

                case "1":
                    RemoveDoorFromBadge(badgeID);
                    break;
                case "2":
                    RemoveAllDoorsFromBadge(badgeID);
                    break;
                case "3":
                    AddDoorToBadge(badgeID);
                    break;
                case "4":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection.");
                    PressAnyKeyToContinue();

                    return;
            }
        }

        private void RemoveDoorFromBadge(int badgeID)
        {
            Badges badge = _repo.GetBadgeByBadgeID(badgeID);
            DisplayCurrentBadgeDoors(badgeID);
            List<string> doorsToRemove = GetDoorsToRemove(badge);
            for (int idx = 0; idx < badge.Doors.Count(); idx++)
            {
                foreach (var door in doorsToRemove)
                {
                    if (door == badge.Doors[idx])
                    {
                        badge.Doors.Remove(door);
                    }
                }
            }
            _repo.UpdateBadgeDic(badgeID, badge);
        }

        private void AddDoorToBadge(int badgeID)
        {
            Badges badge = _repo.GetBadgeByBadgeID(badgeID);
            DisplayCurrentBadgeDoors(badgeID);
            List<string> doorsToAdd = GetDoorsToAdd(badge);
            for (int idx = 0; idx < doorsToAdd.Count(); idx++)
            {
                badge.Doors.Add(doorsToAdd[idx]);
            }

            _repo.UpdateBadgeDic(badgeID, badge);


        }

        private void RemoveAllDoorsFromBadge(int badgeID)
        {
            _repo.RemoveAllDoorsFromBadge(badgeID);

            Badges badge = _repo.GetBadgeByBadgeID(badgeID);
            if (badge.Doors == null)
            {
                _repo.UpdateBadgeDic(badgeID, badge);
                Console.WriteLine("Doors Successfully removed");
            }
            else
            {
                Console.WriteLine("Error removing all doors from badge");
            }

            PressAnyKeyToContinue();


        }

        private List<string> GetDoorsToAdd(Badges badge)
        {
            bool keepRunning = true;
            List<string> addList = new List<string>();
            while (keepRunning)
            {
                string doorToAdd = DoorPrompt().Trim();
                if (!IsDoorInList(doorToAdd, badge.Doors) && ValidateAgainstStaticList(doorToAdd))
                {
                    addList.Add(doorToAdd);
                    keepRunning = WhileContinue();

                }
                else
                {
                    Console.WriteLine("Door is already assigned to badge or the door is not valid.");
                    AnyKey();
                    keepRunning = WhileContinue();
                }
            }
            return addList;

        }

        private void DisplayCurrentBadgeDoors(int badgeID)
        {
            string doorsInBadgeObject = ("Badge Currently Accesses: ");
            string sDoor = "";
            Badges badge = _repo.GetBadgeByBadgeID(badgeID);
            for (int idx = 0; idx < badge.Doors.Count(); idx++)
            {
                if (idx < 1)
                {
                    doorsInBadgeObject = doorsInBadgeObject + badge.Doors[idx];
                }
                else
                {
                    sDoor = (", " + badge.Doors[idx]);
                    doorsInBadgeObject = (doorsInBadgeObject + sDoor);
                }
            }
            Console.WriteLine(doorsInBadgeObject);

        }
        private List<string> GetDoorsToRemove(Badges badge)
        {
            bool keepRunning = true;
            List<string> removeList = new List<string>();
            while (keepRunning)
            {
                string doorToRemove = DoorPrompt().Trim();
                if (IsDoorInList(doorToRemove, badge.Doors))
                {
                    removeList.Add(doorToRemove);
                    keepRunning = WhileContinue();

                }
                else
                {
                    Console.WriteLine("Door not found in badge details");
                    AnyKey();
                    keepRunning = WhileContinue();
                }
            }
            return removeList;

        }

        private void DisplayAllBadges()
        {
            Console.WriteLine("Badge #" + "\t" + "\t" + "Door Access");
            string badgeLine = "";
            string doorLine = "";
            foreach (var item in _repo.badgeDictionary)
            {
                badgeLine = $"{item.Key}" + "\t" + "\t";
                int i = 0;
                if (item.Value.Doors != null)
                {
                    foreach (var door in item.Value.Doors)
                    {
                        i++;
                        if (i == 1)
                        {
                            doorLine = door;
                        }
                        else
                        {
                            doorLine = doorLine + ", " + door;
                        }


                    }
                }

                badgeLine = badgeLine + doorLine;
                Console.WriteLine(badgeLine);
            }
            AnyKey();
        }
        public void IntegerError()
        {
            Console.WriteLine("BadgeID Must be a positive integer greater than 0");
            PressAnyKeyToContinue();
        }
        private int GetValidIntegers()
        {
            Console.WriteLine("Enter the Badge Number (Number must be greater than 0): ");
            string input = Console.ReadLine();
            int retVal = ValidateIntInput(input);
            return retVal;

        }

        private void DisplayDoors()
        {
            Console.Clear();
            Console.WriteLine("Avalable Doors: ");
            Doors.DisplayDoorList();

        }

        private string DoorPrompt()
        {
            Console.WriteLine("Enter the door name to add/remove: ");
            string input = Console.ReadLine().ToUpper();
            return input;
        }

        public int ValidateIntInput(string value)
        {
            int retVal;

            if (int.TryParse(value, out retVal))
            {
                return retVal;
            }
            return 0;

        }

        public bool ValidateAgainstStaticList(string value)
        {
            for (int idx = 0; idx < Doors._doorList.Count(); idx++)
            {
                if (value == Doors._doorList[idx])
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsDoorInList(string doorValue, List<string> list)
        {
            foreach (var item in list)
            {
                if (doorValue == item)
                {
                    return true;
                }

            }
            return false;
        }

        private bool WhileContinue() //maybe recycle this one?
        {
            Console.WriteLine("Would you like to do another (y/n)");
            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    GenericError();
                    return false;
            }
        }
        private int GetListSize(List<string> list)
        {
            int listSize = list.Count();
            return listSize;
        }

        private void GenericError()
        {
            Console.WriteLine("Error in input or input not found.");
            PressAnyKeyToContinue();
        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            RunMenu();
        }

        private void AnyKey()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
        private void CreateStartContent()
        {
            Doors._doorList.Add("A1");
            Doors._doorList.Add("A2");
            Doors._doorList.Add("A3");
            Doors._doorList.Add("A4");
            Doors._doorList.Add("A5");
            Doors._doorList.Add("B1");
            Doors._doorList.Add("B2");
            Doors._doorList.Add("B3");
            Doors._doorList.Add("B4");
            Doors._doorList.Add("B5");

            List<string> newList = new List<string>();
            newList.Add("A1");
            newList.Add("A2");
            newList.Add("A3");
            Badges badge1 = new Badges(1234, newList);
            _repo.AddNewBadgeToList(badge1);
            _repo.AddBadgeToDictionary(1234, badge1);


        }

    }
}
