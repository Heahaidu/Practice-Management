using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserSession
    {
        private static UserSession _instance;
        private static readonly object lockObj = new object();

        public TransferObject.User CurrentUser { get; private set; }

        private UserSession() { }

        public static UserSession Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserSession();
                        }
                    }
                }
                return _instance;
            }
        }

        public void SetCurrentUser(TransferObject.User user)
        {
            CurrentUser = user;
        }

        public void ClearSession()
        {
            CurrentUser = null;
        }

    }
}
