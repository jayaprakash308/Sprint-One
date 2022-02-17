using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.DAL;
using FMS.BL;
using FMS.Entity;
using FMS.Exceptions;
namespace FMS.BL
{
    public class CourseBL
    {
        #region CourseMethods
        //method for add new course
        public static void AddNewCourse(Courses newcourse)
        {
            try
            {
                FacultyDAL addcourseDAL = new FacultyDAL();
                //call add new course method of DAL
                addcourseDAL.AddNewCourse(newcourse);
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
        public static void UpdateCourse(Courses newcourse)
        {
            try
            {
                FacultyDAL updCourseDAL = new FacultyDAL();
                //call update course method of DAL
                updCourseDAL.UpdateCourse(newcourse);
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
        public static void DeleteCourse(Courses newcourse)
        {
            try
            {
                FacultyDAL delCourseDAL = new FacultyDAL();
                //call delete course method of DAL
                delCourseDAL.DeleteCourse(newcourse);
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