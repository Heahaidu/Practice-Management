using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AuthenticationService
    {
        public (bool, TransferObject.User) Login(string username, string password)
        {
            TransferObject.User user = new TransferObject.User() {
                username = username,
                password = password,
                displayName = "Nguyễn Hải Dương",
                email = "test@gmail.com"
            };

            UserSession.Instance.SetCurrentUser(user);


            return (username == "admin" && password == "password", user);
        }
    }
}
