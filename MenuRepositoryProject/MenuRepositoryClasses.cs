using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Cafe
{

    public class MenuItem
    {
        //our public data members, with their get and set methods
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public float MealPrice { get; set; }

        //a list instantiated with it's getter and setter to holds the strings of ingredients 
        public List<string> MealIngredients { get; set; } = new List<string>();

        //lets make two constructors, the basic that takes now arguments and is created empty
        public MenuItem()
        {

        }//end of constructor with no arguments

        //and a constructor with all needed arguments to fully instantiate a complete MenuItem
        public MenuItem(int TheMealNumber, string TheMealName, string TheMealDescription, float TheMealPrice, List<string> TheMealIngedients)
        {
            MealNumber = TheMealNumber;
            MealName = TheMealName;
            MealDescription = TheMealDescription;
            MealPrice = TheMealPrice;
            MealIngredients = TheMealIngedients;
            //everything should be set now, with the values of the arguments saves as the member variables

        }//end of overloaded constructor that takes all arguments


    }//end of class MenuItem

    public class MenuItemRepository
    {
        //our private field contains a list of all MealItems
        private List<MenuItem> _menuItemsList = new List<MenuItem>();

        //lets get that public crud going
        //create
        public bool Add(MenuItem aMenuItem)
        {
            //add and check size of the list afterwards
            int currentSize = _menuItemsList.Count();

            _menuItemsList.Add(aMenuItem);

            if (currentSize < _menuItemsList.Count())
            {
                //worked, or at least it got bigger
                return true;

            }//end of if bigger
            else
            {
                return false;
            }//end of else not bigger
        }//end of method add

        //read all or one

        public List<MenuItem> ReturnAllMenuItems()
        {
            //this method will return the entire list full of menu items
            return _menuItemsList;

        }//end of returnAllMenuItems

        //now each MenuItem is seemingly portraying a meal?? or at least some of them
        //might be meals. heck, lets assume that instead of any individual items like a drink or a small fries
        //there's only ten menuItems and each is a meal. or not, the point is the number is unique to the menuItem
        //and therefore will be the way we look MenuItems up
        public MenuItem ReturnMenuItem(int MealNumber)
        {
            //MenuItem aMeal = new MenuItem();
            foreach(MenuItem aMeal in _menuItemsList)
            {
                if( aMeal.MealNumber == MealNumber)
                {
                    //we have a match, return the menuItem
                    return aMeal;

                }


            }//end of foreach MenuItem in list
            //if we get here there is no menuItem with that mealNumber so
            return null;

        }//end of method ReturnMenuItem

        //now its time for an update
        //following the pattern we've used, we will accept a number and an object, and after
        //finding the right object will simply set its properties to that of the passed object
        public bool UpdateMenuItem(int MealNumber, MenuItem NewMeal)
        {
            MenuItem oldMeal = ReturnMenuItem(MealNumber);
            if(oldMeal == null)
            {
                //didn't work
                return false;

            }//end of if null

            //if we are here its not null so
            oldMeal.MealName = NewMeal.MealName;
            oldMeal.MealNumber = NewMeal.MealNumber;
            oldMeal.MealDescription = NewMeal.MealDescription;
            oldMeal.MealIngredients = NewMeal.MealIngredients;
            oldMeal.MealPrice = NewMeal.MealPrice;
            //everything has been changed
            return true;


        }//end of method updateMenuItem
        public bool DeleteMenuItem(int MealNumber)
        {
            //start by getting the meal
            MenuItem aMeal = ReturnMenuItem(MealNumber);
            //alright, lets do this the other way
            if(aMeal != null)
            {
                //the meal was returned, so lets remove it from the list
                bool successFlag = _menuItemsList.Remove(aMeal);
                //remove itself returns a bool, so this will reflect the status of our delete command
                //and just pass it on 
                return successFlag;

            }//end of if not null
            //and of course to get here we had to have been given a null so
            return false;

        }//end of deleteMenuItem




    }//end of class menuItemRepository
}
