using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class TripService
    {
        private readonly IUserSession userSession;
        private readonly ITripDAO tripDao;
        private bool isFriend;

        public TripService(IUserSession userSession, ITripDAO tripDao)
        {
            this.userSession = userSession;
            this.tripDao = tripDao;
        }

        public List<Trip> GetTripsByUser(User user)
        {
            User loggedUser = GetLoggedUser();

            if (loggedUser == null) throw new UserNotLoggedInException();

            return user.IsFriend(loggedUser) ? tripDao.FindTripsByUser(user) : new List<Trip>();
        }

        private User GetLoggedUser()
        {
            return userSession.GetLoggedUser();
        }
    }
}