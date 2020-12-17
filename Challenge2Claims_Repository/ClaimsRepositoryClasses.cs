using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2Claims_Repository
{

    //an enum
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }//end of enum ClaimType


    //our claim poco
    public class Claim
    {

        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public float ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        //a constructor
        public Claim() { }

        //we'll need another, overloaded constructor will arguments
        public Claim(int aClaimID, ClaimType aTypeOfClaim, string aDescription, float aClaimAmount, DateTime anIncidentDate, DateTime aClaimDate, bool aStatus)
        {
            ClaimID = aClaimID;
            TypeOfClaim = aTypeOfClaim;
            Description = aDescription;
            ClaimAmount = aClaimAmount;
            DateOfIncident = anIncidentDate;
            DateOfClaim = aClaimDate;
            IsValid = aStatus;

        }//end of overloaded constructor

        //so now we can either make an empty claim or instantiate one completely

    }//end of class claim



    //and our repo class fro to hold the claims
    public class ClaimRepository
    {
        //this will contain a queue of claims, a first in first out container
        private Queue<Claim> _queueOfClaims = new Queue<Claim>();

        //and now some methods
        //crud in this case has an add, a get entire queue, and see the next claim, an erase 
        //the next claim, there are no updates really, the items in the queue cannot be changed
        //or rearranged

        //add
        public bool Add(Claim aClaim)
        {

            _queueOfClaims.Enqueue(aClaim);

            if (_queueOfClaims.Contains(aClaim))
            {
                return true;
            }
            else
            {
                return false;
            }
        }//end method Add


        //our read
        public Queue<Claim> ReturnQueue()
        {

            return _queueOfClaims;

        }//end of method ReturnQueue

        //and now the return the next Claim

        //our other read
        public Claim PeekClaim()
        {
            //takes no argument because you MUST handle the next claim

            return _queueOfClaims.Peek();

        }//end of method PeekClaim

        //this one DOES take an argument, and sees if the claim is in the queue
        public bool ContainsClaim(Claim aClaim)
        {
            if (_queueOfClaims.Contains(aClaim))
            {
                return true;
            }//end of if contains
            return false;

        }//end of method ContainsClaim



        //our delete method, removes the next claim from the queue
        public Claim DequeueClaim()
        {
            //again, can only be the first

            return _queueOfClaims.Dequeue();

        }//end of method DequeueClaim




    }//end of class ClaimRepository






}
