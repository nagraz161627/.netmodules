using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Exception;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary ;

namespace DataAccessLayer
{
    public class GuestOperations
    {
        public static List<Guest> guestList = new List<Guest>();

        public static bool AddGuest(Guest guestObj)
        {
            bool guestAdded = false;
            try
            {
                guestList.Add(guestObj);
                guestAdded = true;
            }
            catch (GuestPhoneBookException)
            {
                throw;
            }
            return guestAdded;
        }

        public static List<Guest> ReturnGuestInformation()
        {
            return guestList;
        }


        //Function to delete guest from the list
        public static bool DeleteGuest(Guest guestToBeDeleted)
        {
            try
            {
                //Removing guest from the list
                guestList.Remove(guestToBeDeleted);
                return true;
            }
            catch (SystemException e)
            {
                throw;
            }
        }

        //Function to search 
        public static Guest  SearchGuest(int guestID)
        {
            try
            {
                //To store details of searched guest
                Guest searchedguest = null;

              /*  foreach (var guest in guestList)
                {
                    //Cheking the guest ID
                    if (guest.GuestID == guestID)
                    {
                        //If guest found store the guest details to searchedguest
                        searchedguest = guest;
                    }
                }*/
                  searchedguest = guestList.Find(p => p.GuestID  == guestID );//null;
                
                return searchedguest;
            }
            catch (Exception.GuestPhoneBookException  e)
            {
                throw;
            }
        }
        
       

        //Function to update guest details in list
        public static bool Updateguest(Guest guestToBeUpdated)
        {
            bool guestUpdated = false;

            for (var i = 0; i < guestList.Count; i++)
            {
                //Find the guest to be updated & update record
                if (guestList[i].GuestID == guestToBeUpdated.GuestID)
                {
                    guestList[i].GuestName = guestToBeUpdated.GuestName;
                    guestList[i].GuestContactNumber  = guestToBeUpdated.GuestContactNumber;
                    guestUpdated = true;
                }
            }

            return guestUpdated;
        }

        public static void SerializeData()
        {
            FileStream stream;
            try
            {
                stream = new FileStream("guest.txt", FileMode.Create, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, guestList);
               stream.Close();
            }
            catch (IOException e)
            {
                throw e;
            }
            
        }
        public static List<Guest> DeserializeData()
        {
            FileStream stream = new FileStream("guest.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            guestList = formatter.Deserialize(stream) as List<Guest >;
            return guestList;
        }
        public static List<Guest> DisplayGuestFromFile()
        {
            guestList = DeserializeData();
            return guestList;
        }


    }
}
