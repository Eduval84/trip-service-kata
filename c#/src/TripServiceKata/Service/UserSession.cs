using TripServiceKata.Entity;
using TripServiceKata.Exception;

namespace TripServiceKata.Service
{
    public class UserSession : IUserSession
    {
        private UserSession()
        {
        }

        public User GetLoggedUser()
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.GetLoggedUser() should not be called in an unit test");
        }
    }
}