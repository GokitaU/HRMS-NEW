using HrmsLibrary.Common;
using HrmsLibrary.DataAccess;
using HrmsObjects.Details;
using HrmsObjects.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.BusinessLogic
{
    [Serializable]
    public class UserMgr
    {
        public List<User> SearchList(int PageNo, int RowsPerPage, string SearchText)
        {
            UserDbo objUserDB = new UserDbo();
            return objUserDB.SearchList(PageNo, RowsPerPage, SearchText);
        }
        public List<User> RoleID()
        {
            UserDbo objUserDB = new UserDbo();
            return objUserDB.RoleID();
        }
        public List<Employee> Employee()
        {
            UserDbo objUserDB = new UserDbo();
            return objUserDB.Employee();
        }
        public Employee AutoBind(Int64 Emloyeeid)
        {
            UserDbo objUserDB = new UserDbo();
            return objUserDB.AutoBind(Emloyeeid);
        }
        public Int32 NameMatch(string Name)
        {
            UserDbo objUserDB = new UserDbo();
            return objUserDB.NameMatch(Name);
        }

        public string Create(User objUser)
        {
            string UserId = string.Empty;
            try
            {
                string Password = objUser.Password;
                UserDbo objUserDB = new UserDbo();
                objUser.Password = DataFactory.GetEncryptedData(Password);
                UserId = objUserDB.Create(objUser);
                return UserId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Boolean Update(User objuser)
        {
            string Password = objuser.Password;
            UserDbo objuserdb = new UserDbo();
            objuser.Password = DataFactory.GetEncryptedData(Password);

            objuserdb.Update(objuser);
            return true;
        }

        public string CheckOldPass(Int64 Userid)
        {
            UserDbo objuserdb = new UserDbo();
            string password = objuserdb.CheckOldPass(Userid);
            password = DataFactory.GetDecryptedData(password);
            return password;

        }
    }
}
