using DatabaseData.DatabaseLayer;
using RESTfulService.BusinesslogicLayer;

namespace Samtidighedstest
{
    public class UnitTest1
    {
        [Fact]
        public void TryLockFlight_ShouldLockAvailableFlight()
        {
            // Arrange
            var mockFlightAccess = new Mock<IFlightAccess>();
            mockFlightAccess.Setup(m => m.TryLockFlight(It.IsAny<int>(), It.IsAny<string>())).Returns(true);
            var flightdataControl = new FlightdataControl(mockFlightAccess.Object);

            // Act
            var result = flightdataControl.TryLockFlight(1, "testUser");

            // Assert
            Assert.IsTrue(result);
        }
    }
}