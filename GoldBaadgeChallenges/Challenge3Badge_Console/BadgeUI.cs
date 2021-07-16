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
                "3) Exit the Badge Admin System");


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
                /*case "2":
                    UpdateBadge();
                    break;*/
                case "3":
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
            if(_repo.AddBadgeToDictionary(badgeID, badge) && _repo.AddNewBadgeToList(badge))
            {
                Console.WriteLine("Badge was succesfully added");
                PressAnyKeyToContinue();
            }
            else
            {
                Console.WriteLine("Badge creation Failed.");
                PressAnyKeyToContinue();
            }


        }

        

        public void IntegerError()
        {
            Console.WriteLine("BadgeID Must be a positive integer greater than 0");
            PressAnyKeyToContinue();
        }
        private int GetValidIntegers()
        {
            Console.WriteLine("Enter the Badge ID (ID must be greater than 0): ");
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

        public List<string> BuildDoorList()
        {
            List <string> retList = new List <string>();
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
                    if (AddContinue())
                    {
                        doorValue = DoorPrompt();
                        if (!ValidateAgainstStaticList(doorValue) || !IsDoorInList(doorValue, retList))
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

        private string DoorPrompt()
        {
            Console.WriteLine("Enter the door name: ");
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
            if (Doors._doorList.Contains(value))
            {
                return true;
            }
            return false;
        }

        private bool IsDoorInList(string doorValue, List<string> list)
        {
            if (list.Contains(doorValue))
            {
                return false;
            }
            return true;
        }

        private bool AddContinue()
        {
            Console.WriteLine("Would you like to add another (y/n)");
            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default :
                    GenericError();
                    return false;
            }
        }

        private void GenericError()
        {
            Console.WriteLine("Error in Input.");
            PressAnyKeyToContinue();
        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            RunMenu();
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
            
                

        }

    }
}
