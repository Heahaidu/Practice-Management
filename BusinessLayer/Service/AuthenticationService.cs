using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AuthenticationService
    {
        public bool Login(string username, string password)
        {
            DataLayer.LoginDL loginDL = new DataLayer.LoginDL();
            
            (bool success, TransferObject.User user) = loginDL.Login(username, password);

            if (!success)
            {
                return false;
            }

            UserSession.Instance.SetCurrentUser(user);

            return true;
        }
    }
}
