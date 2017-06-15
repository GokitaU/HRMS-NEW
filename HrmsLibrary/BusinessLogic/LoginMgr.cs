using HrmsLibrary.Common;
using HrmsLibrary.DataAccess;
using HrmsObjects.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.BusinessLogic
{
    [Serializable]
    public class LoginMgr
    {
        public User UserDetails(string UserName, string Password)
        {
            string DecPassword = string.Empty;
            LoginDBops objLogin = new LoginDBops();
            DecPassword = DataFactory.GetEncryptedData(Password);
            return objLogin.MyHome1(UserName, DecPassword);
        }
    }
}
