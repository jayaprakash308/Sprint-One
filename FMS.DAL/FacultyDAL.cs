using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using FMS.Entity;
using FMS.Exceptions;
using FMS.DAL;
namespace FMS.DAL

{
    public class FacultyDAL
    {

        #region Variables
        int access;
        public static int UniversalID;
        SqlConnection con=null;

        #endregion


        #region LoginCheckMethod

        //method for login check
        public int LoginCheck(Users user)
        {
           
            SqlConnection con = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["F"].ToString();


            string cmdtext = "UsersSelect";
            SqlCommand cmd = new SqlCommand(cmdtext, con);
            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@username", user.UserName1);
            cmd.Parameters.AddWithValue("@password", user.Password1);
            //cmd.Parameters.AddWithValue("@usertype", user.Usertype);

            //cmd.Parameters.AddWithValue("@UniversalID",user.UniversalID);

            try
            {
              // string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
                con.Open();
                SqlDataReader sqldatareader = cmd.ExecuteReader();
                if (sqldatareader.HasRows)
                {
                    while (sqldatareader.Read())
                    {
                        string password = sqldatareader.GetString(2);
                        string usertype = sqldatareader.GetString(3);
                        UniversalID = sqldatareader.GetInt32(4);


                        if (password == user.Password1 )
                        {
                            if (usertype == "faculty")
                            {
                                access = 2;
                                return access;
                            }
                            else if (usertype == "admin")
                            {
                                access = 1;
                                return access;
                            }
                            else if (usertype == "student")
                            {
                                access = 0;
                                return access;
                            }

                        }
                        else
                        {
                            throw new FacultyExceptions("wrong password");

                        }
                    }
                }
                else
                {
                    throw new FacultyExceptions("You are not valid user");
                }
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return -1;
        }
        #endregion


        #region FacultyDALmethods
        //method for add personal information
        public void AddPersonalInfo(Faculty faculty)
        {
            try
            {
                string cmdtext = "FacultyInsert"; 
                //call add or update or delete personal information method
                AddorUpdorDelPersonalInfo(faculty, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for update personal information
        public void UpdPersonalInfo(Faculty faculty)
        {
            try
            {
                string cmdtext = "FacultyUpdate";
                //call add or update or delete personal information method
                AddorUpdorDelPersonalInfo(faculty, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //method for delete personal information
        public void DelPersonalnfo(Faculty faculty)
        {
            try
            {
                string cmdtext = "FacultyDelete";
                //call add or update or delete personal information method
                AddorUpdorDelPersonalInfo(faculty, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for add or update or delete personal information
        public void AddorUpdorDelPersonalInfo(Faculty faculty, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmdtext == "FacultyInsert" || cmdtext == "FacultyUpdate")
            {
                cmd.Parameters.AddWithValue("@firstname", faculty.FirstName);
                cmd.Parameters.AddWithValue("@lastname", faculty.LastName);
                cmd.Parameters.AddWithValue("@address", faculty.Address);
                cmd.Parameters.AddWithValue("@city", faculty.City);
                cmd.Parameters.AddWithValue("@state", faculty.State);
                cmd.Parameters.AddWithValue("pincode", faculty.Pincode);
                cmd.Parameters.AddWithValue("@mobileno", faculty.MoblieNo);
                cmd.Parameters.AddWithValue("hiredate", faculty.HireDate);
                cmd.Parameters.AddWithValue("@email", faculty.EmailAddress);
                cmd.Parameters.AddWithValue("dob", faculty.DateofBirth);
                cmd.Parameters.AddWithValue("@deptid", faculty.DeptID);
                cmd.Parameters.AddWithValue("@desgnid", faculty.DesignationID);
            }


            cmd.Parameters.AddWithValue("@facultyid", faculty.FacultyID);

            int facultyid = faculty.FacultyID;

            if (validate(facultyid))
            {
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //printing succedded message 
                    if (cmdtext == "FacultyInsert")
                    {
                        throw new FacultyExceptions("Faculty Personal Information Succesfully Added");
                    }
                    else if (cmdtext == "FacultyUpdate")
                    {
                        throw new FacultyExceptions("Faculty Personal Information Successfully Updated");
                    }
                    else if (cmdtext == "FacultyDelete")
                    {
                        throw new FacultyExceptions("Faculty Personal Information Successfully Deleted");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (FacultyExceptions e)
                {
                    throw new FacultyExceptions(e.Message);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (conn != null)
                        conn.Close();

                }
            }
            else
            {

                throw new FacultyExceptions("You are not authorized for this action");

            }



        }


        //method for print faculty information
        public Faculty PrintFacultyInfo(Faculty faculty)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "FacultySelect";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@facultyid", faculty.FacultyID);
            int facultyid = faculty.FacultyID;
            if (validate(facultyid))
            {

                try
                {
                    conn.Open();
                    SqlDataReader sqldatareader = cmd.ExecuteReader();
                    if (sqldatareader.HasRows)
                    {
                        while (sqldatareader.Read())
                        {
                            //read faculty information from database
                            faculty.FirstName = sqldatareader.GetString(0);
                            faculty.LastName = sqldatareader.GetString(1);
                            faculty.Address = sqldatareader.GetString(2);
                            faculty.City = sqldatareader.GetString(3);
                            faculty.State = sqldatareader.GetString(4);
                            faculty.Pincode = sqldatareader.GetInt32(5);
                            faculty.MoblieNo = sqldatareader.GetString(6);
                            faculty.HireDate = sqldatareader.GetDateTime(7);
                            faculty.EmailAddress = sqldatareader.GetString(8);
                            faculty.DateofBirth = sqldatareader.GetDateTime(9);
                            faculty.DeptID = sqldatareader.GetInt32(10);
                            faculty.DesignationID = sqldatareader.GetInt32(11);
                            faculty.FacultyID = sqldatareader.GetInt32(12);

                        }
                    }
                }
                catch (FacultyExceptions e)
                {
                    throw new FacultyExceptions(e.Message);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
                return faculty;
            }
            else
            {
                throw new FacultyExceptions("you are not authorized for this action");
                // return faculty;
            }


        }

        #endregion


        #region ValidateFacultyMethod
        //method for faculty validation
        public bool validate(int facultyid)
        {
            try
            {
                if (facultyid == UniversalID || UniversalID > 2000 || (UniversalID > 100 && UniversalID < 1000))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion


        #region AdministratorMethods


        //method for validate username
        public void ValidateUserName(string UserName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "UserNameCheck";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@username", UserName);
            try
            {
                conn.Open();
                SqlDataReader sqldatareader = cmd.ExecuteReader();
                if (sqldatareader.HasRows)
                {

                    throw new FacultyExceptions("Username already exists");


                }
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }



        }

        //validating password method
        public void ValidatePassword(string Password)
        {

            try
            {
                if (Password.Length < 8)
                {
                    throw new FacultyExceptions("Password length must be greater than 8 characters");
                }
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        //method for add new user
        public void AddNewUser(Users newuser)
        {


            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "UsersInsert";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@username", newuser.UserName1);
            cmd.Parameters.AddWithValue("@password", newuser.Password1);
          //  cmd.Parameters.AddWithValue("@usertype", newuser.Usertype);
           // cmd.Parameters.AddWithValue("@uid", newuser.UniversalID);
            try
            {
                ValidateUserName(newuser.UserName1);
                ValidatePassword(newuser.Password1);
                conn.Open();
                int recordcount = cmd.ExecuteNonQuery();
                string acknowledgement = recordcount + " user successfully added";
                throw new FacultyExceptions(acknowledgement);

            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }

        }

        //method for add new designation
        public void AddNewDesignation(Designation newdesignation)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "DesignationInsert";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@designationname", newdesignation.DesignationName);
            try
            {
                conn.Open();
                int recordcount = cmd.ExecuteNonQuery();
                string acknowledgement = recordcount + " Designation Successfully added";
                throw new FacultyExceptions(acknowledgement);

            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }
        }

        //method for add department
        public void AddDepartment(Department newdept)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "DepartmentsInsert";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@deptname", newdept.DeptName);

            try
            {
                conn.Open();
                int recordcount = cmd.ExecuteNonQuery();
                string acknowledgement = recordcount + " Department Successfully added";
                throw new FacultyExceptions(acknowledgement);

            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }
        }

        //method for update current job
        public void UpdCurrentJob(Faculty faculty)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "CurrentJobUpd";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@facultyid", faculty.FacultyID);
            cmd.Parameters.AddWithValue("@deptid", faculty.DeptID);
            cmd.Parameters.AddWithValue("@desgnid", faculty.DesignationID);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                throw new FacultyExceptions("Current Job of Faculty Successfully updated");


            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }

        }




        //method for print all faculty information
        public ArrayList PrintAllFacultyInfo(Faculty faculty)
        {

            var objectList = new ArrayList();
            //create list for storing select stored procedure
            List<String> storedproc = new List<string>
            {
                "DegreesSelect",
                "PublicationsSelect",
                "WorkHistoriesSelect",
                "CourseTaughtSelect",
                "GrantsSelect"
            };
            //create objects
            Degrees degree = new Degrees();
            Publications publication = new Publications();
            WorkHistory work = new WorkHistory();
            CoursesTaught course = new CoursesTaught();
            Grants Grants = new Grants();
            foreach (string cmdtext in storedproc)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@facultyid", faculty.FacultyID);

                try
                {
                    conn.Open();
                    SqlDataReader sqldatareader = cmd.ExecuteReader();
                    if (sqldatareader.HasRows)
                    {
                        while (sqldatareader.Read())
                        {
                            if (storedproc.IndexOf(cmdtext) == 0)
                            {
                                //read degree details from database
                                degree.DegreeID = sqldatareader.GetInt32(0);
                                degree.Degree = sqldatareader.GetString(1);
                                degree.Specialization = sqldatareader.GetString(2);
                                degree.DegreeYear = sqldatareader.GetString(3);
                                degree.Grade = Convert.ToChar(sqldatareader.GetString(4));
                                degree.FacultyID = sqldatareader.GetInt32(5);
                            }
                            else if (storedproc.IndexOf(cmdtext) == 1)
                            {
                                //read publication details from database
                                publication.PublicationID = sqldatareader.GetInt32(0);
                                publication.PublicationTitle = sqldatareader.GetString(1);
                                publication.ArticleName = sqldatareader.GetString(2);
                                publication.PublisherName = sqldatareader.GetString(3);
                                publication.PublicationLocation = sqldatareader.GetString(4);
                                publication.CitationDate = sqldatareader.GetDateTime(5);
                                publication.FacultyID = sqldatareader.GetInt32(6);
                            }
                            else if (storedproc.IndexOf(cmdtext) == 2)
                            {
                                //read work history details from database
                                work.WorkHistoryID = sqldatareader.GetInt32(0);
                                work.Organization = sqldatareader.GetString(1);
                                work.JobTitle = sqldatareader.GetString(2);
                                work.JobBeginDate = sqldatareader.GetDateTime(3);
                                work.JobEndDate = sqldatareader.GetDateTime(4);
                                work.JobResponsibilities = sqldatareader.GetString(5);
                                work.JobType = sqldatareader.GetString(6);
                                work.FacultyID = sqldatareader.GetInt32(7);
                            }
                            else if (storedproc.IndexOf(cmdtext) == 3)
                            {
                                //read course details from database
                                course.CourseID = sqldatareader.GetInt32(0);
                                course.FirstDateTaught = sqldatareader.GetDateTime(1);
                                course.SubjectID = sqldatareader.GetInt32(2);
                                course.FacultyID = sqldatareader.GetInt32(3);
                            }
                            else if (storedproc.IndexOf(cmdtext) == 4)
                            {
                                //read grant details from database
                                Grants.GrantID = sqldatareader.GetInt32(0);
                                Grants.GrantTitle = sqldatareader.GetString(1);
                                Grants.GrantDescription = sqldatareader.GetString(2);
                                Grants.FacultyID = sqldatareader.GetInt32(3);
                            }
                        }

                    }

                    //add details in list
                    objectList.Add(degree);
                    objectList.Add(publication);
                    objectList.Add(work);
                    objectList.Add(course);
                    objectList.Add(Grants);
                }
                catch (FacultyExceptions e)
                {
                    throw new FacultyExceptions(e.Message);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
            return objectList;
        }


        #endregion


        #region PublicationYearorMonthorRecent

        //method for print publication yearwise
        public ArrayList PrintPublicationsYear(string year)
        {
            ArrayList publicationList = null;
            try
            {
                string cmdtext = "YearSelect";
                //call print year or month or recent method
                publicationList = PrintYearorMonthorRecent(year, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publicationList;
        }
        //method for print publication monthwise
        public ArrayList PrintPublicationsMonth(string month)
        {
            ArrayList publicationList = null;
            try
            {
                string cmdtext = "MonthSelect";
                //call print year or month or recent method
                publicationList = PrintYearorMonthorRecent(month, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publicationList;
        }


        //method for print recent publications 
        public ArrayList PrintPublicationsRecent(string recent)
        {
            ArrayList publicationList = null;
            try
            {
                string cmdtext = "RecentSelect";
                //call print year or month or recent method
                publicationList = PrintYearorMonthorRecent(recent, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publicationList;
        }

        //method for print year or month or recent publications
        public ArrayList PrintYearorMonthorRecent(string filter, string cmdtext)
        {


            var publicationList = new ArrayList();

            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (cmdtext == "YearSelect")
            {
                cmd.Parameters.AddWithValue("@year", filter);
            }
            else if (cmdtext == "MonthSelect")
            {
                cmd.Parameters.AddWithValue("@month", filter);
            }
            else if (cmdtext == "RecentSelect")
            {
                cmd.Parameters.AddWithValue("@recent", filter);
            }
            Publications publication;
            try
            {
                conn.Open();
                SqlDataReader sqldatareader = cmd.ExecuteReader();
                if (sqldatareader.HasRows)
                {
                    while (sqldatareader.Read())
                    {
                        //read publication details from database
                        publication = new Publications();
                        publication.PublicationID = sqldatareader.GetInt32(0);
                        publication.PublicationTitle = sqldatareader.GetString(1);
                        publication.ArticleName = sqldatareader.GetString(2);
                        publication.PublisherName = sqldatareader.GetString(3);
                        publication.PublicationLocation = sqldatareader.GetString(4);
                        publication.CitationDate = sqldatareader.GetDateTime(5);
                        publication.FacultyID = sqldatareader.GetInt32(6);
                        publicationList.Add(publication);
                    }

                }

            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }


            return publicationList;
        }
        #endregion


        #region SubjectMethods
        //method for add or update or delete subject
        public void AddorUpdorDelSubj(Subjects newsubject, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;



            if (cmdtext == "SubjectsUpdate")
            {
                cmd.Parameters.AddWithValue("@subjectid", newsubject.SubjectID);

            }
            cmd.Parameters.AddWithValue("@subjectname", newsubject.SubjectName);
            try
            {
                conn.Open();
                int recordcount = cmd.ExecuteNonQuery();
                //print succedded message
                if (cmdtext == "SubjectsInsert")
                    throw new FacultyExceptions(recordcount + " Subject Successfully added");
                else if (cmdtext == "SubjectsUpdate")
                    throw new FacultyExceptions(recordcount + " Subject Successfully updated");
                else if (cmdtext == "SubjectsDelete")
                    throw new FacultyExceptions(recordcount + " Subject Successfully Deleted");


            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }
        }

        //method for add new subject
        public void AddNewSubject(Subjects newsubject)
        {
            try
            {
                string cmdtext = "SubjectsInsert";
                //call add or update or delete subject method
                AddorUpdorDelSubj(newsubject, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for update subject
        public void UpdateSubject(Subjects newsubject)
        {
            try
            {
                string cmdtext = "SubjectsUpdate";
                //call add or update or delete subject method
                AddorUpdorDelSubj(newsubject, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //method for delete subject
        public void DeleteSubject(Subjects newsubject)
        {
            try
            {
                string cmdtext = "SubjectsDelete";
                //call add or update or delete subject method
                AddorUpdorDelSubj(newsubject, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion


        #region CourseMethods

        //method for add or update or delete course
        public void AddorUpdorDelCourse(Courses newcourse, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            if (cmdtext == "coursesinsert" || cmdtext == "coursesupdate")
            {

                cmd.Parameters.AddWithValue("@coursename", newcourse.CourseName);
                cmd.Parameters.AddWithValue("@coursecredit", newcourse.CourseCredits);
                cmd.Parameters.AddWithValue("@deptid", newcourse.DeptID);
            }
            if (cmdtext == "coursesupdate" || cmdtext == "coursesdelete")
            {
                cmd.Parameters.AddWithValue("@courseid", newcourse.CourseID);
            }
            try
            {
                conn.Open();
                int recordcount = cmd.ExecuteNonQuery();
                //print succedded message
                if (cmdtext == "coursesinsert")
                    throw new FacultyExceptions(recordcount + " Course Successfully added");
                else if (cmdtext == "coursesupdate")
                    throw new FacultyExceptions(recordcount + " Course Successfully updated");
                else if (cmdtext == "coursesdelete")
                    throw new FacultyExceptions(recordcount + " Course Successfully deleted");

            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }
        }

        //method for add new course
        public void AddNewCourse(Courses newcourse)
        {
            try
            {
                string cmdtext = "coursesinsert";
                //call add or update or delete course method
                AddorUpdorDelCourse(newcourse, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for update course
        public void UpdateCourse(Courses newcourse)
        {
            try
            {
                string cmdtext = "coursesupdate";
                //call add or update or delete course method
                AddorUpdorDelCourse(newcourse, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for delete course
        public void DeleteCourse(Courses newcourse)
        {
            try
            {
                string cmdtext = "coursesdelete";
                //call add or update or delete course method
                AddorUpdorDelCourse(newcourse, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion


        #region GrantsMethods
        //method for add grant details
        public void AddGrants(Grants grants)
        {
            try
            {
                string cmdtext = "GrantsInsert";
                //call add or update or delete grant method
                AddorUpdorDelGrants(grants, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //method for update grant details
        public void UpdGrants(Grants grants)
        {
            try
            {
                string cmdtext = "GrantsUpdate";
                //call add or update or delete grant method
                AddorUpdorDelGrants(grants, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for delete grant details
        public void DelGrants(Grants grants)
        {
            try
            {
                string cmdtext = "GrantsDelete";
                //call add or update or delete grant method
                AddorUpdorDelGrants(grants, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        //method for add or update or delete grant
        public void AddorUpdorDelGrants(Grants grants, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmdtext == "GrantsInsert" || cmdtext == "GrantsUpdate")
            {
                cmd.Parameters.AddWithValue("@GrantTitle", grants.GrantTitle);
                cmd.Parameters.AddWithValue("@GrantDescription", grants.GrantDescription);
                cmd.Parameters.AddWithValue("facultyid", grants.FacultyID);
            }
            if (cmdtext == "GrantsDelete")
            {
                cmd.Parameters.AddWithValue("facultyid", grants.FacultyID);
            }
            if (cmdtext == "GrantsUpdate" || cmdtext == "GrantsDelete")
            {
                cmd.Parameters.AddWithValue("@grantid", grants.GrantID);
            }

            int facultyid = grants.FacultyID;
            try
            {
                if (validate(facultyid))
                {
                    conn.Open();
                    int recordcount = cmd.ExecuteNonQuery();
                    //print succedded message
                    if (cmdtext == "GrantsInsert")
                        throw new FacultyExceptions(recordcount + " Grant Record Successfully Inserted");
                    else if (cmdtext == "GrantsUpdate")
                        throw new FacultyExceptions(recordcount + " Grant Record Successfully Updated");
                    else if (cmdtext == "GrantsDelete")
                        throw new FacultyExceptions(recordcount + " Grants Record Successfully Deleted");

                }
                else
                {

                    throw new FacultyExceptions("you are not authorised for this action");

                }

            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }

        }

        //method for print grant details
        public ArrayList PrintGrants(Grants grant)
        {
            ArrayList grantsList = new ArrayList();
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "GrantsSelect";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@facultyid", grant.FacultyID);
            Grants grants;

            int facultyid = grant.FacultyID;
            if (validate(facultyid))
            {
                try
                {
                    conn.Open();
                    SqlDataReader sqldatareader = cmd.ExecuteReader();
                    if (sqldatareader.HasRows)
                    {
                        while (sqldatareader.Read())
                        {
                            //read grant details from database
                            grants = new Grants();
                            grants.GrantID = sqldatareader.GetInt32(0);

                            grants.GrantTitle = sqldatareader.GetString(1);

                            grants.GrantDescription = sqldatareader.GetString(2);

                            grants.FacultyID = sqldatareader.GetInt32(3);
                            grantsList.Add(grants);

                        }
                    }
                }

                catch (FacultyExceptions e)
                {
                    throw new FacultyExceptions(e.Message);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
                return grantsList;
            }
            else
            {
                throw new FacultyExceptions("you are not authorised for this action");

            }
        }
        #endregion


        #region WorkHistoryMethods
        //method for add work history information
        public void AddWorkHistoryInfo(WorkHistory workHistory)
        {
            try
            {
                string cmdtext = "WorkHistoriesInsert";
                //call add or update or delete work history information method
                AddorUpdorDelWorkInfo(workHistory, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        //method for update work history information
        public void UpdWorkHistoryInfo(WorkHistory workHistory)
        {
            try
            {
                string cmdtext = "WorkHistoriesUpdate";
                //call add or update or delete work history information method
                AddorUpdorDelWorkInfo(workHistory, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for delete work history information
        public void DelWorkHistoryInfo(WorkHistory workHistory)
        {
            try
            {
                string cmdtext = "WorkHistoriesDelete";
                //call add or update or delete work history information method
                AddorUpdorDelWorkInfo(workHistory, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for add or update or delete work history information 
        public void AddorUpdorDelWorkInfo(WorkHistory workHistory, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@facultyid", workHistory.FacultyID);
            if (cmdtext == "WorkHistoriesInsert" || cmdtext == "WorkHistoriesUpdate")
            {
                cmd.Parameters.AddWithValue("@organization", workHistory.Organization);
                cmd.Parameters.AddWithValue("@jobtitle", workHistory.JobTitle);
                cmd.Parameters.AddWithValue("@jobbegindate", workHistory.JobBeginDate);
                cmd.Parameters.AddWithValue("@jobenddate", workHistory.JobEndDate);
                cmd.Parameters.AddWithValue("@jobresponsibilities", workHistory.JobResponsibilities);
                cmd.Parameters.AddWithValue("@jobtype", workHistory.JobType);
            }
            if (cmdtext == "WorkHistoriesUpdate" || cmdtext == "WorkHistoriesDelete")
            {
                cmd.Parameters.AddWithValue("@workid", workHistory.WorkHistoryID);
            }
            int facultyid = workHistory.FacultyID;
            try
            {
                if (validate(facultyid))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //print succedded message
                    if (cmdtext == "WorkHistoriesInsert")
                        throw new FacultyExceptions("Work history Successfully Inserted");
                    else if (cmdtext == "WorkHistoriesUpdate")
                        throw new FacultyExceptions("Work history Successfully Updated");
                    else if (cmdtext == "WorkHistoriesDelete")
                        throw new FacultyExceptions("WorkHistory Successfully Deleted");
                }
                else
                {
                    throw new FacultyExceptions("You are not a valid user");
                }

            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }
        }

        // method for printing work history details
        public ArrayList PrintWorkHistoryInfo(WorkHistory workHistoryy)
        {
            ArrayList workList = new ArrayList();
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "WorkHistoriesSelect";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            WorkHistory workHistory = new WorkHistory();
            int facultyid = workHistoryy.FacultyID;
            cmd.Parameters.AddWithValue("@facultyid", workHistoryy.FacultyID);

            if (validate(facultyid))
            {

                try
                {
                    conn.Open();
                    SqlDataReader sqldatareader = cmd.ExecuteReader();
                    if (sqldatareader.HasRows)
                    {
                        while (sqldatareader.Read())
                        {
                            //read work history informatio from database
                            workHistory = new WorkHistory();
                            workHistory.WorkHistoryID = sqldatareader.GetInt32(0);
                            workHistory.Organization = sqldatareader.GetString(1);
                            workHistory.JobTitle = sqldatareader.GetString(2);
                            workHistory.JobBeginDate = sqldatareader.GetDateTime(3);
                            workHistory.JobEndDate = sqldatareader.GetDateTime(4);
                            workHistory.JobResponsibilities = sqldatareader.GetString(5);
                            workHistory.JobType = sqldatareader.GetString(6);
                            workHistory.FacultyID = sqldatareader.GetInt32(7);
                            workList.Add(workHistory);

                        }
                    }
                }
                catch (FacultyExceptions e)
                {
                    throw new FacultyExceptions(e.Message);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
                return workList;
            }
            else
            {
                throw new FacultyExceptions("you are not authorised for this action");
            }
        }
        #endregion


        #region PublicationMethods

        //method for add new publication
        public void AddPublications(Publications publications)
        {
            try
            {
                string cmdtext = "PublicationInsert";
                //call add or update or delete publications method
                AddorUpdorDelPublications(publications, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for update publication
        public void UpdPublications(Publications publications)
        {
            try
            {
                string cmdtext = "PublicationUpdate";
                //call add or update or delete publications method
                AddorUpdorDelPublications(publications, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for delete publication
        public void DelPublications(Publications publications)
        {
            try
            {
                string cmdtext = "PublicationDelete";
                //call add or update or delete publications method
                AddorUpdorDelPublications(publications, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method  for add or update or delete publications
        public void AddorUpdorDelPublications(Publications publications, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@facultyid", publications.FacultyID);

            if (cmdtext == "PublicationInsert" || cmdtext == "PublicationUpdate")
            {
                cmd.Parameters.AddWithValue("@publictitle", publications.PublicationTitle);
                cmd.Parameters.AddWithValue("@articlename", publications.ArticleName);
                cmd.Parameters.AddWithValue("@publicname", publications.PublisherName);
                cmd.Parameters.AddWithValue("@publicloc", publications.PublicationLocation);
                cmd.Parameters.AddWithValue("@Citationdt", publications.CitationDate);
            }
            if (cmdtext == "PublicationUpdate" || cmdtext == "PublicationDelete")
            {
                cmd.Parameters.AddWithValue("@publicid", publications.PublicationID);
            }
            int facultyid = publications.FacultyID;
            try
            {
                if (validate(facultyid))
                {

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //print succedded message
                    if (cmdtext == "PublicationInsert")
                        throw new FacultyExceptions("Publication Successfully Inserted");
                    else if (cmdtext == "PublicationUpdate")
                        throw new FacultyExceptions("Publication Successfully Updated");
                    else if (cmdtext == "PublicationDelete")
                        throw new FacultyExceptions("Publication Successfully Deleted");

                }
                else
                {
                    throw new FacultyExceptions("You are not authorised for this action");
                }


            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conn.Close();

            }

        }

        //method for print publication details
        public ArrayList PrintPublications(Publications publication)
        {


            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "PublicationsSelect";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            ArrayList publicationList = new ArrayList();

            cmd.Parameters.AddWithValue("@facultyid", publication.FacultyID);
            Publications publications;
            int facultyid = publication.FacultyID;
            if (validate(facultyid))
            {

                try
                {
                    conn.Open();
                    SqlDataReader sqldatareader = cmd.ExecuteReader();
                    if (sqldatareader.HasRows)
                    {
                        while (sqldatareader.Read())
                        {
                            //read publication details from database
                            publications = new Publications();
                            publications.PublicationID = sqldatareader.GetInt32(0);
                            publications.PublicationTitle = sqldatareader.GetString(1);
                            publications.ArticleName = sqldatareader.GetString(2);
                            publications.PublisherName = sqldatareader.GetString(3);
                            publications.PublicationLocation = sqldatareader.GetString(4);
                            publications.CitationDate = sqldatareader.GetDateTime(5);
                            publications.FacultyID = sqldatareader.GetInt32(6);

                            publicationList.Add(publications);
                        }
                    }

                }
                catch (FacultyExceptions e)
                {
                    throw new FacultyExceptions(e.Message);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
                return publicationList;
            }
            else
            {

                throw new FacultyExceptions("you are not authorised for this action");

            }
        }
        #endregion


        #region CourseTaughtMethods
        //method for add new course taught
        public void AddCourseTaught(CoursesTaught courseTaught)
        {
            try
            {
                string cmdtext = "CourseTaughtInsert";
                //call add or update or delete course taught method
                AddorUpdorDelCourseTaught(courseTaught, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for update course taught
        public void UpdCourseTaught(CoursesTaught courseTaught)
        {
            try
            {
                string cmdtext = "CourseTaughtUpdate";
                //call add or update or delete course taught method
                AddorUpdorDelCourseTaught(courseTaught, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for delete course taught
        public void DelCourseTaught(CoursesTaught courseTaught)
        {
            try
            {
                string cmdtext = "CourseTaughtDelete";
                //call add or update or delete course taught method
                AddorUpdorDelCourseTaught(courseTaught, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //method for add or update or delete course taught
        public void AddorUpdorDelCourseTaught(CoursesTaught courseTaught, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@facultyid", courseTaught.FacultyID);
            if (cmdtext == "CourseTaughtUpdate" || cmdtext == "CourseTaughtInsert")
            {
                cmd.Parameters.AddWithValue("@FirstDateTaught", courseTaught.FirstDateTaught);
                cmd.Parameters.AddWithValue("@subjectid", courseTaught.SubjectID);

            }
            if (cmdtext == "CourseTaughtUpdate" || cmdtext == "CourseTaughtDelete")
            {
                cmd.Parameters.AddWithValue("@courseid", courseTaught.CourseID);
            }

            int facultyid = courseTaught.FacultyID;
            try
            {
                if (validate(facultyid))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //print succedded message
                    if (cmdtext == "CourseTaughtInsert")
                        throw new FacultyExceptions("CoursesTaught record Successfully Inserted");
                    else if (cmdtext == "CourseTaughtUpdate")
                        throw new FacultyExceptions("CoursesTaught record Successfully Updated");
                    else if (cmdtext == "CourseTaughtDelete")
                        throw new FacultyExceptions("CoursesTaught Record Successfully Deleted");
                }
                else
                {

                    throw new FacultyExceptions("you are not authorized for this action");
                }

            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }
        }

        //method for print course taught
        public ArrayList PrintCourseTaught(CoursesTaught courseTaught)
        {
            ArrayList courseTaughtList = new ArrayList();
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "CourseTaughtSelect";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@FacultyID", courseTaught.FacultyID);
            CoursesTaught coursesTaught;
            int facultyid = courseTaught.FacultyID;
            if (validate(facultyid))
            {
                try
                {
                    conn.Open();
                    SqlDataReader sqldatareader = cmd.ExecuteReader();
                    if (sqldatareader.HasRows)
                    {
                        while (sqldatareader.Read())
                        {
                            //read course taught details from database
                            coursesTaught = new CoursesTaught();
                            coursesTaught.CourseID = sqldatareader.GetInt32(0);

                            coursesTaught.FirstDateTaught = sqldatareader.GetDateTime(1);

                            coursesTaught.SubjectID = sqldatareader.GetInt32(2);

                            coursesTaught.FacultyID = sqldatareader.GetInt32(3);
                            courseTaughtList.Add(coursesTaught);
                        }
                    }
                }
                catch (FacultyExceptions e)
                {
                    throw new FacultyExceptions(e.Message);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
                return courseTaughtList;
            }
            else
            {

                throw new FacultyExceptions("you are not authorized for this action");

            }
        }

        #endregion


    }
}