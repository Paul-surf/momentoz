using WebserverMomentoz.ServiceLayer;
using Newtonsoft.Json;
using Moq;

namespace MomentozWebServerTests
{
    public class UnitTest1
    {
        private ServiceConnection sc;
        readonly String _serviceBaseUrl = "https://localhost:5114/api/customers";

        public UnitTest1()
        {
            sc = new ServiceConnection(_serviceBaseUrl);
        }
        [Fact]
        public async void isConnectionEstablished()
        {
            bool connection = false;
            var serviceResponse = await sc.CallServiceGet();
            if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
            {
                connection = true;
            }
                Assert.True(connection);
        }
    }
}