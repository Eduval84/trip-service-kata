﻿using NSubstitute;
using System;
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
        public void tripsList_must_be_empty()
        {
            var moqUser = new User();
            var userSession = Substitute.For<IUserSession>();
            var service = new TripService(userSession);

            var unused=userSession.GetLoggedUser().Returns(moqUser);

            Assert.Empty(service.GetTripsByUser(moqUser));
        }
    }
}
