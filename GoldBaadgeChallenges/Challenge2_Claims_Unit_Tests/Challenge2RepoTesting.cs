using Challenge2_Claims_POCO;
using Challenge2_Claims_REPO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge2_Claims_Unit_Tests
{
    [TestClass]
    public class Challenge2RepoTesting

    {
        private ClaimsRepo _repo;
        private Claims claim;



        [TestInitialize]

        public void ArrangeTests()
        {
            _repo = new ClaimsRepo();
            claim = new Claims();
            Claims claim1 = new Claims(1, ClaimType.Car, "Accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 4, 27));
            Claims claim2 = new Claims(2, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));

            _repo.AddClaimToQueue(claim1);
            _repo.AddClaimToQueue(claim2);
            _repo.AddClaimToList(claim1);
            _repo.AddClaimToList(claim2);



        } //CREATE METHODS
        [TestMethod]
        public void AddClaimToList_ListCountShouldIncrement()
        {
            int listLengthBefore = _repo.claimList.Count;
            Claims claim3 = new Claims(3, ClaimType.Theft, "Stolen Pancakes", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));
            _repo.AddClaimToList(claim3);
            int listLengthAfter = _repo.claimList.Count;

            Assert.AreNotEqual(listLengthBefore, listLengthAfter);

        }

        [TestMethod]
        public void AddClaimToQueue_ShouldIncrementQueueCount()
        {   //ARRANGE
            int qLengthBefore = _repo._claimQueue.Count;
            Claims claim3 = new Claims(3, ClaimType.Theft, "Stolen Pancakes", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));
            //ACT
            _repo.AddClaimToQueue(claim3);
            int qLengthAfter = _repo._claimQueue.Count;
            //ASSERT
            Assert.AreNotEqual(qLengthBefore, qLengthAfter);

        }
        // READ METHODS


        [TestMethod]
        public void ReturnAllClaimsFromList_shouldReturnTrue()
        {
            //arrange

            bool actual;
            List<Claims> listOfContent = _repo.ReturnAllClaims();
            //ACT
            if (listOfContent.Count > 0)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ReturnQueue_shouldReturnTrue()
        {
            bool actual;
            Queue<int> contentQueue = _repo.ReturnQueue();
            if (contentQueue.Count > 0)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }

            Assert.IsTrue(actual);
        }
        //Delete Methods
        [TestMethod]
        public void DeleteClaimFromList_ListCountShouldDecrement()
        {
            //Arrange
            List<Claims> listOfContent = _repo.ReturnAllClaims();

            //Act
            int listSizeBefore = listOfContent.Count;
            _repo.RemoveClaimFromListByID(1);
            int listSizeAfter = listOfContent.Count;

            //Assert
            Assert.IsTrue(listSizeAfter < listSizeBefore);

        }

       












        }
    }
}
