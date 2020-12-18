using Challenge2Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge2Claims_Tests
{
    [TestClass]
    public class Challenge2ClaimsTest
    {
        //create some private data members
        Claim _aClaim = new Claim();
        ClaimRepository _claimRepo = new ClaimRepository();

        [TestInitialize]
        public void Arrange()
        {
            Claim aNewClaim = new Claim(2, ClaimType.Car, "was rear ended by red car", 2000.99f, new DateTime(2019, 5, 12), new DateTime(2019, 5, 29), true);
            _claimRepo.Add(aNewClaim);

        }//end of method Arrange





        [TestMethod]

        public void ReturnQueue_SouldBeLargerThanZero()
        {
            Queue<Claim> aQueue = _claimRepo.ReturnQueue();
            int size = aQueue.Count;
            Assert.IsTrue(size > 0);


        }//end of ReturnQueue_SouldBeLargerThanOne

        [TestMethod]
        public void Add_ShouldReturnTrue()
        {
            _aClaim = new Claim(4, ClaimType.Home, "tree fell on garage", 7000.00f, new DateTime(2020, 1, 2), new DateTime(2020, 5, 9), false);
            _claimRepo.Add(_aClaim);
            bool status = _claimRepo.ContainsClaim(_aClaim);
            Assert.IsTrue(status);

        }//end of method Add_ShouldBeTrue

        //peekclaim
        [TestMethod]
        public void PeekClaim_ShouldNotBeNull()
        {
            _aClaim = _claimRepo.PeekClaim();
            Assert.IsNotNull(_aClaim);

        }//end of test PeekClaim

        //dequeueclaim
        [TestMethod]
        public void DequeueClaim_ShouldBeFalse()
        {
            //peek to get it, dequeue it, check if the queue contains it still
            _aClaim = _claimRepo.PeekClaim();
            _claimRepo.DequeueClaim();
            Assert.IsFalse(_claimRepo.ContainsClaim(_aClaim));


        }//end of test DequeueClaim_Should BeFalse



        //contains
        public void Contains_ShouldBeTrue()
        {
            //maybe opposite then
            //check that it doesnt contain a claim
            //add it and then check again
            //so create the new claim
            _aClaim = new Claim(4, ClaimType.Home, "tree fell on garage", 7000.00f, new DateTime(2020, 1, 2), new DateTime(2020, 5, 9), false);
            //check that it isnt there yet
            bool status = _claimRepo.ContainsClaim(_aClaim);
            //should return false, now add the claim
            _claimRepo.Add(_aClaim);
            //and a new status
            bool newStatus = _claimRepo.ContainsClaim(_aClaim);
            //whew if we do this right it will say the first failed and the second passed
            Assert.IsTrue(newStatus && !status);



        }//end of Contains_ShouldBeTrue




    }//end of class
}
