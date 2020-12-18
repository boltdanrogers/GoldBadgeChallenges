using Challenge3Badge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3Badge_Console
{
    class ProgramUI
    {
        //create the private instance of the repo
        BadgeRepository _badgeRepo = new BadgeRepository();

        //need the run

        public void Run()
        {
            Arrange();

            UserMenu();

        }

        private void Arrange()
        {
            Console.WriteLine("inside arrange");
            Badge aBadge = new Badge(1,new List<string>() {"A4", "B1", "C7" });
            _badgeRepo.Add(aBadge);
            aBadge = new Badge(2, new List<string>() { "A1", "A2", "A3", "A4" });
            _badgeRepo.Add(aBadge);
            aBadge = new Badge(3, new List<string>() { "C5", "B2", "B1", "A1" });
            _badgeRepo.Add(aBadge);



        }//end of method Arrange

        private void UserMenu()
        {
            //Console.WriteLine("inside menu");
            //Console.ReadLine();

            bool ContinueFlag = true;
            while (ContinueFlag)
            {
                Console.Clear();
                //lets print out our menu for the user to choose from
                Console.WriteLine("Please select from the following menu:");

                Console.WriteLine("1: Create new Badge\n" +
                    "2: Update permissions on an existing Badge\n" +
                    "3: Delete all door permissions associated with a Badge\n" +
                    "4: View all Badge Numbers and associated door permissions\n" +
                    "5: Exit Program");

                //get that input
                Console.WriteLine("Enter your selection:");
                string userInput = Console.ReadLine();

                //and to do something with that input
                switch (userInput)
                {
                    case "1":
                        CreateBadge();
                        Console.WriteLine("Press enter the continue");
                        Console.ReadLine();
                        break;
                    case "2":
                        UpdateBadge();
                        Console.WriteLine("Press enter the continue");
                        Console.ReadLine();
                        break;

                    case "3":
                        DeleteBadgeDoors();
                        Console.WriteLine("Press enter the continue");
                        Console.ReadLine();
                        break;
                    case "4":
                        ViewAllBadges();
                        Console.WriteLine("Press enter the continue");
                        Console.ReadLine();
                        break;
                    case "5":
                        ContinueFlag = false;
                        Console.WriteLine("Exiting program.");
                        Console.WriteLine("Press enter the continue");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;





                }//end of switch case




            }//end of while

            //user has requested to leave the program


        }//end of method UserMenu


        //other methods that will be called from menu per user request

        private void CreateBadge()
        {
            //get the needed information from the user
            Console.Clear();
            Console.WriteLine("Create new Badge\n\nPlease enter an unused ID number.");
            string userDoor;
            //get the ID, and then loop for the list
            int userID = int.Parse(Console.ReadLine());
            List<string> aList = new List<string>();

            Console.WriteLine("Loop to enter door privileges\nEnter 'finished' to exit");
            bool continueFlag = true;
            while (continueFlag)
            {
                Console.WriteLine("Enter a Door to add to the Badge's list of permissions.");
                userDoor = Console.ReadLine().ToLower();
                if (userDoor == "finished")
                {
                    continueFlag = false;
                }//end if user entered finished
                else
                {
                    aList.Add(userDoor);
                }//end else add to list

            }//end of while continue

            //we have the pieces to make a Badge

            //lets make it and add to the Dictionary
            Badge aBadge = new Badge(userID, aList);
            _badgeRepo.Add(aBadge);



            Console.WriteLine("Badge added to Dictionary");



        }//end of method CreateBadge

        private void PrintBadge(Badge aBadge)
        {
            Console.WriteLine($"{aBadge.BadgeID,10}\t{string.Join(",", aBadge.DoorList.ToArray()),30}");
        }//end of PrintBadge


        //show all badges
        private void ViewAllBadges()
        {
            Console.Clear();
            Console.WriteLine("");
            //get the dictionary and iterate through
            Dictionary<int, Badge> aDictionary = _badgeRepo.ReturnDictionary();
            //and what we actually want is the different badges so
            Dictionary<int, Badge>.ValueCollection aValueList = aDictionary.Values;
            Console.WriteLine($"{0,10}\t{1,30}", "ID", "Doors");
            foreach(Badge aBadge in aValueList)
            {
                PrintBadge(aBadge);
            }
            Console.WriteLine();

        }//end method ViewAllBadges

        //update
        private void UpdateBadge()
        {
            //again the most complicated
            Console.Clear();
            ViewAllBadges();
            Console.WriteLine("Enter a badge ID number");
            //this one, we want to get the badge and show the parts inside it
            
            int userID = int.Parse(Console.ReadLine());
            Badge aBadge = _badgeRepo.ReturnBadge(userID);
            if (aBadge != null)
            {
                List<string> aList = aBadge.DoorList;
                
                //Console.WriteLine("enter 'finished' to exit loop");
                bool continueFlag = true;
                while(continueFlag)
                {
                    PrintBadge(aBadge);
                    Console.WriteLine("Would you like to remove a door or add a door:\n1: Add\n2: Remove\n3: Exit");
                    string userInput = Console.ReadLine();
                    string userDoor;
                    switch (userInput)
                    {
                        case "1":
                            Console.WriteLine("Enter a door to add:");
                            userDoor = Console.ReadLine();
                            aList.Add(userDoor);
                            break;
                        case "2":
                            Console.WriteLine("Enter a door to remove:");
                            userDoor = Console.ReadLine();
                            aList.Remove(userDoor);
                            break;
                        case "3":
                            continueFlag = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;

                    }//end of switch case



                }//end of while true




            }//end of if exists
            else
            {
                Console.WriteLine("Invalid ID");
            }//end of else null



        }//end of method UpdateBadge

        //delete
        private void DeleteBadgeDoors()
        {
            //so this is described pretty specific, and we don't want to actually delete the badge
            //just remove all the doors from the badge selected and save that in the dictionary
            Console.Clear();
            Console.WriteLine("Please enter the ID for the Badge you" +
                " would like to reset permissions on");
            int userID = int.Parse(Console.ReadLine());
            Badge aBadge = _badgeRepo.ReturnBadge(userID);
            if (aBadge != null)
            {
                bool? successFlag = _badgeRepo.Delete(userID);
                if (successFlag == true)
                {
                    //we have removed the original badge
                    //add another with the same ID but an empty list
                    Badge aNewBadge = new Badge(userID, new List<string>());
                    //now add to the repo
                    _badgeRepo.Add(aNewBadge);
                    Console.WriteLine("Badge door access reset to none");
                }//end of if true

            }
            else
            {
                Console.WriteLine("ID not found");
            }//end of else



        }//end of method DeleteBadgeDoors

        //helper method
        private Badge ReturnBadge(int anID)
        {

            Badge aBadge = _badgeRepo.ReturnBadge(anID);

            /*
            if (aBadge != null)
            {

                return aBadge

            }//end of if not null
            else
            {
                return null;
            }//end of else null

            */

            //seems like that is unneeded if we are going to return a null if its a null
            return aBadge;


        }//end of method ReturnBadge





    }//end of class ProgramUI
}
