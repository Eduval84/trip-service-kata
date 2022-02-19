using TripServiceKata.Entity;
using TripServiceKata.Exception;

namespace TripServiceKata.Service
{
    public class UserSession : IUserSession
    {
        private static readonly IUserSession userSession = new UserSession();

        private UserSession()
        {
        }

        public static IUserSession GetInstance()
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