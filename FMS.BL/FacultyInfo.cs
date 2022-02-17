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
    public class FacultyInfo
    {
        public static void AddPersonalInfo(Faculty faculty)
        {
            FacultyDAL perinfoDAL = new FacultyDAL();
            perinfoDAL.AddPersonalInfo(faculty);
        }

        public static void UpdPersonalInfo(Faculty faculty)
        {
            FacultyDAL perinfoDAL = new FacultyDAL();
            perinfoDAL.UpdPersonalInfo(faculty);
        }

        public static void PrintFacultyInfo(Faculty faculty)
        {
            FacultyDAL perinfoDAL = new FacultyDAL();
            perinfoDAL.PrintFacultyInfo(faculty);
        }

    }
}