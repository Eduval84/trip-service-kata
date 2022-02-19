using NSubstitute;
using System;
using System.Collections.Generic;
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
            var tripService = new TripService(UserSession.GetInstance());
            tripService.GetTripsByUser(null);

            Assert.True(false);
        }

        [Fact]
        public void throw_user_not_logged_in_exception()
        {
            var userSession = Substitute.For<IUserSession>();
            var service = new TripService(userSession);

            Assert.Throws<UserNotLoggedInException>(()=>service.GetTripsByUser(null));
        }

        [Fact]
        public void tripsList_by_user_must_be_empty()
        {
            var moqUser = new User();
            var userSession = Substitute.For<IUserSession>();
            var service = new TripService(userSession);

            var unused=userSession.GetLoggedUser().Returns(moqUser);

            Assert.Empty(service.GetTripsByUser(moqUser));
        }

        [Fact]
        public void Find_Trips_By_User()
        {

            var moqLoggedUserUser = new User();
            var moqUser = new User();

            moqUser.AddFriend(moqLoggedUserUser);
            var userSession = Substitute.For<IUserSession>();
            var service = new TripService(userSession);

            var unused=userSession.GetLoggedUser().Returns(moqLoggedUserUser);
            var moqExpectedTripList = new List<Trip>();
            moqUser.FindTripsByUser().Returns(moqExpectedTripList);
            
            var trips = service.GetTripsByUser(moqUser);
            Assert.True(trips == moqExpectedTripList);
 
        }

    }
}
