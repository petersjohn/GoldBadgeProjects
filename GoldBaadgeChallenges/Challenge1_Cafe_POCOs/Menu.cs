using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Cafe_POCO
{
    
    public class MenuContent
    {
        public MenuContent() { }

        public MenuContent(string itemName, int itemNumber, string itemDescription, decimal itemPrice, IList<string> itemIngredients)
        {
            ItemName = itemName;
            ItemNumber = itemNumber;
            ItemDescription = itemDescription;
            ItemPrice = itemPrice;
            ItemIngredients = itemIngredients;
         }

        public string ItemName { get; set; }
        public int ItemNumber { get; set; }

        public string ItemDescription { get; set; }

        public decimal ItemPrice { get; set; }

        public IList<string> ItemIngredients { get; set; }

        














    }








}