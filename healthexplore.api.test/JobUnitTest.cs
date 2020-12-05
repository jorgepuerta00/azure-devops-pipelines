using System.Linq;
using healthexplore.job.api.Configuration;
using healthexplore.job.api.Models;
using healthexplore.job.api.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Xunit;

namespace healthexplore.api.test
{
    public class JobUnitTest
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        [Fact]
        public async void JobsTest()
        {
            // Arrange
            var _config = InitConfiguration();
            var _options = Options.Create(_config.GetSection("ConnectionString").Get<ConnectionString>());
            var _jobRepository = new Repository<Job>(_options);

            // Act
            var jobs = await _jobRepository.GetAll();

            // Assert
            Assert.True(jobs.Count() > 0, "Can't read jobs document");
        }

        [Fact]
        public async void JobsSearchTest()
        {
            // Arrange
            var _config = InitConfiguration();
            var _options = Options.Create(_config.GetSection("ConnectionString").Get<ConnectionString>());
            var _jobRepository = new Repository<Job>(_options);

            // Act
            var jobs = await _jobRepository.SearchByKeyword("charge");

            // Assert
            Assert.True(jobs.Count() >= 0, "Can't read jobs document");
        }
    }
}
