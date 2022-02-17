using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.BL;
using FMS.Entity;
using FMS.Exceptions;
using FMS.DAL;

namespace FMS.BL
{
    public class DepartmentBL
    {
        #region DepartmentMethods
        //method for add department
        public static void AddDepartment(Department newdept)
        {
            try
            {
                FacultyDAL addepartmentDAL = new FacultyDAL();
                //call add department method of DAL
                addepartmentDAL.AddDepartment(newdept);
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