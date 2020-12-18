using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3Badge_Repository
{
    public class Badge
    {
        //only two fields

        public int BadgeID { get; set; }

        public List<string> DoorList { get; set; }

        //an empty constructor
        public Badge() { }

        public Badge(int anID, List<string> aList)
        {
            BadgeID = anID;
            DoorList = aList;

        }//end of overloaded constructor



    }//end of class Badge

    public class BadgeRepository
    {
        //we're storing the badges in a Dictionary
        private Dictionary<int, Badge> _BadgeDictionary = new Dictionary<int, Badge>();
        //we will use the ID as the key and store the actual badge as the value
        //the instructions make it sound like we will actual store the list of doors as the value
        //but this seems unnecessarily complicated. the repo will still have to return a badge,
        //and to have taken the two pieces and stored them in a dictionary, only to combine them
        //again as an actual badge on command .. silly
        
        //crud
        //create a new badge 
        public bool Add(Badge aBadge)
        {
            //the add
            _BadgeDictionary.Add(aBadge.BadgeID, aBadge);
            
            //check that it is there
            if ((_BadgeDictionary.ContainsKey(aBadge.BadgeID)) && (_BadgeDictionary.ContainsValue(aBadge)))
            {
                //this should only be gotten to if the key and the value are both in the dictionary
                return true;

            }//end of if contains the key and the value
            else
            {
                //something went wrong and so we return false
                return false;
            }

        }//end of method Add
        
        //read methods

        //get the whole dictionary
        public Dictionary<int, Badge> ReturnDictionary()
        {

            return _BadgeDictionary;

        }//end of method ReturnDictionary

        //get a specific badge
        public Badge ReturnBadge(int anID)
        {
            if (_BadgeDictionary.ContainsKey(anID))
            {

                return _BadgeDictionary[anID];

            }//end of 
            else
            {
                return null;
            }//end of else does not contain the key

        }//end of method ReturnBadge

        //thats the only way we are going to give the user to get a badge
        //they need to have the ID number

        //update 
       


        public bool? UpdateBadge(int anID, Badge NewBadge)
        {

            //we will be given an ID
            if (_BadgeDictionary.ContainsKey(anID))
            {
                //the ID exists so get the badge
                //or dont
                //Badge aBadge = _BadgeDictionary[anID];

                //we are going to change the Badge now with the new badge pieces
                //aaand since the key can never actually be changed, we have to take the old out
                //and replace it by adding the new badge
                _BadgeDictionary.Remove(anID);
                _BadgeDictionary.Add(anID, NewBadge);
                if(_BadgeDictionary.ContainsKey(NewBadge.BadgeID) && _BadgeDictionary.ContainsValue(NewBadge))
                {

                    //seems that the dictionary contains the key and value, and we're going to 
                    //assume they are an actual pair...
                    return true;

                }//end of if dictionary contains key and value
                else
                {
                    //doesnt seem to have worked
                    return false;
                }//end of else

            }//end of if key exists
            else
            {
                //aaaand our dictionary doesn't have that ID
                return null;
            }

        }//end of method UpdateBadge

        //our delete method
        public bool? Delete(int anID)
        {
            if (_BadgeDictionary.ContainsKey(anID))
            {
                bool successFlag = _BadgeDictionary.Remove(anID);
                
                return successFlag;  

            }//end of if id exists
            else
            {
                return null;
            }//end of else doesnt exist



        }//end of 




    }//end of class BadgeRepository



}
