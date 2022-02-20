using NSubstitute;
using System;
using System.Collections.Generic;
using FluentAssertions;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        [Fact]
        public void failTest()
        {
            var tripService = new TripService(UserSession.GetInstance(), new TripDAO());
            tripService.GetTripsByUser(null);

            Assert.True(false);
        }

        [Fact]
        public void throw_user_not_logged_in_exception()
        {
            var userSession = Substitute.For<IUserSession>();
            var service = new TripService(userSession, new TripDAO());

            Assert.Throws<UserNotLoggedInException>(()=>service.GetTripsByUser(null));
        }

        [Fact]
        public void tripsList_by_user_must_be_empty()
        {
            var user = new User();
            var userSession = Substitute.For<IUserSession>();
            var service = new TripService(userSession, new TripDAO());

            var unused=userSession.GetLoggedUser().Returns(user);

            Assert.Empty(service.GetTripsByUser(user));
        }

        [Fact]
        public void Find_Trips_By_User()
        {
            var userSession = Substitute.For<IUserSession>();
            var tripDao = Substitute.For<ITripDAO>();
            var service = new TripService(userSession, tripDao);

            var loggedUser = new User();
            var testUser = new User();

            testUser.AddFriend(loggedUser);

            var configcaCall = userSession.GetLoggedUser().Returns(loggedUser);

            List<Trip> expectedListOfTrip = new List<Trip>();
            var configcaCall2 = tripDao.FindTripsByUser(testUser).Returns(expectedListOfTrip);

            var trips = service.GetTripsByUser(testUser);
            Assert.Equal(trips,expectedListOfTrip);

        }

    }
}
