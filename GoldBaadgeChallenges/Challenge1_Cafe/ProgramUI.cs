using Challenge1_Cafe_POCO;
using Challenge1_Cafe_REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Cafe
{
    class ProgramUI
    {

        bool isRunning = true;

        private readonly MenuRepo _repo = new MenuRepo();

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
            Console.WriteLine("Welcome to the Komodo Cafe Menu\n" +
                "Select an item from the following menu: \n" +
                "1) Show the entire cafe menu \n" +
                "2) Get menu item by number \n" +
                "3) Create a new cafe menu item \n" +
                "4) Delete an item from the cafe menu \n" +
                "5) Exit");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayCompleteMenu();
                    break;
                case "2":
                    DisplayMenuItemByNumber();
                    break;
                case "3":
                    CreateNewMenuItem();
                    break;
                case "4":
                    DeleteMenuItem();
                    break;
                case "5":
                    isRunning = false;
                    return;
                default:
                    Console.WriteLine("Please enter a valid selection.");
                    PressAnyKeyToContinue();

                    

                    return;
            }
        }

        private void DisplayCompleteMenu()
        {
            List<MenuContent> listOfMenuContent = _repo.GetMenu();

            foreach(MenuContent item in listOfMenuContent)
            {
                DisplayMenuItem(item);
            }

            PressAnyKeyToContinue();
                
        }

        private void DisplayMenuItemByNumber()
        {
            Console.WriteLine("Enter the item's menu number: ");
            int itemNumber = int.Parse(Console.ReadLine());

            MenuContent content = _repo.GetMenuContentByItemNumber(itemNumber);

            if(content != null)
            {
                DisplayMenuItem(content);
            }

            PressAnyKeyToContinue();
        }

        private void DisplayMenuItem(MenuContent content)
        {
            var list = content.ItemIngredients;
            string listItems = string.Join(",", list);


                Console.WriteLine($"Name: {content.ItemName} \n" +
                $"Number: {content.ItemNumber} \n" +
                $"Description: {content.ItemDescription} \n" +
                $"Price: {content.ItemPrice} \n" +
                $"Ingredients: {listItems} \n" +
                $" ");
        }

        private void CreateNewMenuItem()
        {
            
            Console.Clear();

            Console.WriteLine("Enter a name for the Menu Item: ");
            string itemName = Console.ReadLine();

            Console.WriteLine("Enter the item number for the new menu item: ");
            int itemNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Menu Item description: (Make it sound really delicious!)");
            string itemDescription = Console.ReadLine();

            Console.WriteLine("Enter the price of the new menu item: ");
            decimal price = decimal.Parse(Console.ReadLine());
             

            List<string> retrievedList = new List<string>(CreateListItems());
            //public MenuContent(string itemName, int itemNumber, string itemDescription, decimal itemPrice, IList<string> itemIngredients)
            MenuContent content = new MenuContent(itemName, itemNumber, itemDescription, price, retrievedList);
            _repo.AddItemsToMenu(content);

            PressAnyKeyToContinue();

        }

        private List<string> CreateListItems()
        {
            bool continueToAddItems = true;
            List<string> ingredients = new List<string>();
            while (continueToAddItems)
            {
                if(ingredients.Count < 1)
                {
                    Console.WriteLine("Enter the first ingredient: ");
                    string ingredientItem = Console.ReadLine();
                    ingredients.Add(ingredientItem);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Do you want to add another item? (y/n)");
                    string continueResponse = Console.ReadLine().ToLower();
                    if(continueResponse == "n")
                    {
                        continueToAddItems = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter the next ingredient: ");
                        string ingredientItem = Console.ReadLine();
                        ingredients.Add(ingredientItem);

                    }
                }

           }
            return ingredients;
        }

        private void DeleteMenuItem()
        {
            List<MenuContent> listOfContent = _repo.GetMenu();

            foreach(MenuContent content in listOfContent)
            {
                Console.WriteLine(content.ItemNumber);
                Console.WriteLine(content.ItemName);

                
            }
            Console.WriteLine("Enter the Menu Item Number that you wish to delete: ");
            int menuItem = int.Parse(Console.ReadLine());
            if (_repo.DeleteItemByNumber(menuItem))
            {
                Console.WriteLine("Item deleted.");
              
            }
            else
            {
                Console.WriteLine("Delete failed, did you enter the correct item number?");
                
            }
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
            //public MenuContent(string itemName, int itemNumber, string itemDescription, decimal itemPrice, IList<string> itemIngredients)
            MenuContent veggieWrap =
                new MenuContent("Veggie Wrap", 1, "A delightful assortment of fresh vegetables on a base of guacamole", 7.95m, new List<string> { "spinach wrap", "guac", "iceberg lettuce", "green pepper", "diced tomato", "sweet onion", "black olive", "roasted corn", "southwest sauce" }); ;
            _repo.AddItemsToMenu(veggieWrap);
        }
    }
}
