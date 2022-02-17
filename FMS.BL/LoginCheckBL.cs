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
    public class LoginCheckBL
    {
        #region LoginCheckingMethod
        //method for login check 
        public static int LoginCheck(Users user)
        {
            int access = -1;
            try
            {

                FacultyDAL loginDAL = new FacultyDAL();
                //call login check method of DAL
                access = loginDAL.LoginCheck(user);

            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return access;
        }
        #endregion
    }




}