using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class AccountBL
    {

        public bool UpdateDisplayName(string displayName)
        {
            try
            {
                DataLayer.AccountDL accountDL = new DataLayer.AccountDL();
                bool success = accountDL.UpdateAccount(UserSession.Instance.CurrentUser.username, UserSession.Instance.CurrentUser.password, displayName, UserSession.Instance.CurrentUser.email);
                
                if (!success)
                {
                    return false;
                }   

                UserSession.Instance.CurrentUser.displayName = displayName;
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ChangePassword(string oldPassword, string newPassword, string confirmNewPassword)
        {
            try
            {
                if (oldPassword != UserSession.Instance.CurrentUser.password || newPassword != confirmNewPassword)
                {
                    return false;
                }

                DataLayer.AccountDL accountDL = new DataLayer.AccountDL();
                bool succes = accountDL.UpdateAccount(UserSession.Instance.CurrentUser.username,
                    newPassword, 
                    UserSession.Instance.CurrentUser.displayName, 
                    UserSession.Instance.CurrentUser.email);
                if (!succes)
                {
                    return false;
                }
                UserSession.Instance.CurrentUser.password = newPassword;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                DataLayer.AccountDL accountDL = new DataLayer.AccountDL();
                List<User> users = accountDL.GetUsers();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
