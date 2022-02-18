using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using FMS.BL;
using FMS.Entity;
using FMS.Exception;


namespace FacultyInformationSystem
{
    class Program
    {
        #region ColorMethods
        //Print output in yellow color
        public static void CallYellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        //Print output in white color
        public static void CallWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        //Print output in green color
        public static void CallGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        //Print output in cyan color
        public static void CallCyan()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        //Print output in red color
        public static void CallRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        #endregion


        


   

        
        

        #region PrintingMenu




        //print menu for student
        public static void PrintStudentMenu()
        {
            Console.Clear();
            // CallTitle();
            CallCyan();
            Console.WriteLine("1)Search for publication");
        }


        //Print menu for admin
        public static void printAdminMenu()
        {
            Console.Clear();
            //  CallTitle();
            CallRed();
            Console.WriteLine("Administrator menu");
            Console.WriteLine();
            CallCyan();
            Console.WriteLine("1)Add new User");
            Console.WriteLine("2)Add new Department");
            Console.WriteLine("3)Add new Designation");
            Console.WriteLine("4)Add/Update/Delete Courses");
            Console.WriteLine("5)Add/Update/Delete Subjects");
            Console.WriteLine("6)Print Faculty information");
            Console.WriteLine("7)Change Faculty Current Job Info");
            Console.WriteLine("8)Print Publications");

        }


        //Print menu for faculty
        public static void printfacultymenu()
        {

            Console.Clear();
            // CallTitle();
            CallRed();
            Console.WriteLine("Faculty Menu");
            CallCyan();
            Console.WriteLine();
            Console.WriteLine("1)Personal Information");
            Console.WriteLine("2)JobHistory");
            Console.WriteLine("3)Publications");
            Console.WriteLine("4)Courses Taught");
            Console.WriteLine("5)Faculty Grants");


        }

        #endregion


        #region TakingInputsMethods


        //taking input for faculty's  personal information
        public static void TakeDetails(Faculty faculty)
        {
            CallGreen();
            Console.Write("Enter the Faculty ID: ");
            CallWhite();
            faculty.FacultyID = Convert.ToInt32(Console.ReadLine());
            CallGreen();
            Console.Write("Enter the firstname: ");
            CallWhite();
            faculty.FirstName = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the lastname: ");
            CallWhite();
            faculty.LastName = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the Adress: ");
            CallWhite();
            faculty.Address = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the City: ");
            CallWhite();
            faculty.City = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the State: ");
            CallWhite();
            faculty.State = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the Pincode: ");
            CallWhite();
            faculty.Pincode = Convert.ToInt32(Console.ReadLine());
            CallGreen();
            Console.Write("Enter the MobileNumber: ");
            CallWhite();
            faculty.MoblieNo = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the HireDate: ");
            CallWhite();
            faculty.HireDate = Convert.ToDateTime(Console.ReadLine());
            CallGreen();
            Console.Write("Enter the EmailAddress: ");
            CallWhite();
            faculty.EmailAddress = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the DateOfBirth: ");
            CallWhite();
            faculty.DateofBirth = Convert.ToDateTime(Console.ReadLine());
            CallGreen();
            Console.Write("Enter the DeptID: ");
            CallWhite();
            faculty.DeptID = Convert.ToInt32(Console.ReadLine());
            CallGreen();
            Console.Write("Enter the DesignationID: ");
            CallWhite();
            faculty.DesignationID = Convert.ToInt32(Console.ReadLine());
        }

        //taking input for faculty's workhistory details
        public static void WorkDetails(WorkHistory work)
        {
            CallGreen();
            Console.Write("Enter the workhistory id : ");
            CallWhite();
            work.WorkHistoryID = Convert.ToInt32(Console.ReadLine());
            CallGreen();
            Console.Write("Enter the FacultyId : ");
            CallWhite();
            work.FacultyID = Convert.ToInt32(Console.ReadLine());
            CallGreen();
            Console.Write("Enter the Organisation : ");
            CallWhite();
            work.Organization = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the JobTitle : ");
            CallWhite();
            work.JobTitle = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the JobBeginDate : ");
            CallWhite();
            work.JobBeginDate = Convert.ToDateTime(Console.ReadLine());
            CallGreen();
            Console.Write("Enter the JobEndDate : ");
            CallWhite();
            work.JobEndDate = Convert.ToDateTime(Console.ReadLine());
            CallGreen();
            Console.Write("Enter the JobResponsibilities : ");
            CallWhite();
            work.JobResponsibilities = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the Jobtype : ");
            CallWhite();
            work.JobType = Console.ReadLine();

        }

        //taking input for faculty's  publication details
        public static void PublicationDetails(Publications publications)
        {
            CallGreen();
            Console.Write("Enter the Publication ID : ");
            CallWhite();
            publications.PublicationID = Convert.ToInt32(Console.ReadLine());
            CallGreen();
            Console.Write("Enter the faculty id : ");
            CallWhite();
            publications.FacultyID = Convert.ToInt32(Console.ReadLine());
            CallGreen();
            Console.Write("Enter the PublicationTitle : ");
            CallWhite();
            publications.PublicationTitle = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the ArticleName : ");
            CallWhite();
            publications.ArticleName = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the Publisher Name : ");
            CallWhite();
            publications.PublisherName = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the Publisher Location : ");
            CallWhite();
            publications.PublicationLocation = Console.ReadLine();
            CallGreen();
            Console.Write("Enter the Citation Date : ");
            CallWhite();
            publications.CitationDate = Convert.ToDateTime(Console.ReadLine());

        }

        #endregion


        #region ReadingPasswordMethod


        //method for read password
        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int position = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(position - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(position - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }
        #endregion

        public static string LoginAs()
        {
            string loginusertype = string.Empty;
            try
            {
                CallCyan();
                Console.WriteLine("1)Faculty");
                Console.WriteLine("2)Admin");
                Console.WriteLine("3)Student");

                CallGreen();
                Console.Write("Enter your choice : ");
                CallWhite();
                int loginas = Convert.ToInt32(Console.ReadLine());

                if (loginas == 1)
                {
                    loginusertype = "faculty";
                }
                else if (loginas == 2)
                {
                    loginusertype = "admin";
                }
                else if (loginas == 3)
                {
                    loginusertype = "student";
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return loginusertype;

        }

        #region MainMethod

        //Main method 
        static void Main(string[] args)
        {



            

            string loginusertype = LoginAs();





        }
        #endregion
    }
}
