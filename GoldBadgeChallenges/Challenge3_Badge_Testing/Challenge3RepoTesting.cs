using Challenge3_Badge_POCO;
using Challenge3_Badge_REPO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge3_Badge_Testing
{
    [TestClass]
    public class Challenge3RepoTesting
    {
        private BadgeREPO _repo;
        private Badges badge;

        [TestInitialize]
        public void ArrangeTesting()
        {
            _repo = new BadgeREPO();
            badge = new Badges();

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

            List<string> newList = new List<string>
            {
                "A1",
                "A2",
                "A3",
                "B1",
                "B2"
            };
            Badges badge1 = new Badges(1234, newList);
            _repo.AddNewBadgeToList(badge1);
            _repo.AddBadgeToDictionary(1234, badge1);
        }

        [TestMethod]
        public void AddANewBadgeToList_shouldReturnTrue()
        {
            //Arrange
            Badges badge = new Badges();
            List<string> testList = new List<string>{
                "A1",
                "A2",
                "A3",
                "B1",
                "B2"
            };
            int szBefore = _repo._badges.Count;
            badge.BadgeID = 2345;
            badge.Doors = testList;
            //Act
            _repo.AddNewBadgeToList(badge);
            int szAfter = _repo._badges.Count;
            //assert
            Assert.IsTrue(szAfter > szBefore);

        }

        [TestMethod]
        public void AddBadgeToDictionary_ShouldReturnTrue()
        {
            //arrange
            Badges badge = new Badges();
            List<string> testList = new List<string>{
                "A1",
                "A2",
                "A3",
                "B1",
                "B2"
            };
            int szBefore = _repo._badges.Count;
            badge.BadgeID = 2345;
            badge.Doors = testList;
            //act
            _repo.AddBadgeToDictionary(2345, badge);
            //assert
            Assert.IsTrue(_repo.badgeDictionary.ContainsKey(badge.BadgeID));

        }

        [TestMethod]
        public void CheckDictionaryForValue_ShouldReturnTrue()
        {
            bool retBool;

            retBool = _repo.CheckDictionary(1234);

            Assert.IsTrue(retBool);
        }

        [TestMethod]
        public void GetAllBadgesFromList_shouldReturnNotNull()
        {
            //arrange 
            List<Badges> testList = new List<Badges>();
            //act
            testList = _repo.GetAllBadgesFromList();

            Assert.IsNotNull(testList);

        }

        [TestMethod]
        public void GetBadgeByBadgeID_ShouldReturnTrue()
        {
            //arrange
            int testBadgeID = 1234;
            //act
            int retID = _repo.GetBadgeByBadgeID(testBadgeID).BadgeID;

            Assert.AreEqual(testBadgeID, retID);

        }

        [TestMethod]
        public void RemoveDoorsFromBadge_ListShouldDecrement()
        {
            //arrange
            int badgeID = 1234;
            List<string> testList = new List<string>();
            List<string> inputList = new List<String>
            {
                "A1",
                "A2"
            };

            testList = _repo.GetBadgeByBadgeID(badgeID).Doors;

            //Act
            _repo.RemoveDoorsFromBadge(badgeID, inputList);

            Assert.IsTrue(_repo._badges.Count == (testList.Count - 2));
        }

        [TestMethod]
        public void UpdateBadgeDictionary_shouldReturnTrue()
        {
            //arrange
            int badgeID = 1234;
            int szBefore = _repo.badgeDictionary[badgeID].Doors.Count;
            List<string> inputList = new List<String>
            {
                "A1",
                "A2"
            };

            //act
            _repo.RemoveDoorsFromBadge(badgeID, inputList);
            Badges badge = _repo.GetBadgeByBadgeID(badgeID);

            _repo.UpdateBadgeDictionary(badgeID, badge); //tested method
            int szAfter = _repo.badgeDictionary[badgeID].Doors.Count;

            //assert
            Assert.AreNotEqual(szBefore, szAfter);

        }

        [TestMethod]
        public void AddNewDoorsToBadge_countOfDoorsShouldIncrement()
        {
            //Arrange
            List<string> testList = new List<string>
            {
                "B1",
                "B2"
            };
            int badgeID = 1234;

            int szBefore = (_repo.GetBadgeByBadgeID(badgeID).Doors.Count);

            //act
            _repo.AddNewDoorsToBadge(badgeID, testList);
            int szAfter = (_repo.GetBadgeByBadgeID(badgeID).Doors.Count);
            //assert
            Assert.IsTrue(szBefore == szAfter - 2);

        }

        [TestMethod]
        public void AddBadgesToNullList_shourdReturnNotNullTrue()
        {
            //arrange
            int badgeID = 1234;
            _repo.RemoveAllDoorsFromBadge(badgeID);

            List<string> retList = new List<string>();
            List<string> testList = new List<string>
            {
                "B1",
                "B2"
            };

            //act
            _repo.AddBadgesToNullList(badgeID, testList);
            retList = _repo.GetBadgeByBadgeID(badgeID).Doors;

            Assert.IsNotNull(retList);
        }

        [TestMethod]
        public void RemoveAllDoorsFromBadge_ShouldReturnTrueNotEqual()
        {
            //arrange
            int badgeID = 1234;
            List<string> testBefore = new List<string>();
            List<string> testAfter = new List<string>();
            testBefore = _repo.GetBadgeByBadgeID(badgeID).Doors;


            //act
            _repo.RemoveAllDoorsFromBadge(badgeID);
            testAfter = _repo.GetBadgeByBadgeID(badgeID).Doors;

            //Assert
            Assert.AreNotEqual(testAfter, testBefore);
        }



    }


}
