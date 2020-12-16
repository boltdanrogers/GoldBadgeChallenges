using Challenge1Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge1Cafe_Tests
{
    [TestClass]
    public class Cafe1Tests
    {
        //ok, this is our test class
        //we will have several test methods to assert that various aspects of the repository works as expected
        private MenuItemRepository _repo;
        private MenuItem _meal;
        //there will also be a method to initialize some data into the repository
        
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepository();
            _meal = new MenuItem();
            //now that we've initialized our classes, lets populate the repo
            _meal = new MenuItem(1, "Cheeseburger", "A quarter lb of beef on bun with a thick slice of cheese", 5.99f, new List<string>() { "bun", "burger", "cheese" });
            _repo.Add(_meal);

            _meal = new MenuItem(2, "Mac and Cheese", "Huge bowl of al dente macoroni smothered in the yellowest cheesiest sauce you've ever had", 7.49f, new List<string>() { "macaroni", "butter", "cheese" });
            _repo.Add(_meal);

            //we've added two menuItems to the repo

        }//end of method Arrange

        
        //just need to test the four methods
        [TestMethod]
        public void AddToRepo_And_ReturnMenuItem_ShouldGetAreEqual()
        {

            _meal = new MenuItem(3, "Chili Cheese Fries", "A plate of our award winning fries, covered in our homemade chili and topped with cheese, sourcream, whatever you like", 9.99f, new List<string>() { "fries", "chili", "cheese" });
            _repo.Add(_meal);

            MenuItem newItem = _repo.ReturnMenuItem(3);
            Assert.AreEqual(_meal, newItem);


        }//end of addToRepo method

        [TestMethod]
        public void DeleteFromRepo_ShouldGetNull()
        {
            //we can get rid of one of the original menuItems and then ask for it again
            bool deleteMehtodSaysWorked = _repo.DeleteMenuItem(1);
            if(deleteMehtodSaysWorked)
            {
                MenuItem aTestMenuItem = _repo.ReturnMenuItem(1);
                Assert.AreEqual(aTestMenuItem, null);

            }//end of if method said it worked
            else
            {
                //says it didn't work
                Assert.IsTrue(deleteMehtodSaysWorked);

            }

        }//end of deleteFromRepo method

        [TestMethod]
        public void UpdateMethod_ShouldGetTrue()
        {
            //we want to update a menuItem and then we check that
            //the stored menuItem contains the new values
            _meal = new MenuItem(3, "Chili Cheese Fries", "A plate of our award winning fries, covered in our homemade chili and topped with cheese, sourcream, whatever you like", 9.99f, new List<string>() { "fries", "chili", "cheese" });
            _repo.UpdateMenuItem(1,_meal);

            MenuItem anotherMeal = _repo.ReturnMenuItem(3);
            //lets check that the descriptions are the same
            Assert.AreEqual(_meal.MealDescription, anotherMeal.MealDescription);


        }//end of test method

        [TestMethod]
        public void GetRepo()
        {
            //this one I guess we see that the getall returns a list of menu items
            //since the list inside the repo is filled with two at the beginning
            //we cna just assert that the count of the returned list is not zero
            
            List<MenuItem> aList = _repo.ReturnAllMenuItems();
            Assert.AreNotEqual(0, aList.Count);

        }//end of test method

        

    }//end of class Cafe1Tests
}
