using RateYourIdea.Core.BaseModels;
using System.Web;

namespace RateYourIdea.Core.Session
{
    public class SessionBusiness
    {
        string SessionToken = "Cabas";

        public void CreateSession(UserInfo userInfo)
        {
            HttpContext.Current.Session.Add(SessionToken, userInfo);
        }

        public bool SessionValidate()
        {
            if (HttpContext.Current.Session[SessionToken] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearSession()
        {
            HttpContext.Current.Session.Remove(SessionToken);
        }

        public UserInfo GetSessionUser()
        {
            return (UserInfo)HttpContext.Current.Session[SessionToken];
        }

        //public string GetUserRole()
        //{
        //    return ((UserInfo)HttpContext.Current.Session[SessionToken]).UserRole;
        //}
    }
}
