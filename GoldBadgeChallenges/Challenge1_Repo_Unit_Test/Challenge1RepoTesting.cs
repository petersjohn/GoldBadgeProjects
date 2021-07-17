using Challenge1_Cafe_POCO;
using Challenge1_Cafe_REPO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge1_Repo_Unit_Test
{
    [TestClass]
    public class Challenge1RepoTesting
    {
        private MenuRepo _repo;
        private MenuContent _content;
        

        [TestInitialize]
        public void ArrangeTests()
        {
            _repo = new MenuRepo();
            _content = new MenuContent("Veggie Wrap", 1, "A delightful assortment of fresh vegetables on a base of guacamole", 7.95m, new List<string> { "spinach wrap", "guac", "iceberg lettuce", "green pepper", "diced tomato", "sweet onion", "black olive", "roasted corn", "southwest sauce" });
            _repo.AddItemsToMenu(_content); 
            
        }
        
        [TestMethod]
        public void AddToList_ShouldGetNotull()
        {
            MenuContent content = new MenuContent();
            content.ItemName = "testwrap";
            content.ItemNumber = 2;
            MenuRepo _repo = new MenuRepo();
            _repo.AddItemsToMenu(content);
            MenuContent getContentFromMenuList = _repo.GetMenuContentByItemNumber(2);
            Assert.IsNotNull(getContentFromMenuList);
        }

        [TestMethod]
        public void ReadFromList_ShouldReturnNotNull()
        {//ARRANGE
            bool expected = true;
            bool actual;
            List<MenuContent> listOfContent = _repo.GetMenu();
            //ACT
            if (listOfContent.Count > 0)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }
            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteFromList_ShouldReturnZero()
        {//ARRANGE
            List<MenuContent> listOfContent = _repo.GetMenu();
            int sizeOfListBefore = listOfContent.Count;
            //ACT
            _repo.DeleteItemByNumber(1);
            int sizeOfListAfter = listOfContent.Count;
            //ASSERT
            Assert.AreNotEqual(sizeOfListBefore, sizeOfListAfter);

        }
    }
}
