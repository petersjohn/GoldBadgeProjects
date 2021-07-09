using Challenge1_Cafe_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Cafe_REPO
{
    public class MenuRepo
    {
        //CRUD

        private readonly List<MenuContent> _menuContent = new List<MenuContent>();

        //create

        public bool AddItemsToMenu(MenuContent content)
        {
            int menuItemCount = _menuContent.Count();
            _menuContent.Add(content);
            if(_menuContent.Count() == menuItemCount + 1)
            {
                return true;
            }
            return false;
        }

        //Read

        public List<MenuContent> GetMenu()
        {
            return _menuContent;
        }

        public MenuContent GetMenuContentByItemNumber(int menuNumber)
        {

            foreach (var item in _menuContent)
            {
                if (item.ItemNumber == menuNumber)
                {
                    return item;
                }
            }
            return null;
        }

        //UPDATE
        //Not implementing Updates at this time

        //Delete

        public bool DeleteItemByNumber(int menuNumber)
        {
            MenuContent content = GetMenuContentByItemNumber(menuNumber);
            if(content == null)
            {
                return false;
            }

            int sizeOfMenuBefore = _menuContent.Count;
            _menuContent.Remove(content);
            if(sizeOfMenuBefore > _menuContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

            

        }

        

        



        

       
    }
}
