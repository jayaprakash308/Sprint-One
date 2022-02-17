using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using FMS.BL;
using FMS.Entity;
using FMS.Exceptions;


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


        //#region Banner
        ////Print project title
        //public static void CallTitle()
        //{
        //    CallYellow();
        //    Console.WriteLine(@"         ___             _ _          ___       __                    _   _            ___         _              ");
        //    Console.WriteLine(@"        | __|_ _ __ _  _| | |_ _  _  |_ _|_ _  / _|___ _ _ _ __  __ _| |_(_)___ _ _   / __|_  _ __| |_ ___ _ __  ");
        //    Console.WriteLine(@"        | _/ _` / _| || | |  _| || |  | || ' \|  _/ _ \ '_| '  \/ _` |  _| / _ \ ' \  \__ \ || (_-<  _/ -_) '  \ ");
        //    Console.WriteLine(@"        |_|\__,_\__|\_,_|_|\__|\_, | |___|_||_|_| \___/_| |_|_|_\__,_|\__|_\___/_||_| |___/\_, /__/\__\___|_|_|_|");
        //    Console.WriteLine(@"                               |__/                                                        |__/                  ");
        //    CallGreen();

        //}
        //#endregion


        #region PrintingTableDesign

        //print line
        static void PrintLine(int tableWidth)
        {
            Console.WriteLine(new string('-', tableWidth));
        }


        //Printing row
        static void PrintRow(int tableWidth, params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";
            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }


        //Set alignment to the text
        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;



            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        #endregion


        #region PrintingOutputMethods


        //print output for coursestaught by faculty
        public static void PrintCoursesTaught(ArrayList courseTaughtList)
        {

            int tableWidth = 120;
            CallRed();
            PrintLine(tableWidth);
            PrintRow(tableWidth, "CourseID", "FacultyID", "SubjectID", "FirstDateTaught");
            PrintLine(tableWidth);
            CallCyan();
            for (int i = 0; i < courseTaughtList.Count; i++)
            {
                CoursesTaught courseTaught = (CoursesTaught)courseTaughtList[i];
                PrintRow(tableWidth, courseTaught.CourseID.ToString(), courseTaught.FacultyID.ToString(), courseTaught.SubjectID.ToString(), courseTaught.FirstDateTaught.ToString());
                PrintLine(tableWidth);

            }
            CallGreen();
        }

        //print grants/awards achieved by faculty
        public static void PrintGrantsArray(ArrayList grantsList)
        {
            CallCyan();
            CallRed();
            int tableWidth = 120;
            PrintLine(tableWidth);
            PrintRow(tableWidth, "GrantID", "GrantTitle", "GrantDescription", "FacultyID");
            PrintLine(tableWidth);
            CallCyan();
            for (int i = 0; i < grantsList.Count; i++)
            {
                Grants grants = (Grants)grantsList[i];
                PrintRow(tableWidth, grants.GrantID.ToString(), grants.GrantTitle, grants.GrantDescription, grants.FacultyID.ToString());
                PrintLine(tableWidth);
            }
            CallGreen();
        }



        //Print workhistory details of faculty
        public static void PrintWorkHistory(ArrayList workList)
        {

            int tableWidth = 120;
            CallRed();
            PrintLine(tableWidth);
            PrintRow(tableWidth, "WorkHistoryID", "Organization", "Jobtitle", "JobBeginDate", "JobEndDate", "JobResponsibilities", "JobType", "FacultyID");
            PrintLine(tableWidth);
            CallCyan();
            for (int i = 0; i < workList.Count; i++)
            {
                WorkHistory workHistory = (WorkHistory)workList[i];

                PrintRow(tableWidth, workHistory.WorkHistoryID.ToString(), workHistory.Organization, workHistory.JobTitle, workHistory.JobBeginDate.ToString(), workHistory.JobEndDate.ToString(), workHistory.JobResponsibilities, workHistory.JobType, workHistory.FacultyID.ToString());
                PrintLine(tableWidth);

            }
            CallGreen();

        }


        //Print the publication details
        public static void PrintPublicationsArray(ArrayList publicationList)
        {

            int tableWidth = 120;
            CallRed();
            PrintLine(tableWidth);
            PrintRow(tableWidth, "PublicationID", "PublicationTitle", "ArticleName", "PublisherName", "CitationDate", "FacultyID");
            PrintLine(tableWidth);
            CallCyan();
            for (int i = 0; i < publicationList.Count; i++)
            {

                Publications publication = (Publications)publicationList[i];
                {

                    PrintRow(tableWidth, publication.PublicationID.ToString(), publication.PublicationTitle, publication.ArticleName, publication.PublisherName, publication.CitationDate.ToString(), publication.FacultyID.ToString());
                    PrintLine(tableWidth);

                }
            }
            CallGreen();
        }




        //Print the faculty information
        public static void PrintFacultyInfo(Faculty faculty)
        {

            int tableWidth = 225;
            CallRed();
            PrintLine(tableWidth - 4);
            PrintRow(tableWidth, "FacultyID", "FirstName", "LastName", "Address", "City", "State", "Pincode", "MobileNo", "HireDate", "EmailAddress", "DateOfBirth", "DeptID", "DesignationID");
            PrintLine(tableWidth - 4);
            CallCyan();
            PrintRow(tableWidth, faculty.FacultyID.ToString(), faculty.FirstName, faculty.LastName, faculty.Address, faculty.City, faculty.State, faculty.Pincode.ToString(), faculty.MoblieNo, faculty.HireDate.ToString(), faculty.EmailAddress,
                faculty.DateofBirth.ToString(), faculty.DeptID.ToString(), faculty.DesignationID.ToString());
            PrintLine(tableWidth - 4);


            CallGreen();
        }

        //Print faculty's all information details 
        public static void PrintAllFacultyInfo(ArrayList objList)
        {
            CallCyan();
            for (int i = 0; i < objList.Count; i++)
            {
                if (i == 0)
                {
                    //get the degree details of faculty
                    Degrees degree = (Degrees)objList[0];


                    int tableWidth = 120;
                    CallRed();
                    PrintLine(tableWidth);
                    PrintRow(tableWidth, "DegreeID", "Degree", "Specialization", "DegreeYear", "Grade");
                    PrintLine(tableWidth);
                    CallCyan();
                    PrintRow(tableWidth, degree.DegreeID.ToString(), degree.Degree, degree.Specialization, degree.DegreeYear, degree.Grade.ToString());
                    PrintLine(tableWidth);

                    CallGreen();
                }
                else if (i == 1)
                {
                    //get the publication details of faculty
                    Publications publication = (Publications)objList[1];
                    ArrayList publicationArray = new ArrayList();
                    publicationArray.Add(publication);
                    PrintPublicationsArray(publicationArray);

                }
                else if (i == 2)
                {
                    //get the workhistory details of faculty
                    WorkHistory workhistory = (WorkHistory)objList[2];

                    ArrayList workhistoryArray = new ArrayList();
                    workhistoryArray.Add(workhistory);
                    PrintWorkHistory(workhistoryArray);

                }
                else if (i == 3)
                {
                    //get the coursetaught details of faculty
                    CoursesTaught coursetaught = (CoursesTaught)objList[3];
                    ArrayList courseTaughtArray = new ArrayList();
                    courseTaughtArray.Add(coursetaught);
                    PrintCoursesTaught(courseTaughtArray);

                }
                else if (i == 4)
                {
                    //get the grant details of faculty
                    Grants grants = (Grants)objList[4];
                    ArrayList grantsArray = new ArrayList();
                    grantsArray.Add(grants);
                    PrintGrantsArray(grantsArray);
                }
            }
            CallGreen();
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



          //  CallTitle();

            string loginusertype = LoginAs();

            int access = -1;
            try
            {
                Users user = new Users();
                CallRed();
                Console.WriteLine();
                Console.WriteLine("LOGIN FORM");
                Console.WriteLine();
                CallGreen();
                Console.Write("UserName : ");
                CallWhite();
                user.UserName1 = Console.ReadLine();
                CallGreen();
                Console.Write("Password : ");
                CallWhite();
                user.Password1 = ReadPassword();
              //  user.usertype = loginusertype;


                try
                {
                    access = LoginCheckBL.LoginCheck(user);
                }
                catch (FacultyExceptions e)
                {
                    CallRed();
                    Console.WriteLine(e.Message);
                    CallGreen();
                }
                catch (Exception e)
                {
                    CallRed();
                    Console.WriteLine(e.Message);
                    CallGreen();
                }

            }
            catch (Exception e)
            {
                CallRed();
                Console.WriteLine(e.Message);
                CallGreen();
            }

            if (access == 0)
            {
                try
                {
                    //call student menu method
                    PrintStudentMenu();
                    int studentChoice = -1;

                    CallGreen();
                    Console.WriteLine();
                    Console.Write("Enter the choice: ");
                    CallWhite();
                    studentChoice = Convert.ToInt32(Console.ReadLine());



                    if (studentChoice == 1)
                    {

                        Publications publications = new Publications();


                        Console.Clear();
                       // CallTitle();
                        CallGreen();

                        Console.Write("Enter the Faculty id: ");
                        CallWhite();
                        publications.FacultyID = Convert.ToInt32(Console.ReadLine());
                        var publicationList = PublicationBL.PrintPublications(publications);
                        PrintPublicationsArray(publicationList);
                    }
                    else
                    {
                        CallRed();
                        Console.WriteLine("Please enter input according to menu");
                        CallGreen();
                    }
                }
                catch (FacultyExceptions e)
                {
                    CallRed();
                    Console.WriteLine(e.Message);
                    CallGreen();
                }
                catch (FormatException e)
                {
                    CallRed();
                    Console.WriteLine(e.Message);
                    CallGreen();
                }
                catch (Exception e)
                {
                    CallRed();
                    Console.WriteLine(e.Message);
                    CallGreen();
                }

            }


            else if (access == 1)
            {

                Users newuser = new Users();
                printAdminMenu();
                CallGreen();
                Console.WriteLine();
                Console.Write("Enter the choice: ");
                CallWhite();
                int choice = -1;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    CallRed();
                    Console.WriteLine(e.Message);
                    CallGreen();
                }


                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.Clear();
                           // CallTitle();
                            CallGreen();
                            //taking input for adding new user
                            Console.Write("Enter the new Username : ");
                            CallWhite();
                            newuser.UserName1 = Console.ReadLine();
                            CallGreen();
                            Console.Write("Enter the new Password: ");
                            CallWhite();
                            newuser.Password1 = Console.ReadLine();
                            CallGreen();
                            Console.Write("Enter the new Usertype: ");
                            CallWhite();
                          //  newuser.Usertype = Console.ReadLine();
                            CallGreen();
                            Console.Write("Enter the new UniversalID: ");
                            CallWhite();
                          //  newuser.UniversalID = Convert.ToInt32(Console.ReadLine());
                            //call method for adding new user
                            AdministatorBL.AddNewUser(newuser);
                        }
                        catch (FacultyExceptions e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (FormatException e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }

                        break;
                    case 2:
                        try
                        {
                            //taking input for adding new department
                            Department newdepartment = new Department();
                            Console.Clear();
                           // CallTitle();
                            CallGreen();
                            Console.WriteLine();
                            Console.Write("Enter the Department Name : ");
                            CallWhite();
                            newdepartment.DeptName = Console.ReadLine();
                            //call method for adding new department
                            DepartmentBL.AddDepartment(newdepartment);
                        }
                        catch (FacultyExceptions e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        break;
                    case 3:
                        try
                        {
                            //taking input for adding new designation
                            Designation newdesignation = new Designation();
                            Console.Clear();
                           // CallTitle();
                            Console.WriteLine();
                            CallGreen();
                            Console.Write("Enter the New Designation : ");
                            CallWhite();
                            newdesignation.DesignationName = Console.ReadLine();
                            //call method for adding new designation
                            AdministatorBL.AddNewDesignation(newdesignation);
                        }
                        catch (FacultyExceptions e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        break;
                    case 4:
                        Console.Clear();
                     //   CallTitle();
                        Console.WriteLine();
                        CallCyan();
                        Console.WriteLine("1)Add Course");
                        Console.WriteLine("2)Update Course");
                        Console.WriteLine("3)Delete Course");
                        try
                        {
                            //taking input for adding new course
                            CallGreen();
                            Console.WriteLine();
                            Console.Write("Enter your choice : ");
                            CallWhite();
                            int coursechoice = Convert.ToInt32(Console.ReadLine());
                            Courses newcourse = new Courses();
                            if (coursechoice == 1)
                            {
                                Console.Clear();
                              //  CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the New Course name : ");
                                CallWhite();
                                newcourse.CourseName = Console.ReadLine();
                                CallGreen();
                                Console.Write("Enter the New Course credits : ");
                                CallWhite();
                                newcourse.CourseCredits = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the dept id : ");
                                CallWhite();
                                newcourse.DeptID = Convert.ToInt32(Console.ReadLine());
                                //call method for adding new course
                                CourseBL.AddNewCourse(newcourse);
                            }
                            else if (coursechoice == 2)
                            {
                                //taking input to update new course
                                Console.Clear();
                              //  CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the course id : ");
                                CallWhite();
                                newcourse.CourseID = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the New Course name : ");
                                CallWhite();
                                newcourse.CourseName = Console.ReadLine();
                                CallGreen();
                                Console.Write("Enter the New Course credits : ");
                                CallWhite();
                                newcourse.CourseCredits = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the dept id : ");
                                CallWhite();
                                newcourse.DeptID = Convert.ToInt32(Console.ReadLine());
                                //call method to update new course
                                CourseBL.UpdateCourse(newcourse);
                            }
                            else if (coursechoice == 3)
                            {
                                //taking input to delete new course
                                Console.Clear();
                              //  CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Course id : ");
                                CallWhite();
                                newcourse.CourseID = Convert.ToInt32(Console.ReadLine());
                                //call method to delete new course
                                CourseBL.DeleteCourse(newcourse);
                            }
                        }
                        catch (FacultyExceptions e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (FormatException e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        break;

                    case 5:

                        Console.Clear();

                      //  CallTitle();
                        CallCyan();
                        Console.WriteLine();
                        Console.WriteLine("1)Add subject");
                        Console.WriteLine("2)Update Subject");
                        Console.WriteLine("3)Delete Subject");
                        try
                        {
                            //taking input to add new subject
                            CallGreen();
                            Console.WriteLine();
                            Console.Write("Enter your choice : ");
                            CallWhite();
                            int subjectChoice = Convert.ToInt32(Console.ReadLine());
                            Subjects newsubject = new Subjects();
                            if (subjectChoice == 1)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the New Subject : ");
                                CallWhite();
                                newsubject.SubjectName = Console.ReadLine();
                                //call method to add new subject
                                AdministatorBL.AddNewSubject(newsubject);
                            }
                            else if (subjectChoice == 2)
                            {
                                //taking input to update new subject
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Subject id to Update : ");
                                CallWhite();
                                newsubject.SubjectID = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the New Subject name : ");
                                CallWhite();
                                newsubject.SubjectName = Console.ReadLine();
                                //call method to update new subject
                                AdministatorBL.UpdateSubject(newsubject);
                            }
                            else if (subjectChoice == 3)
                            {
                                //taking input to delete subject
                                Console.Clear();
                              //  CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Subject name to Delete : ");
                                CallWhite();
                                newsubject.SubjectName = Console.ReadLine();
                                //call method to delete subject
                                AdministatorBL.DeleteSubject(newsubject);
                            }
                        }
                        catch (FacultyExceptions e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (FormatException e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        break;
                    case 6:
                        try
                        {
                            //taking faculty id for printing faculty's all informatiomn
                            Faculty faculty = new Faculty();
                            Console.Clear();
                          //  CallTitle();
                            Console.WriteLine();
                            CallGreen();
                            Console.Write("Enter the Faculty ID: ");
                            CallWhite();
                            faculty.FacultyID = Convert.ToInt32(Console.ReadLine());
                            //call method to faculty information
                            faculty = FacultyBL.PrintFacultyInfo(faculty);
                            //print faculty information
                            PrintFacultyInfo(faculty);
                            //call method to print all faculty information
                            var objectList = FacultyBL.PrintAllFacultyInfo(faculty);
                            //print all faculty informtion
                            PrintAllFacultyInfo(objectList);
                        }
                        catch (FacultyExceptions e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }

                        catch (FormatException e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }

                        break;
                    case 7:
                        try
                        {
                            //taking inputs for updating the job details
                            Faculty facultyobj = new Faculty();
                            Console.Clear();
                          //  CallTitle();
                            Console.WriteLine();
                            CallGreen();
                            Console.Write("Enter Facultyid you want to update: ");
                            CallWhite();
                            facultyobj.FacultyID = Convert.ToInt32(Console.ReadLine());
                            CallGreen();
                            Console.Write("Enter the New Department id: ");
                            CallWhite();
                            facultyobj.DeptID = Convert.ToInt32(Console.ReadLine());
                            CallGreen();
                            Console.Write("Enter the New Designation id: ");
                            CallWhite();
                            facultyobj.DesignationID = Convert.ToInt32(Console.ReadLine());
                            //call method for updating the job details
                            AdministatorBL.UpdCurrentJob(facultyobj);
                        }
                        catch (FacultyExceptions e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }

                        catch (FormatException e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }


                        break;
                    case 8:
                        Console.Clear();
                     //   CallTitle();
                        Console.WriteLine();
                        CallCyan();
                        //print menu for admin how they want to show publication
                        Console.WriteLine("1)Yearwise");
                        Console.WriteLine("2)Monthwise");
                        Console.WriteLine("3)Recent");

                        try
                        {

                            Console.WriteLine();
                            CallGreen();
                            //taking choice of admin
                            Console.Write("Enter your option: ");
                            CallWhite();
                            int select = Convert.ToInt32(Console.ReadLine());
                            if (select == 1)
                            {
                                Console.Clear();
                              //  CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Year: ");
                                CallWhite();
                                string year = Console.ReadLine();
                                //printing publications year wise
                                var publicationList = PublicationBL.PrintPubicationsYear(year);
                                PrintPublicationsArray(publicationList);

                            }
                            else if (select == 2)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the month: ");
                                CallWhite();
                                string month = Console.ReadLine();
                                //printing publications month wise
                                var publicationList = PublicationBL.PrintPubicationsMonth(month);
                                PrintPublicationsArray(publicationList);
                            }
                            else if (select == 3)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the No.of recent records u want: ");
                                CallWhite();
                                string recent = Console.ReadLine();
                                //printing recent publications
                                var publicationList = PublicationBL.PrintPubicationsRecent(recent);
                                PrintPublicationsArray(publicationList);


                            }
                        }
                        catch (FacultyExceptions e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }

                        catch (FormatException e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        break;
                    default:
                        CallRed();
                        Console.WriteLine("Please enter input according to menu");
                        CallGreen();
                        break;


                }
            }


            else if (access == 2)
            {

                printfacultymenu();
                CallGreen();
                Console.Write("Enter the Choice : ");
                CallWhite();
                int facultyChoice = -1;
                try
                {
                    facultyChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    CallRed();
                    Console.WriteLine(e.Message);
                    CallGreen();
                }

                Faculty faculty = new Faculty();

                switch (facultyChoice)
                {
                    case 1:
                        Console.Clear();
                     //   CallTitle();
                        Console.WriteLine();
                        CallCyan();

                        //printing menu to faculty
                        Console.WriteLine("1)Insert the info");
                        Console.WriteLine("2)Update the info");
                        Console.WriteLine("3)Print the info");
                        Console.WriteLine("4)Delete the info");
                        try
                        {

                            CallGreen();
                            Console.Write("Enter your choice : ");
                            CallWhite();
                            int crudchoice = Convert.ToInt32(Console.ReadLine());
                            if (crudchoice == 1)
                            {
                                Console.Clear();
                               //// CallTitle();
                                Console.WriteLine();
                                TakeDetails(faculty);
                                //call method to add faculty personal information
                                FacultyBL.AddPersonalInfo(faculty);
                            }
                            else if (crudchoice == 2)
                            {
                                Console.Clear();
                              //  CallTitle();
                                Console.WriteLine();
                                TakeDetails(faculty);
                                //call method to update faculty personal information
                                FacultyBL.UpdPersonalInfo(faculty);
                            }
                            else if (crudchoice == 3)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Faculty ID : ");
                                CallWhite();
                                faculty.FacultyID = Convert.ToInt32(Console.ReadLine());
                                //call method to print faculty personal information
                                faculty = FacultyBL.PrintFacultyInfo(faculty);
                                if (faculty.FirstName != "")
                                    PrintFacultyInfo(faculty);
                            }
                            else if (crudchoice == 4)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Faculty ID : ");
                                CallWhite();
                                faculty.FacultyID = Convert.ToInt32(Console.ReadLine());
                                //call method to delete faculty personal information
                                FacultyBL.DelPersonalnfo(faculty);
                            }
                        }
                        catch (FacultyExceptions e)
                        {
                            CallCyan();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (FormatException e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        break;
                    case 2:
                        Console.Clear();
                      //  CallTitle();
                        Console.WriteLine();
                        CallCyan();
                        //print menu faculty job history
                        Console.WriteLine("1)Insert the JobHistory");
                        Console.WriteLine("2)Update the JobHistory");
                        Console.WriteLine("3)Print the JobHistory");
                        Console.WriteLine("4)Delete the JobHistory");
                        try
                        {
                            Console.WriteLine();
                            CallGreen();
                            Console.Write("Enter the Choice: ");
                            CallWhite();
                            int workchoice = Convert.ToInt32(Console.ReadLine());
                            WorkHistory work = new WorkHistory();
                            if (workchoice == 1)
                            {
                                Console.Clear();
                              //  CallTitle();
                                Console.WriteLine();
                                WorkDetails(work);
                                //call method to add faculty workhistory
                                WorkHistoryBL.AddWorkHistoryInfo(work);

                            }
                            else if (workchoice == 2)
                            {
                                Console.Clear();
                              //  CallTitle();
                                Console.WriteLine();
                                WorkDetails(work);
                                //call method to update faculty workhistory
                                WorkHistoryBL.UpdWorkHistoryInfo(work);
                            }
                            else if (workchoice == 3)
                            {
                                Console.Clear();
                             //   CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the FacultyId : ");
                                CallWhite();
                                work.FacultyID = Convert.ToInt32(Console.ReadLine());
                                //call method to print faculty workhistory
                                var workList = WorkHistoryBL.PrintWorkHistoryInfo(work);
                                PrintWorkHistory(workList);
                            }
                            else if (workchoice == 4)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the FacultyID : ");
                                CallWhite();
                                work.FacultyID = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the WorkHistoryID : ");
                                CallWhite();
                                work.WorkHistoryID = Convert.ToInt32(Console.ReadLine());

                                //call method to delete faculty workhistory
                                WorkHistoryBL.DelWorkHistoryInfo(work);
                            }
                        }
                        catch (FacultyExceptions e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }

                        catch (FormatException e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        break;

                    case 3:
                        Console.Clear();
                      //  CallTitle();
                        Console.WriteLine();
                        CallCyan();
                        //print menu for publication
                        Console.WriteLine("1)Insert into the Publications");
                        Console.WriteLine("2)Update the Publications");
                        Console.WriteLine("3)Print the Publications");
                        Console.WriteLine("4)Delete the publications");
                        try
                        {
                            CallGreen();
                            Console.WriteLine();
                            Console.Write("Enter the choice: ");
                            CallWhite();
                            int publicationChoice = Convert.ToInt32(Console.ReadLine());
                            Publications publications = new Publications();
                            if (publicationChoice == 1)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                PublicationDetails(publications);
                                //call method to add publication
                                PublicationBL.AddPublications(publications);
                            }
                            else if (publicationChoice == 2)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                PublicationDetails(publications);
                                //call method to update publication
                                PublicationBL.UpdPublications(publications);
                            }
                            else if (publicationChoice == 3)
                            {
                                Console.Clear();
                              //  CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Faculty id : ");
                                CallWhite();
                                publications.FacultyID = Convert.ToInt32(Console.ReadLine());
                                //call method to print publication
                                var publicationList = PublicationBL.PrintPublications(publications);
                                PrintPublicationsArray(publicationList);
                            }
                            else if (publicationChoice == 4)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Faculty id : ");
                                CallWhite();
                                publications.FacultyID = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the Publication id : ");
                                CallWhite();
                                publications.PublicationID = Convert.ToInt32(Console.ReadLine());

                                //call method to delete publication
                                PublicationBL.DelPublications(publications);
                            }
                        }
                        catch (FacultyExceptions e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }

                        catch (FormatException e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        break;
                    case 4:
                        Console.Clear();
                       // CallTitle();
                        Console.WriteLine();
                        CallCyan();
                        //print menu for coursestaught
                        Console.WriteLine("1)Insert the CoursesTaught");
                        Console.WriteLine("2)Update the CoursesTaught");
                        Console.WriteLine("3)Print the CoursesTaught");
                        Console.WriteLine("4)Delete the Courses Taught");
                        try

                        {
                            CallGreen();
                            Console.WriteLine();
                            Console.Write("Enter your choice: ");
                            CallWhite();
                            int courseTaughtChoice = Convert.ToInt32(Console.ReadLine());
                            CoursesTaught coursetaught = new CoursesTaught();
                            if (courseTaughtChoice == 1)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the FirstDateTaught : ");
                                CallWhite();
                                coursetaught.FirstDateTaught = Convert.ToDateTime(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the SubjectID : ");
                                CallWhite();
                                coursetaught.SubjectID = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the FacultyID : ");
                                CallWhite();
                                coursetaught.FacultyID = Convert.ToInt32(Console.ReadLine());
                                //call method to add new coursestaught by faculty
                                FacultyBL.AddCourseTaught(coursetaught);
                            }
                            else if (courseTaughtChoice == 2)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Course ID : ");
                                CallWhite();
                                coursetaught.CourseID = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the FirstDateTaught : ");
                                CallWhite();
                                coursetaught.FirstDateTaught = Convert.ToDateTime(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the FacultyID : ");
                                CallWhite();
                                coursetaught.FacultyID = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the SubjectID : ");
                                CallWhite();
                                coursetaught.SubjectID = Convert.ToInt32(Console.ReadLine());
                                //call method to update coursestaught by faculty
                                FacultyBL.UpdCourseTaught(coursetaught);

                            }
                            else if (courseTaughtChoice == 3)
                            {
                                Console.Clear();
                              //  CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the FacultyID : ");
                                CallWhite();
                                coursetaught.FacultyID = Convert.ToInt32(Console.ReadLine());
                                //call method to print coursestaught by faculty
                                ArrayList courseTaughtList = FacultyBL.PrintCourseTaught(coursetaught);
                                PrintCoursesTaught(courseTaughtList);

                            }
                            else if (courseTaughtChoice == 4)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the CourseID : ");
                                CallWhite();
                                coursetaught.CourseID = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the FacultyID : ");
                                CallWhite();
                                coursetaught.FacultyID = Convert.ToInt32(Console.ReadLine());
                                //call method to delete coursestaught by faculty
                                FacultyBL.DelCourseTaught(coursetaught);

                            }
                        }

                        catch (FacultyExceptions e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }

                        catch (FormatException e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        break;

                    case 5:
                        Console.Clear();
                      //  CallTitle();
                        Console.WriteLine();
                        CallCyan();
                        //print menu for grants
                        Console.WriteLine("1)Insert the Grants");
                        Console.WriteLine("2)Update the Grants");
                        Console.WriteLine("3)Print the Grants");
                        Console.WriteLine("4)Delete the Grants");
                        try
                        {
                            Console.WriteLine();
                            CallGreen();
                            Console.Write("Enter your choice : ");
                            CallWhite();
                            int grantchoice = Convert.ToInt32(Console.ReadLine());
                            Grants grants = new Grants();
                            if (grantchoice == 1)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Grant Title : ");
                                CallWhite();
                                grants.GrantTitle = Console.ReadLine();
                                CallGreen();
                                Console.Write("Enter the Grant Description : ");
                                CallWhite();
                                grants.GrantDescription = Console.ReadLine();
                                CallGreen();
                                Console.Write("Enter the Grant FacultyId : ");
                                CallWhite();
                                grants.FacultyID = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                //call method to add new grants details
                                FacultyBL.AddGrants(grants);
                            }
                            else if (grantchoice == 2)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Grant ID : ");
                                CallWhite();
                                grants.GrantID = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the Grant FacultyId : ");
                                CallWhite();
                                grants.FacultyID = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the Grant Title : ");
                                CallWhite();
                                grants.GrantTitle = Console.ReadLine();
                                CallGreen();
                                Console.Write("Enter the Grant Description : ");
                                CallWhite();
                                grants.GrantDescription = Console.ReadLine();
                                //call method to update grants datails
                                FacultyBL.UpdGrants(grants);

                            }
                            else if (grantchoice == 3)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Grant FacultyId : ");
                                CallWhite();
                                grants.FacultyID = Convert.ToInt32(Console.ReadLine());
                                //call method to print grants datails
                                var grantsList = FacultyBL.PrintGrants(grants);
                                PrintGrantsArray(grantsList);

                            }
                            else if (grantchoice == 4)
                            {
                                Console.Clear();
                               // CallTitle();
                                Console.WriteLine();
                                CallGreen();
                                Console.Write("Enter the Grant FacultyId : ");
                                CallWhite();
                                grants.FacultyID = Convert.ToInt32(Console.ReadLine());
                                CallGreen();
                                Console.Write("Enter the Grant id : ");
                                grants.GrantID = Convert.ToInt32(Console.ReadLine());
                                CallWhite();
                                //call method to delete grants datails
                                FacultyBL.DelGrants(grants);
                            }
                        }
                        catch (FacultyExceptions e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }

                        catch (FormatException e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        catch (Exception e)
                        {
                            CallRed();
                            Console.WriteLine(e.Message);
                            CallGreen();
                        }
                        break;
                    default:
                        CallRed();
                        Console.WriteLine("Please enter input according to menu");
                        CallGreen();
                        break;

                }



            }




        }
        #endregion
    }
}