using TripServiceKata.Entity;
using Xunit;

namespace TripServiceKata.Tests
{
    public class UserShould
    {


        [Fact]
        public void user_get_Friends()
        {
            var firstUser = new User();

            Assert.True(firstUser.GetFriends().Count == 0);

        }

        [Fact]
        public void add_friend()
        {
            var firstUser = new User();
            var newFriendForfirstUser = new User();

            firstUser.AddFriend(newFriendForfirstUser);

            Assert.Contains(newFriendForfirstUser, firstUser.GetFriends());

        }


    }
}
