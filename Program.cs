using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Exception;
using BusinessLogicLayer;

namespace PresentationLayer
{
   

        /// <summary>
        /// Purpose: This class is used for the working functionalities and also the main function, from which, the user will input data and run the whole program, to store, retrieve and save in file and fetch from file.
        /// Author Name: IGate
        /// Created On: 10/1/2015
        /// </summary>
        class GuestPresentation
        {
            //Method to Add a Guest and calling the validation methods from the GuestBiz class
            public static void AddGuest()
            {
                try
                {
                    //Creating object of Guest class to access the values being stored through the properties
                    Guest newGuest = new Guest();

                    //User Inputs
                    Console.Write("Enter Guest ID : ");
                    newGuest.GuestID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Guest Name : ");
                    newGuest.GuestName = Console.ReadLine();
                    Console.Write("Enter Guest Contact No : ");
                    newGuest.GuestContactNumber = Console.ReadLine();
                    
                    //Checking if all validations by calling the GuestBL class to use it's function AND using are true AND using NAMED ARGUMENTS
                    bool GuestAdded = GuestValidations.AddGuest(newGuest);
                    if (GuestAdded == true)
                        Console.WriteLine("Guest Added Successfully!");
                    else
                        throw new GuestPhoneBookException("Guest not added! Please try again following the validations mentioned!");
                }
                //Catching user defined exception
                catch (GuestPhoneBookException p)
                {
                    Console.WriteLine(p.Message);
                }

                    //Catching System exception
                catch (SystemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //Method to Delete a Guest and calling the validation methods from the GuestBiz class
            public static void DeleteGuest()
            {
                int GuestID;
                bool GuestDeleted;

                try
                {
                    //User Inputs
                    Console.Write("Enter the Guest ID to be deleted : ");
                    GuestID = Convert.ToInt32(Console.ReadLine());
                    //Calling the GuestBL class to use it's function AND using NAMED ARGUMENTS
                    GuestDeleted = GuestValidations.DeleteGuest(GuestID);

                    if (GuestDeleted == true)
                        Console.WriteLine("Guest Deleted Successfully!");
                    else
                        throw new GuestPhoneBookException("Guest not deleted!");
                }
                //Catching User defined exception
                catch (GuestPhoneBookException p)
                {
                    Console.WriteLine(p.Message);
                }
                //Catching System exception
                catch (SystemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            public static void SearchGuest()
            {
                int GuestID;
                Guest searchedGuest;

                try
                {
                    Console.Write("Enter Guest ID for search : ");
                    GuestID = Convert.ToInt32(Console.ReadLine());

                    //Checking if all validations by calling the GuestBiz class to use it's function AND using are true AND using NAMED ARGUMENTS
                    searchedGuest = GuestValidations.SearchGuest(GuestID: GuestID);

                    if (searchedGuest != null)
                    {
                        Console.WriteLine("Guest ID   : " + searchedGuest.GuestID);
                        Console.WriteLine("Guest Name : " + searchedGuest.GuestName);
                        Console.WriteLine("Guest Phone: " + searchedGuest.GuestContactNumber);
                        
                    }
                    else
                    {
                        throw new GuestPhoneBookException("Guest not found!");
                    }
                }
                //Catching User defined exception
                catch (GuestPhoneBookException p)
                {
                    Console.WriteLine(p.Message);
                }
                //Catching System exception
                catch (SystemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //Method to Display a Guest and calling the validation methods from the GuestBiz class
            public static void DisplayGuest()
            {
                //Creating List object to store n number of inputs from the user
                List<Guest> GuestList = new List<Guest>();

                try
                {
                    GuestList = GuestValidations.DisplayFromFile();
                    if (GuestList.Count > 0)
                    {
                        Console.WriteLine("*******************All Guest Detail****************");
                        Console.WriteLine("Guest ID     -    Guest Name   -    Guest Contact No   ");
                        Console.WriteLine("--------------------------------------------------------");
                        foreach (Guest p in GuestList)
                        {
                            Console.WriteLine(p.GuestID + "\t\t\t" + p.GuestName + "\t\t\t" + p.GuestContactNumber);
                        }
                    }
                    else
                    {
                        throw new GuestPhoneBookException("There are no records!");
                    }
                }
                //Catching User defined exception
                catch (GuestPhoneBookException p)
                {
                    Console.WriteLine(p.Message);
                }
                //Catching System exception
                catch (SystemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            //Method to Update a Guest and calling the validation methods from the GuestBiz class
            public static void UpdateGuest()
            {
                Guest GuestToBeUpdated = new Guest();
                bool GuestUpdated;

                try
                {

                    //User inputs
                    Console.Write("Enter Guest ID for which you would like to update the record : ");
                    GuestToBeUpdated.GuestID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Guest Name to be updated : ");
                    GuestToBeUpdated.GuestName = Console.ReadLine();
                    Console.Write("Enter Guest Phone Number to be updated : ");
                    GuestToBeUpdated.GuestContactNumber = Console.ReadLine();
                  
                    //Checking if all validations by calling the GuestBL class to use it's function AND using are true AND using NAMED ARGUMENTS
                    GuestUpdated = GuestValidations.UpdateGuest(GuestToBeUpdated );

                    //Checking if validations are true or not
                    if (GuestUpdated == true)
                        Console.WriteLine("Guest Updated Successfully!");
                    else
                        throw new GuestPhoneBookException("Guest not updated!");
                }
                //Catching User defined exception
                catch (GuestPhoneBookException p)
                {
                    Console.WriteLine(p.Message);
                }
                //Catching System exception
                catch (SystemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            public static void AddRecordsToFile()
            {
                GuestValidations.SerializeData();
                Console.WriteLine("Records Serialized and Successfully added to the file");
                Console.WriteLine();
            }

            //
            private static void ListAllGuests()
            {
                List<Guest> Guests = GuestValidations.ReturnGuestInformation();
                foreach (Guest Guest in Guests)
                {
                    Console.WriteLine("Guest ID is : {0}", Guest.GuestID);
                    Console.WriteLine("Guest Name is : {0}", Guest.GuestName);
                    Console.WriteLine("Guest Phone is : {0}", Guest.GuestContactNumber);
                    
                }
            }

            //Method to print menu to the user for user's choice
            public static void PrintMenu()
            {
                Console.WriteLine();
                Console.WriteLine("*************Guest Menu*************");
                Console.WriteLine("1.  Add Guest - Press 1,");
                Console.WriteLine("2.  Delete Guest - Press 2,");
                Console.WriteLine("3.  Search Guest - Press 3,");
                Console.WriteLine("4.  Display All Guests - Press 4,");
                Console.WriteLine("5.  Add Guest records to file - Press 5,");
                Console.WriteLine("6.  Display Guest records from file - Press 6,");
                Console.WriteLine("7.  Update  Guest - Press 7,");
                Console.WriteLine("8.  Exit");
                Console.WriteLine("**************************************");
            }

            //Main method to call all the functions as per the need of the user
            static void Main(string[] args)
            {
                int choice;

               // Attribute[] arr = Attribute.GetCustomAttributes(typeof(Guest), typeof(GuestCategoryAttribute));


                do
                {
                    //Calling PrintMenu() function to print menu
                    PrintMenu();

                    bool validchoice;
                    Console.Write("Enter your choice please : ");
                    validchoice  = Int32.TryParse (Console.ReadLine(),out choice );

                    //Switch case to allow the user choose the option as per choice
                   if(!validchoice)
                   Console.WriteLine("Enter the Choice from 1-8");
                   else
                   {
                    switch (choice)
                    {
                        case 1: AddGuest();
                            break;
                        case 2: DeleteGuest();
                            break;
                        case 3: SearchGuest();
                            break;
                        case 4: ListAllGuests();
                            break;
                        case 5: AddRecordsToFile();
                            break;
                        case 6: DisplayGuest();
                            break;
                        case 7: UpdateGuest();
                            break;
                        case 8: break;
                        default: Console.WriteLine("Invalid Choice!");
                            break;
                    }
                    //While loop to ensure the program runs as per user's choice, unit he/she presses exit
                }} while (choice != 8);
            }
                
                }
        }

        
    




    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int choice;
    //        do
    //        {
    //            PrintMenu();
    //            Console.WriteLine("Enter your Choice:");
    //            choice = Convert.ToInt32(Console.ReadLine());
    //            switch (choice)
    //            {
    //                case 1:
    //                    AddGuest();
    //                    break;
    //                case 2:
    //                    ListAllGuests();
    //                    break;
    //                case 3:
    //                    return;
    //                default:
    //                    Console.WriteLine("Invalid Choice");
    //                    break;
    //            }
    //        } while (choice != -1);
    //    }

    //    private static void PrintMenu()
    //    {
    //        Console.WriteLine("\n***********Guest PhoneBook Menu***********");
    //        Console.WriteLine("1. Add Guest");
    //        Console.WriteLine("2. List All Guests");
    //        Console.WriteLine("3. Exit");
    //        Console.WriteLine("******************************************\n");
    //    }

    //    private static void AddGuest()
    //    {
    //        try
    //        {
    //            int guestId;
    //            bool validGuestId;
    //            Guest newGuest = new Guest();
    //            Console.WriteLine("Enter GuestID :");
    //            validGuestId = int.TryParse(Console.ReadLine(), out guestId);
    //            if (!validGuestId||guestId<=0)
    //            {
    //                Console.WriteLine("Please enter only positive numbers in guest id field");
    //            }
    //            else
    //            {
    //                newGuest.GuestID = guestId;
    //                Console.WriteLine("Enter Guest Name :");
    //                newGuest.GuestName = Console.ReadLine();
    //                Console.WriteLine("Enter PhoneNumber :");
    //                newGuest.GuestContactNumber = Console.ReadLine();
    //                bool guestAdded = GuestValidations.AddGuest(newGuest);
    //                if (guestAdded)
    //                {
    //                    Console.WriteLine("Guest Added");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("Guest not Added");
    //                }
    //            }
                
    //        }
    //        catch (GuestPhoneBookException ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }

    //    private static void ListAllGuests()
    //    {
    //        List<Guest> guests = GuestValidations.ReturnGuestInformation();
    //        foreach (Guest guest in guests)
    //        {
    //            Console.WriteLine("Guest ID={0}", guest.GuestID);
    //            Console.WriteLine("Guest Name={0}", guest.GuestName);
    //            Console.WriteLine("Guest Contact No={0}", guest.GuestContactNumber);
    //        }
    //    }
    //}

