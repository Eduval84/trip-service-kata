using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Entity
{
    public class User
    {
        private List<User> friends = new List<User>();

        public List<User> GetFriends()
        {
            return friends;
        }

        public void AddFriend(User user)
        {
            friends.Add(user);
        }

        public List<Trip> FindTripsByUser()
        {
            throw new DependendClassCallDuringUnitTestException(
                "TripDAO should not be invoked on an unit test.");
        }
    }
}