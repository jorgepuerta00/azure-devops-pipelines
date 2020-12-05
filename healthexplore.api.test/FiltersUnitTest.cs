using healthexplore.filters.api.Configuration;
using healthexplore.filters.api.Models;
using healthexplore.filters.api.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Xunit;

namespace healthexplore.api.test
{
    public class FiltersUnitTest
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        [Fact]
        public async void FiltersTest()
        {
            // Arrange
            var _config = InitConfiguration();
            var _options = Options.Create(_config.GetSection("ConnectionString").Get<ConnectionString>());
            var _jobRepository = new Repository<Filters>(_options);

            // Act
            var filters = await _jobRepository.GetAll();

            // Assert
            Assert.True(filters != null, "Can't read filters document");
        }
    }
}
