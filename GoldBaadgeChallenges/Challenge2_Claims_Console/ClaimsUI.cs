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
                case "2":
                    DisplayNextInQueue();
                     break;
                 case "3":
                    CreateNewClaim();
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
            if (claims.Count != 0)
            {
                //Console.WriteLine("ClaimID" + "\t" + "Claim Type" + "\t" + "Description" +"\t" + "IsValid");
                Console.WriteLine("{0,-10}{1,-15}{2,-35}{3,-10}{4,-15}{5,-14}{6,7}", "ClaimID", "Claim Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
                int listSize = claims.Count;
                int idx = 0;
                foreach (var item in claims)
                {
                    idx++;
                    string lossDate = ReturnDateString(item.DateOfAccident);
                    string claimDate = ReturnDateString(item.DateOfClaim);
                    if (idx == listSize)
                    {   
                        Console.WriteLine("{0,-10}{1,-15}{2,-35}{3,-10}{4,-15}{5,-14}{6,7}\n", (item.ClaimID), (item.TypeOfClaim), (item.Description),(item.ClaimAmount),(lossDate), (claimDate), (item.IsValid));
                    }
                    else
                    {
                        Console.WriteLine("{0,-10}{1,-15}{2,-35}{3,-10}{4,-15}{5,-14}{6,7}", (item.ClaimID), (item.TypeOfClaim), (item.Description), (item.ClaimAmount), (lossDate), (claimDate), (item.IsValid));
                    }


                }
            }
            else
            {
                Console.WriteLine("There are no claims in the queue. Check back later.");
            }
            
            PressAnyKeyToContinue();

        }

        private int PeekClaim()
        {
            if (_repo.ReturnQueue().Count > 0)
            {
                int nextInQueue = _repo.ReturnQueue().Peek();
                return nextInQueue;
            }
            else
            {
                return 0;
            }

        }


        private void DisplayNextInQueue()
        {
            int nextInQueue = PeekClaim();
            if (nextInQueue > 0)
            {
                foreach (var item in _repo.ReturnAllClaims())
                {
                    if (item.ClaimID == nextInQueue)
                    {
                        string lossDate = ReturnDateString(item.DateOfAccident);
                        string claimDate = ReturnDateString(item.DateOfClaim);

                        Console.WriteLine($"ClaimID: {item.ClaimID} \n" +
                            $"Type: {item.TypeOfClaim} \n" +
                            $"Description: {item.Description}\n" +
                            $"Amount: {item.ClaimAmount} \n" +
                            $"DateOfAccident: {lossDate} \n" +
                            $"DateOfClaim: {claimDate} \n" +
                            $"IsValid: {item.IsValid} \n");
                    }
                }
                ProcessClaim(nextInQueue);
            }
            else
            {
                Console.WriteLine("There is nothing in the queue, go make coffee and bring me a cup.");
                PressAnyKeyToContinue();
            }
        }

        private void ProcessClaim(int claimID)
        {
            Console.WriteLine("Do you want to process this claim now(y/n)");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "y":
                    RemoveContent(claimID);
                    break;
                case "n":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please enter y/n only");
                    PressAnyKeyToContinue();
                    return;
            }
        }

        private void RemoveContent(int claimID)
        {
            if (_repo.RemoveClaimFromListByID(claimID) == true && _repo.RemoveFromQueue() == true)
            {
                Console.WriteLine("Claim has been removed from the queue. \n");
                PressAnyKeyToContinue();

            }
            else
            {
                Console.WriteLine("Something has gone HORRIBLY wrong, please sprint to the nearest exit.");
                PressAnyKeyToContinue();
            }
        }

        private void CreateNewClaim()
        {
            int newClaimID = _repo.CreateNewClaimID();
            Console.WriteLine($"New Claim ID: {newClaimID}");
            SelectAClaimType();
            ClaimType claimType = GetClaimType();
            Console.WriteLine("Enter a claim description ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the amount of claim: (###.## format)");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Date of the Accident/Loss:");
            DateTime dateOfLoss = CreateDateValue();
            Console.WriteLine("Enter the Date the claim was filed: ");
            DateTime dateOfClaim = CreateDateValue();

            Claims newClaim = new Claims(newClaimID, claimType, description, claimAmount, dateOfLoss, dateOfClaim);
            if (_repo.AddClaimToList(newClaim) && _repo.AddClaimToQueue(newClaim))
            {
                Console.WriteLine("Claim successfully added to Queue");
            }
            else
            {
                Console.WriteLine("An error has occured.");
                
            }
            PressAnyKeyToContinue();





        }

        private DateTime CreateDateValue()
        {
            Console.WriteLine("Enter the Year (YYYY)");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 2 digit Month: ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the 2 digit Day of Month: ex (01)");
            int day = int.Parse(Console.ReadLine());
            DateTime returnDate = new DateTime(year, month, day);
            return returnDate;
        }

        private ClaimType GetClaimType()
        {
            while(true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return ClaimType.Car;
                    case "2":
                        return ClaimType.Home;
                    case "3":
                        return ClaimType.Theft;
                    default:
                        Console.WriteLine("Invalid Selection");
                        PressAnyKeyToContinue();
                        break;
                }
            }
        }

        private void SelectAClaimType()
        {
            Console.WriteLine($"Please select from the following (1-3): \n" +
                $"1) Car \n" +
                $"2) Home \n" +
                $"3) Theft \n"
                );
                
        }

        private void CreateStartContent()
        {
            Claims claim1 = new Claims(1, ClaimType.Car, "Accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 4, 27));
            Claims claim2 = new Claims(2, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
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
        private string ReturnDateString(DateTime date)
        {
            string dateStr = String.Format("{0:MM/dd/yyyy}", date);
            return dateStr;

        }
        public int[] GetQueueArray()
        {
            int[] qArray = (_repo.ReturnQueue()).ToArray();
            return qArray;
        }





    }
}
