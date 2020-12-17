using Challenge2Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2Claims_Console
{
    class ProgramUI
    {
        //we have a private instance of a Repo
        private ClaimRepository _claimRepo = new ClaimRepository();


        //we have a run method that is public
        public void Run()
        {
            Arrange();

            Menu();


        }//end of method Run

        //and an Arrange method to set things up so there are claims in the queue
        private void Arrange()
        {
            //Console.WriteLine("Inside Arrange");
            Claim aClaim = new Claim(2, ClaimType.Car, "was rear ended by red car", 2000.99f, new DateTime(2019, 5, 12), new DateTime(2019, 5, 29), true);
            //for reference, the date-time takes year, month and day
            Claim anotherClaim = new Claim(4, ClaimType.Home, "tree fell on garage", 7000.00f, new DateTime(2020, 1, 2), new DateTime(2020, 5, 9), false);
            Claim lastClaim = new Claim(7, ClaimType.Theft, "purse and briefcase", 499.99f, new DateTime(2018, 10, 28), new DateTime(2018, 11, 20), true);
            //now we have three, lets add them to the queue
            _claimRepo.Add(aClaim);
            _claimRepo.Add(anotherClaim);
            _claimRepo.Add(lastClaim);



        }//end of method arrange


        private void Menu()
        {

            //Console.WriteLine("Inside Menu");
            //we were told to give a three point menu. obviously we need to be able to exit too



            //flag to keep us looping through the menu
            bool continueFlag = true;

            while (continueFlag)
            {

                //print the menu
                Console.WriteLine("Please select one of the following options:");

                Console.WriteLine("1: See all Claims\n" +
                    "2: Take care of next Claim\n" +
                    "3: Enter a new Claim\n" +
                    "4: Exit the Program\n");

                //get the input from the user
                string userInput = Console.ReadLine();


                //evaluate the input
                switch (userInput)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        Add();
                        break;
                    case "4":
                        ExitProgram();
                        continueFlag = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        break;

                }//end of switch case

                //we got the info and did something, now we re down here and will either exit the loop or go back to the top
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                Console.Clear();

            }//end while continue true

        }//end of method Menu


        //and then we'll have some user methods

        //view all claims
        private void ViewAllClaims()
        {
            Console.Clear();
            //get given the copy of the queue
            Queue<Claim> claimsQueue = _claimRepo.ReturnQueue();

            Console.WriteLine("{0,5}{1,15}{2,30}{3,12}{4,12}{5,12}{6,15}", "ID", "Claim Type", "  Description", "Amount", "Incident", "Claim", "Valid");
            //Console.WriteLine("{0,-4}{1,-10}{2,-45}{3,7}{4,-11}{5,-11}{6,5}", "ID", "Claim Type", "  Description", //"Amount", "Incident", "Claim", "Valid");

            foreach (Claim aClaim in claimsQueue)
            {
                PrintClaim(aClaim);

            }//end of foreach
            Console.WriteLine("\n");
        }//end of method ViewAllClaims

        //taking care of business
        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            //peek at the next claim, print outs its info, and request the user either mark
            //the claim processed and remove it from queue or leave it alone and return to menu
            Claim aClaim = _claimRepo.PeekClaim();

            //we have the claim, lets display it and ask the user what they want to do
            Console.WriteLine("{0,5}{1,15}{2,30}{3,12}{4,12}{5,12}{6,15}", "ID", "Claim Type", "  Description", "Amount", "Incident", "Claim", "Valid");
            PrintClaim(aClaim);
            Console.WriteLine();
            Console.WriteLine("please enter one of the following choices:");
            Console.WriteLine("1: Mark Claim Complete and Remove from Queue.\n" +
                "2: Leave Claim in Queue and Return to Menu.");

            //get that input
            string userInput = Console.ReadLine();

            //now do something about it
            string userMessage;
            if (userInput == "1")
            {
                //yay, user said to get rid of the Claim
                _claimRepo.DequeueClaim();
                //should have popped the first in line right our and reduced the size of the queue
                userMessage = "Claim Removed\nReturning to MainMenu";

            }//end of if user entered 1
            else
            {
                userMessage = "Claim not Removed\nReturning to Main Menu";
            }//end of else user entered something else

            //now output the userMessage
            Console.WriteLine(userMessage);

        }//end of method TakeCareOfNextClaim


        //like the add method

        private void Add()
        {
            Console.Clear();

            //this is the beast of a method, we need to get a lot of input from the user and
            //then need to save it to a Claim and THEN add the claim to the queue
            //Console.ReadLine();


            Console.WriteLine("Please enter the following information:");
            Console.WriteLine("A number for the Claim ID:");
            int anID = int.Parse(Console.ReadLine());

            Console.WriteLine("The type of Claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3: Theft");

            //create a loop that only exits when user has inputed a valid number
            int userInputType = 0;
            while ((userInputType < 1) || (userInputType > 3))
            {
                //not really validated, user can enter all kinds of non-numeric values
                userInputType = int.Parse(Console.ReadLine());

            }//end of while user needs to enter valid number

            //only get here if the user gave us a number from 1-3
            ClaimType aTypeOfClaim = (ClaimType)userInputType;
            //should now be the enum

            Console.WriteLine("The Description of the Claim");
            string aDescription = Console.ReadLine();

            Console.WriteLine("The dollar amount of the Claim");
            float aClaimAmount = float.Parse(Console.ReadLine());

            //the claim date and incident date will be gotten, and the time between the two
            //will be calculated, and if the claim is less than 30 days since the incident
            //it will be valid, otherwise no

            //get the date of the incident
            Console.WriteLine("The Date of the Incident");
            Console.WriteLine("Enter the number of the Month");
            int aMonth = int.Parse(Console.ReadLine());
            //really really not validated
            Console.WriteLine("Enter the number of the Day");
            int aDay = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of the Year");
            int aYear = int.Parse(Console.ReadLine());
            DateTime anIncidentDate = new DateTime(aYear, aMonth, aDay);


            //and now again for the claim date
            Console.WriteLine("The Date of the Claim");
            Console.WriteLine("Enter the number of the Month");
            aMonth = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of the Day");
            aDay = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of the Year");
            aYear = int.Parse(Console.ReadLine());
            DateTime aClaimDate = new DateTime(aYear, aMonth, aDay);

            //now to see if it is valid
            bool aStatus;
            TimeSpan elapsedTime = aClaimDate.Subtract(anIncidentDate);
            if (elapsedTime.Days > 30)
            {
                aStatus = false;
                Console.WriteLine("Claim not Valid");
            }//end of if claim is plus 30 days 
            else
            {
                aStatus = true;
                Console.WriteLine("Claim Valid");
            }//end of else is valid timespan


            //ok, we have all the info, lets create a claim  with these properties and enqueue it

            Claim aClaim = new Claim(anID, aTypeOfClaim, aDescription, aClaimAmount, anIncidentDate, aClaimDate, aStatus);
            //now that we have a claim made, lets store it in the repository

            _claimRepo.Add(aClaim);


        }//end of method add

        //and the exit method
        private void ExitProgram()
        {
            Console.Clear();
            Console.WriteLine("Exiting Program");

        }//end of method ExitProgram

        //helper method, so I don't write the same code to many times
        private void PrintClaim(Claim aClaim)
        {
            Console.WriteLine($"{aClaim.ClaimID,5}\t" +
                    $"{aClaim.TypeOfClaim.ToString(),10}\t" +
                    $"{aClaim.Description,30}\t" +
                    $"{aClaim.ClaimAmount,6}\t" +
                    $"{aClaim.DateOfIncident.ToShortDateString(),10}\t" +
                    $"{aClaim.DateOfClaim.ToShortDateString(),10}\t" +
                    $"{aClaim.IsValid.ToString(),5}");

            /*Console.WriteLine($"{aClaim.ClaimID,4}\t" +
                    $"{aClaim.TypeOfClaim.ToString(),-10}\t" +
                    $"{aClaim.Description,-45}\t" +
                    $"{aClaim.ClaimAmount,7}\t" +
                    $"{aClaim.DateOfIncident.ToShortDateString(),-11}\t" +
                    $"{aClaim.DateOfClaim.ToShortDateString(),-11}\t" +
                    $"{aClaim.IsValid.ToString(),5}");*/


        }//end of method PrintClaim


    }//end of class ProgramUI
}
