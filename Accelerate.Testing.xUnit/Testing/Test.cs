using System;
using Xunit;

namespace Accelerate.Testing
{
    /// <summary>
    /// Base class of xUnit test.
    /// </summary>
    public class Test<T> : IClassFixture<T>, IDisposable where T : Fixture
    {
        private Boolean _disposed;
        private T _fixture;

        /// <summary>
        /// Initialize a new instance of <seealso cref="Test{T}" /> class.
        /// </summary>
        /// <param name="fixture">
        /// Fixture binded to a test.
        /// </param>
        public Test(T fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Fixture binded to a test.
        /// </summary>
        protected T Fixture => _fixture;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// Indicate if object is currently freeing, releasing, or resetting unmanaged resources.
        /// </param>
        protected virtual void Dispose(Boolean disposing)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }

            if (disposing)
            {
                _fixture.Dispose();
                _fixture = null;
            }

            _disposed = true;
        }
    }
}
