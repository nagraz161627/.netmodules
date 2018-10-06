using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Entity;
using Exception;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class GuestValidations
    {
        private static bool ValidateGuest(Guest guest)
        {
            StringBuilder sb = new StringBuilder();
            bool validGuest = true;
            if (guest.GuestID <= 0)
            {
                validGuest = false;
                sb.Append(Environment.NewLine + "Invalid Guest ID");
            }

            if (guest.GuestName == string.Empty)
            {
                validGuest = false;
                sb.Append(Environment.NewLine + "Guest Name Required");
            }
            if (!(Regex.IsMatch(guest.GuestName, @"^[a-zA-Z ]+$")))
            {
                validGuest = false;
                sb.Append(Environment.NewLine + "Guest Name should contain only characters.");
            }
            if (!(Regex.IsMatch(guest.GuestContactNumber, @"^[0-9]+$")))
            {
                validGuest = false;
                sb.Append(Environment.NewLine + "Contact number should contain only numbers.");
            }
            if (guest.GuestContactNumber.Length != 10)
            {
                validGuest = false;
                sb.Append(Environment.NewLine + "Required 10 Digit Contact Number");
            }
            if (validGuest == false)
                throw new GuestPhoneBookException(sb.ToString());
            return validGuest;
        }

        public static bool AddGuest(Guest newGuest)
        {
            bool guestAdded = false;
            try
            {
                if (ValidateGuest(newGuest))
                {
                    guestAdded = GuestOperations.AddGuest(newGuest);
                }
            }
            catch (GuestPhoneBookException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return guestAdded;
        }

        public static List<Guest> ReturnGuestInformation()
        {
            return GuestOperations.ReturnGuestInformation();
        }

        //Function to delete Guest
        public static bool DeleteGuest(int GuestID)
        {
            bool GuestDeleted = true;
            Guest GuestToBeDeleted = null;

            try
            {
                //Search Guest in the records
                GuestToBeDeleted = GuestOperations.SearchGuest(GuestID);

                //If Guest is not null delete Guest otherwise raise exception
                if (GuestToBeDeleted != null)
                {
                    GuestDeleted = GuestOperations.DeleteGuest(GuestToBeDeleted);
                }
                else
                {
                    GuestDeleted = false;
                    throw new GuestPhoneBookException("Guest Info does not exists to delete");
                }
            }
            catch (GuestPhoneBookException p)
            {
                throw;
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }

            return GuestDeleted;
        }

        //Function to search Guest Info using Guest ID
        public static Guest  SearchGuest(int GuestID)
        {
            Guest  guestSearched = null;

            try
            {
                //Searching Guest
                guestSearched = GuestOperations.SearchGuest(GuestID);

                //If searched guest is null raise exception
                if (guestSearched == null)
                {
                    throw new GuestPhoneBookException("Guest Info does not exist!");
                }
            }
            catch (GuestPhoneBookException p)
            {
                throw;
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }

            return guestSearched;
        }

        //Function to display all Guest details
        public static List<Guest> DisplayGuest()
        {
            List<Guest> guestList = null;

            try
            {
                guestList  = GuestOperations.DisplayGuestFromFile ();

                //Check guest list is empty or not, if it is then raise exception
                if (guestList == null)
                {
                    throw new GuestPhoneBookException ("Guest List is Empty!");
                }
            }
            catch (GuestPhoneBookException  p)
            {
                throw;
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }

            return guestList ;
        }

        //Function to update Guest
        public static bool UpdateGuest(Guest guestToBeUpdated)
        {
            bool guestUpdated = true;

            try
            {
                //Searching Guest, if found update or raise exception
                if (GuestOperations.SearchGuest(guestToBeUpdated.GuestID ) != null)
                {
                    //validating Guest, if valid update o.w. raise exception
                    if (ValidateGuest(guestToBeUpdated))
                    {
                        guestUpdated = GuestOperations.Updateguest(guestToBeUpdated);
                    }
                    else
                    {
                        guestUpdated = false;
                        throw new GuestPhoneBookException("Guest Info is not updated because it is not valid!");
                    }
                }
                else
                {
                    guestUpdated = false;
                    throw new GuestPhoneBookException("Guest id not exists for update!");
                }
            }
            catch (GuestPhoneBookException  e)
            {
                throw;
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }

            return guestUpdated;
        }

        public static void SerializeData()
        {
            GuestOperations.SerializeData();
        }
        public static List<Guest > DisplayFromFile()
        {
            List<Guest> guestlist = GuestOperations.DisplayGuestFromFile();
            return guestlist;
        }
    }
}
