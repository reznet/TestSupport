using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TestSupport;

namespace TestSupportTests
{
    [TestClass]
    public class ThrowExceptionTraceListenerTests
    {
        [TestMethod]
        public void FailThrowsAssertFailureException()
        {
            Expect.That(() =>
                {
                    Trace.Fail("FAIL");
                }).Throws<AssertFailureException>();
            
        }
    }
}
