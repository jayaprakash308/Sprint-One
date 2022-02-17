using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.DAL;
using FMS.BL;
using FMS.Entity;
using FMS.Exceptions;
namespace FMS.BL
{
    public class FacultyBL
    {
        #region FacultyMethods
        //method for add personal information of faculty
        public static void AddPersonalInfo(Faculty faculty)
        {
            try
            {
                FacultyDAL personalinfoDAL = new FacultyDAL();
                //call add personal information method of DAL
                personalinfoDAL.AddPersonalInfo(faculty);
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

        //method for update personal information of faculty
        public static void UpdPersonalInfo(Faculty faculty)
        {
            try
            {
                FacultyDAL personalinfoDAL = new FacultyDAL();

                //call update personal information method of DAL
                personalinfoDAL.UpdPersonalInfo(faculty);
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

        //method for delete personal information of faculty
        public static void DelPersonalnfo(Faculty faculty)
        {
            try
            {
                FacultyDAL personalinfoDAL = new FacultyDAL();
                //call delete personal information method of DAL
                personalinfoDAL.DelPersonalnfo(faculty);
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

        //method for print personal information of faculty
        public static Faculty PrintFacultyInfo(Faculty faculty)
        {
            Faculty facultyobj = null;
            try
            {
                FacultyDAL personalinfoDAL = new FacultyDAL();
                //call print personal information method of DAL
                facultyobj = personalinfoDAL.PrintFacultyInfo(faculty);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return facultyobj;
        }

        //method for print all faculty information 
        public static ArrayList PrintAllFacultyInfo(Faculty faculty)
        {
            ArrayList objectList = null;
            try
            {
                FacultyDAL allfacDAL = new FacultyDAL();
                //call print all faculty information method of DAL
                objectList = allfacDAL.PrintAllFacultyInfo(faculty);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return objectList;
        }


        //method for add grants detail of faculty
        public static void AddGrants(Grants grants)
        {
            try
            {
                FacultyDAL grantsDAL = new FacultyDAL();
                //call add grant detail method of DAL
                grantsDAL.AddGrants(grants);
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

        //method for update grants detail of faculty
        public static void UpdGrants(Grants grants)
        {
            try
            {
                FacultyDAL grantsDAL = new FacultyDAL();
                //call update grant detail method of DAL
                grantsDAL.UpdGrants(grants);
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

        //method for delete grants detail of faculty
        public static void DelGrants(Grants grants)
        {
            try
            {

                FacultyDAL grantsDAL = new FacultyDAL();
                //call delete grant detail method of DAL
                grantsDAL.DelGrants(grants);
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

        //method for print grants detail of faculty
        public static ArrayList PrintGrants(Grants grants)
        {
            ArrayList grantsList = null;
            try
            {
                FacultyDAL grantsDAL = new FacultyDAL();
                //call print grant detail method of DAL
                grantsList = grantsDAL.PrintGrants(grants);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return grantsList;
        }

        //method for add course taught
        public static void AddCourseTaught(CoursesTaught courseTaught)
        {
            try
            {
                FacultyDAL courseTaughtDAL = new FacultyDAL();
                //call add course taught method of DAL
                courseTaughtDAL.AddCourseTaught(courseTaught);
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
        public static void UpdCourseTaught(CoursesTaught courseTaught)
        {
            try
            {
                FacultyDAL courseTaughtDAL = new FacultyDAL();
                //call update course taught method of DAL
                courseTaughtDAL.UpdCourseTaught(courseTaught);
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

        //method for print course taught
        public static ArrayList PrintCourseTaught(CoursesTaught courseTaught)
        {
            ArrayList courseTaughtList = null;
            try
            {
                FacultyDAL courseTaughtDAL = new FacultyDAL();
                //call print course taught method of DAL
                courseTaughtList = courseTaughtDAL.PrintCourseTaught(courseTaught);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return courseTaughtList;
        }

        //method for delete course taught
        public static void DelCourseTaught(CoursesTaught coursesTaught)
        {
            try
            {
                FacultyDAL courseTaughtDAL = new FacultyDAL();
                //call delete course taught method of DAL
                courseTaughtDAL.DelCourseTaught(coursesTaught);
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

    }
}