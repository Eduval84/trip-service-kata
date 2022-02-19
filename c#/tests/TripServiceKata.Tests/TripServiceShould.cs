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
    }
}
