using System;
using System.Diagnostics;

namespace TestSupport
{
    /// <summary>
    /// A class that enables a test to validate expected behavior from a test method.
    /// </summary>
    public static class Expect
    {
        /// <summary>
        /// Encapsulates a test method.
        /// </summary>
        /// <param name="test">The test method to invoke.</param>
        /// <returns>A TestBody that represents the test method.</returns>
        public static TestBody That(Action test)
        {
            return new TestBody(test);
        }

        /// <summary>
        /// A class that represents a test method.
        /// </summary>
        public class TestBody
        {
            /// <summary>
            /// Initializes a new instance of the TestBody class with the provided test method.
            /// </summary>
            /// <param name="test">An Action representing the method to test.</param>
            public TestBody(Action test)
            {
                this.Test = test;
            }

            /// <summary>
            /// Gets or sets the test method.
            /// </summary>
            private Action Test { get; set; }

            /// <summary>
            /// Verifies that the test method throws the specified exception type.
            /// </summary>
            /// <typeparam name="T">The exception type that should be thrown by the test.</typeparam>
            public void Throws<T>() where T : Exception
            {
                this.Throws<T>(null);
            }

            /// <summary>
            /// Verifies that the test method throws the specified exception type and 
            /// calls a verifier to validate the caught exception.
            /// </summary>
            /// <typeparam name="T">The exception type that should be thrown by the test.</typeparam>
            /// <param name="verifier">An Action that is invoked to verify that the caught exception is correct.</param>
            public void Throws<T>(Action<T> verifier) where T : Exception
            {
                bool didCatch = false;

                try
                {
                    this.Test();
                }
                catch (Exception e)
                {
                    didCatch = true;
                    Type caughtType = e.GetType();

                    Trace.TraceInformation("Caught exception type {0}", caughtType);
                    if (typeof(T) != caughtType)
                    {
                        throw new UnexpectedExceptionThrownException(typeof(T), caughtType);
                    }

                    if (verifier != null)
                    {
                        verifier((T)e);
                    }
                }
                finally
                {
                    if (!didCatch)
                    {
                        throw new NothingThrownException(string.Format("Expected exception type {0} but nothing was thrown.", typeof(T).Name));
                    }
                }
            }
        }
    }
}
