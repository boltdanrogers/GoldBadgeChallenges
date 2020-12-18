using Challenge3Badge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge3Badge_Tests
{
    [TestClass]
    public class Challenge3Badge_Tests
    {

        //we need our private members
        Badge _aBadge = new Badge();
        BadgeRepository _badgeRepo = new BadgeRepository();
        //then we need our arrange method
        [TestInitialize]
        public void Arrange()
        {


            Console.WriteLine("inside arrange");
            _aBadge = new Badge(1, new List<string>() { "A4", "B1", "C7" });
            _badgeRepo.Add(_aBadge);
            _aBadge = new Badge(2, new List<string>() { "A1", "A2", "A3", "A4" });
            _badgeRepo.Add(_aBadge);
            _aBadge = new Badge(3, new List<string>() { "C5", "B2", "B1", "A1" });
            _badgeRepo.Add(_aBadge);
            


        }//end of method Arrange

        //then we need to test

        //add return, return update delete

        /*[TestMethod]
        public void TestTest()
        {
            Assert.AreEqual(true, true);
        }//end of test
        */

        
        [TestMethod]
        public void Add_ShouldReturnTrue()
        {
            _aBadge = new Badge(4, new List<string>() { "R2", "D2", "C3", "P0" });
            _badgeRepo.Add(_aBadge);
            Assert.IsNotNull(_badgeRepo.ReturnBadge(_aBadge.BadgeID));


        }//end of add
        [TestMethod]
        public void ReturnDictionary_ShouldNotBeNull()
        {
            Dictionary<int, Badge> aDictionary = _badgeRepo.ReturnDictionary();
            Assert.IsNotNull(aDictionary);

        }//end of returnQueue
        [TestMethod]
        public void ReturnBadge_ShouldBeEqual()
        {
            _aBadge = new Badge(4, new List<string>() { "R2", "D2", "C3", "P0" });
            _badgeRepo.Add(_aBadge);
            Assert.IsNotNull(_badgeRepo.ReturnBadge(_aBadge.BadgeID));

        }//end of ReturnBadge
        [TestMethod]
        public void Update_ShouldNotEqual()
        {
            //we need to get the badge and save the list, change the badge, get the badge
            //and save its list, and compare and assert 
            List<string> aList = _badgeRepo.ReturnBadge(1).DoorList;
            _aBadge.DoorList = new List<string>() { "C5", "B2", "B1", "A1" };
            _badgeRepo.UpdateBadge(1, _aBadge);
            Assert.AreNotEqual(aList, _badgeRepo.ReturnBadge(1).DoorList);

        }//end of Update_ShouldBeEqual
        [TestMethod]
        public void Delete_ShouldBeTrue()
        {
            Assert.AreEqual(true, _badgeRepo.Delete(1));
        }//end of DeleteDoors
        





    }//end of class
}
