using System.Collections.Generic;
using System.Linq;

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

        public bool IsFriend(User loggedUser)
        {
            return (from friend in GetFriends() let isFriend = true select friend).Contains(loggedUser);
        }
    }
}