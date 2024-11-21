
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using DAO;
using DAO_Library;

namespace Unit_Testing
{
    public abstract class TestBase
    {
        protected string _connectionString;
        protected IOrderProcessorRepository _orderProcessorRepository;

        [SetUp]
        public void Setup()
        {
            // Build configuration for tests
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("C:\\Users\\ROG\\source\\repos\\ECommerce\\Util\\AppSettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("dbCn");
            _orderProcessorRepository = new OrderProcessorRepositoryImpl(_connectionString);
        }
    }
}