using Challenge1Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Cafe

{
    class ProgramUI
    {
        //this will instantiate a repository and then create and manipulate menuItems as needed
        private MenuItemRepository _menuRepository = new MenuItemRepository();

        //our public run method to start the interface
        public void Run()
        {
            //call the setup method to populate the list
            Arrange();
            //call the menu method
            MenuFunction();
            //that's it, when it's done the program will return control to main and end

        }//end of method Run

        //our private interface method to create the menu for the user to choose from, called by method run
        private void MenuFunction()
        {
            bool continueFlag = true;

            while (continueFlag)
            {
                //clear the screen
                Console.Clear();
                //and then print the menu
                Console.WriteLine("Please choose from the following options:\n" +
                    "1: Add a new Item to the Menu\n" +
                    "2: Delete an existing Item from the Menu\n" +
                    "3: View all Menu Items\n" +
                    "4: Exit Program");
                //our menu is out, lets get user input
                Console.WriteLine("Enter the number of your choice:");
                string userInput = Console.ReadLine();

                //and lets see what they said
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Adding a new Menu Item.");
                        Add();

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();

                        break;
                    case "2":
                        Console.WriteLine("Deleting a Menu Item.");
                        Delete();

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();

                        break;
                    case "3":
                        Console.WriteLine("Viewing all Menu Items.");
                        View();

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();

                        break;
                    case "4":
                        Console.WriteLine("Exiting the Program.");
                        Exit();
                        continueFlag = false;

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();

                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();

                        break;

                }//end of switch case
               
            }//end of while continue is true




        }//end of method menuFunction

        //lets add a function to populate some menu items into the repo

        private void Arrange()
        {
            MenuItem aMeal = new MenuItem(1, "Cheeseburger", "A quarter lb of beef on bun with a thick slice of cheese", 5.99f, new List<string>() { "bun", "burger", "cheese" });
            _menuRepository.Add(aMeal);

            MenuItem anotherMeal = new MenuItem(2, "Mac and Cheese", "Huge bowl of al dente macoroni smothered in the yellowest cheesiest sauce you've ever had", 7.49f, new List<string>() { "macaroni", "butter", "cheese" });
            _menuRepository.Add(anotherMeal);

        }//end of method arrange



        //the prompt only specified add delete and return all for the console program

        //add
        private void Add()
        {
            Console.Clear();
            Console.WriteLine("Inside Add");
            //need to create an object to be able to set it's properties
            //or we collect the information, instantiate a list, and then pass those things
            //to the constructor at the end


            Console.WriteLine("Please enter the Meal Number:");
            string number = Console.ReadLine();
            Console.WriteLine("Please enter the Meal Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the Meal Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Please enter the Meal Price:");
            string price = Console.ReadLine();

            //the ingredients are stored in a list
            List<string> ingredientList = new List<string>();
            //now to get a list we have to have a loop and a value that will get us out of the loop
            bool continueIngredientsLoop = true;
            Console.WriteLine("Enter the word 'finished' to quit entering Ingredients.");
            string ingredient;

            while (continueIngredientsLoop)
            {
                Console.WriteLine("Please enter an Ingredient:");
                ingredient = Console.ReadLine();
                if (ingredient.ToLower() == "finished")
                {

                    continueIngredientsLoop = false;

                }//end of if user entered finished
                else
                {
                    //the user has entered SOMETHING, and we must save it to the list
                    ingredientList.Add(ingredient);
                }


            }//end while true get ingredients

            //we have all the things we need, lets call a constructor

            MenuItem aMenuItem = new MenuItem(int.Parse(number), name, description, float.Parse(price), ingredientList);

            //and now we add to the instantiated repo

            bool successFlag = _menuRepository.Add(aMenuItem);

            //tell the user whether it worked or not

            string userMessage = "Not successfully added...";
            if(successFlag)
            {
                userMessage = "Successfully added to the Menu.";
            }//end of if bigger
            Console.WriteLine(userMessage);

        }//end of method add

        //delete
        private void Delete()
        {
            Console.Clear();
            Console.WriteLine("Inside Delete");

            //show all the items, then get user input search for and erase the item
            View();
            Console.WriteLine("Enter the number of the meal you wish to delete:");
            int userChoice = int.Parse(Console.ReadLine());
            //we've got a number, now lets see if we can remove it
            bool wasDeleted = _menuRepository.DeleteMenuItem(userChoice);

            //tell the user whether it worked or not

            string userMessage = "Not successfully deleted...";
            if (wasDeleted)
            {
                userMessage = "Successfully deleted from the Menu.";
            }//end 
            Console.WriteLine(userMessage);

        }//end of method delete

        private void View()
        {
            Console.Clear();
            Console.WriteLine("Inside View");
            //time to get the list
            List<MenuItem> theMenuItemsList = _menuRepository.ReturnAllMenuItems();

            //no loop through
            foreach(MenuItem aMeal in theMenuItemsList)
            {
                Console.WriteLine($"Meal Number: {aMeal.MealNumber}\n" +
                    $"Meal Name: {aMeal.MealName}\n" +
                    $"Meal Price: ${aMeal.MealPrice}\n" +
                    $"Meal Description: {aMeal.MealDescription}\n" +
                    $"Meal Ingredients: {string.Join(",", aMeal.MealIngredients.ToArray())}\n");


            }//end of foreach
            //printed out the three main parts of each meal 


        }//end of method view

        private void Exit()
        {
            Console.WriteLine("Inside Exit");

        }//end of method exit


    }//end of class programUI
}
