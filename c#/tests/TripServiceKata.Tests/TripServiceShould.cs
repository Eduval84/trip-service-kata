using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        [Fact]
        public void failTest()
        {
            var tripService = new TripService();
            tripService.GetTripsByUser(null);

            Assert.True(false);
        }
    }
}
