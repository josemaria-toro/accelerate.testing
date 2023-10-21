using Microsoft.Extensions.Configuration;
using System;

namespace Accelerate.Testing
{
    /// <summary>
    /// Base class of xUnit fixture.
    /// </summary>
    public class Fixture : IDisposable
    {
        private IConfiguration _configuration;

        /// <summary>
        /// Initialize a new instance of <seealso cref="Fixture" /> class.
        /// </summary>
        public Fixture()
        {
            OnTestInit();
        }

        /// <summary>
        /// Configuration service instance.
        /// </summary>
        public IConfiguration Configuration => _configuration;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            OnTestDestroy();
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Perform test-defined tasks associated with freeing, releasing, or resetting resources.
        /// </summary>
        protected virtual void OnTestDestroy()
        {
            _configuration = null;
        }
        /// <summary>
        /// Perform test-defined tasks associated with test initialization.
        /// </summary>
        protected virtual void OnTestInit()
        {
            _configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                                                       .AddEnvironmentVariables()
                                                       .AddInMemoryCollection()
                                                       .AddJsonFile("appsettings.json", true, true)
                                                       .Build();
        }
    }
}
