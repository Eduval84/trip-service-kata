using TripServiceKata.Entity;
using TripServiceKata.Exception;

namespace TripServiceKata.Service
{
    public class UserSession
    {
        private static readonly UserSession userSession = new UserSession();

        private UserSession()
        {
        }

        public static UserSession GetInstance()
        {
            return userSession;
        }

        public User GetLoggedUser()
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.GetLoggedUser() should not be called in an unit test");
        }
    }
}