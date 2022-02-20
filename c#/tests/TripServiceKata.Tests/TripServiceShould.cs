using NSubstitute;
using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        private readonly IUserSession userSessionMoq = Substitute.For<IUserSession>();
        private readonly ITripDAO tripDaoMoq = Substitute.For<ITripDAO>();
        private TripService service;
        

        [Fact]
        public void throw_user_not_logged_in_exception()
        {
            var service = new TripService(userSessionMoq, new TripDAO());

            Assert.Throws<UserNotLoggedInException>(()=>service.GetTripsByUser(null));
        }

        [Fact]
        public void tripsList_by_user_must_be_empty()
        {
            var user = new User();
            service = new TripService(userSessionMoq, new TripDAO());

            //Configured Call
            userSessionMoq.GetLoggedUser().Returns(user);

            Assert.Empty(service.GetTripsByUser(user));
        }

        [Fact]
        public void Find_Trips_By_Friends_Users()
        {

            service = new TripService(userSessionMoq, tripDaoMoq);

            var userToBeAddedLikeAFriend = new User();
            var testUser = new User();

            testUser.AddFriend(userToBeAddedLikeAFriend);

            //Configured Call
            userSessionMoq.GetLoggedUser().Returns(userToBeAddedLikeAFriend);

            List<Trip> expectedListOfTrip = new List<Trip>();

            //Configured Call
            tripDaoMoq.FindTripsByUser(testUser).Returns(expectedListOfTrip);

            var trips = service.GetTripsByUser(testUser);
            Assert.Equal(trips,expectedListOfTrip);

        }


        [Fact]
        public void if_they_are_not_friends_trips_must_be_empty()
        {
            var userWithoutFriends = new User();

            userSessionMoq.GetLoggedUser().Returns(userWithoutFriends);

            service = new TripService(userSessionMoq, tripDaoMoq);

            var trips = service.GetTripsByUser(userWithoutFriends);

            Assert.True(trips.Count == 0);

        }
    }
}
