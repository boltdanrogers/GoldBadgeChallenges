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

        public void ReturnQueue_SouldBeLargerThanOne()
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


    }
}
