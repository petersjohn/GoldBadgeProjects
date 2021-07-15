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
        private  IDictionary<int, List<DoorList>> repoDictionary = new Dictionary<int, List<DoorList>>();

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
                "1) See All Badges in List \n" +
                "2) See All Badges in Dictionary \n" +
                "3) Exit the Claim Queue System");


            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayAllBadges();
                    break;
                case "2":
                    DisplayMyDic();
                    break;
                case "3":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Please enter a valid selection.");
                    PressAnyKeyToContinue();

                    return;
            }
        }

        private void DisplayMyDic()//tee hee
        {
            Console.Clear();
            repoDictionary = _repo._doorAssignments;
            string displayStr;
            foreach (var item in repoDictionary)
            {
                displayStr = "";
                displayStr = ($"BadgeID: {item.Key} Door Access: ");
                int cnt = 0;
                foreach (var door in item.Value)
                {   
                    cnt++;
                    if(cnt > 1)
                    {
                        displayStr = displayStr + $", {door}";
                    }
                    else
                    {
                        displayStr = displayStr + $"{door}";
                    }
                    
                }
                Console.WriteLine(displayStr);
            }
            
            PressAnyKeyToContinue();
        }

        private void DisplayAllBadges()
        {
            Console.Clear();
            List<Badges> listOfBadges = _repo.GetAllBadgesFromList();
            foreach(var badge in listOfBadges)
            {
                DisplayContent(badge);
            }
            PressAnyKeyToContinue();
        }

        private void DisplayContent(Badges badge)
        {

            Console.WriteLine($"BadgeID: {badge.BadgeID} \n");
            foreach(var item in badge.Doors)
            {
                Console.WriteLine($"Door Access: {item} \n");
            }

            
        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            RunMenu();
        }
        private void CreateStartContent()  //public Badges(int badgeID,  List<string> doors)
        {   
           
            List<DoorList> _badge1 = new List<DoorList>();
            _badge1.Add(DoorList.A1);
            _badge1.Add(DoorList.A2);
            _badge1.Add(DoorList.A3);
            _badge1.Add(DoorList.B2);
            Badges badge1 = new Badges(1234, _badge1);
            _repo.AddNewBadgeToList(badge1);
            _repo.AddBadgeToDictionary(badge1.BadgeID, _badge1);

            List<DoorList> _badge2 = new List<DoorList>();
            _badge2.Add(DoorList.A3);
            _badge2.Add(DoorList.B1);
            _badge2.Add(DoorList.B2);
            _badge2.Add(DoorList.B5);
            Badges badge2 = new Badges(2234, _badge2);
            _repo.AddNewBadgeToList(badge2);
            _repo.AddBadgeToDictionary(badge2.BadgeID, _badge2);
        }
    }
}
