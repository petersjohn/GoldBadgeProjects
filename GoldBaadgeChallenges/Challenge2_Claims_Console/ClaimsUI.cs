using Challenge2_Claims_POCO;
using Challenge2_Claims_REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Claims_Console
{
    class ClaimsUI
    {
        bool isRunning = true;

        private readonly ClaimsRepo _repo = new ClaimsRepo();

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
            Console.WriteLine("Komodo Insurance Claim Queue: \n" +
                "Please Enter a menu selection: \n" +
                "1) See all claims in queue \n" +
                "2) Process next claim \n" +
                "3) Enter a new claim \n" +
                "4) Exit the Claim Queue System");
               

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayQueue();
                    break;
                /*case "2":
                    
                    break;
                case "3":
                    
                    break;
                case "4":
                    
                    break;
                case "5":
                    is
                    return;*/
                default:
                    /*Console.WriteLine("Please enter a valid selection.");
                    PressAnyKeyToContinue();*/
                    isRunning = false;



                    return;
            }
        }

        private void DisplayQueue()
        {
            List<Claims> claims = new List<Claims>();
            List<Claims> existingClaims = _repo.ReturnAllClaims();
            int[] qArray = GetQueueArray();

            for (int idx = 0; idx < qArray.Length; idx++)
            {
                claims.Add(existingClaims.Find(claim => claim.ClaimID == qArray[idx]));
            }

            Console.Clear();
            if(claims != null)
            {
                Console.WriteLine("ClaimID" + "\t" + "Claim Type" + "\t" + "Description " +"\t" + "IsValid");
                foreach (var item in claims)
                {
                    Console.WriteLine(item.ClaimID + "\t"+ item.TypeOfClaim + "\t" + "\t" + item.Description + "\t" + "\t" + item.IsValid);

                }
            }
            PressAnyKeyToContinue();

        }

        private void CreateStartContent()
        {
            Claims claim1 = new Claims(1, ClaimType.Car, "Accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 4, 27));
            Claims claim2 = new Claims(2, ClaimType.Home,"House fire in kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            Claims claim3 = new Claims(3, ClaimType.Theft, "Stolen Pancakes", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));
            _repo.AddClaimToQueue(claim1);
            _repo.AddClaimToQueue(claim2);
            _repo.AddClaimToQueue(claim3);
            _repo.AddClaimToList(claim1);
            _repo.AddClaimToList(claim2);
            _repo.AddClaimToList(claim3);
        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            RunMenu();
        }

        public int[] GetQueueArray()
        {
            int[] qArray = (_repo.ReturnQueue()).ToArray();
            return qArray;
        }

        



    }
}
