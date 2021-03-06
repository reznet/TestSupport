﻿using System;
using System.Diagnostics;

namespace TestSupport
{
    /// <summary>
    /// A trace listener that throws an exception when a Debug.Assert or Debug.Fail fails.
    /// </summary>
    public class ThrowExceptionTraceListener : TraceListener
    {
        // add this trace listener to the app.config for an mstest-based test library
        // and when a Debug.Assert fails the test will stop and the error will
        // be logged as if the code had thrown an exception.
        // 
        //<system.diagnostics>
        //    <trace>
        //        <listeners>
        //        <clear />
        //        <add name="DevDashTraceListener" type="SqlDevDashTest.CodeReviewTests.DevDashTraceListener, DevDashTest" />
        //        </listeners>
        //    </trace>
        //    <assert assertuienabled="false" />
        //</system.diagnostics>

        public override void Write(string message)
        {
            // do nothing.  the trace listener added by the test framework already writes messages to the test log
        }

        public override void WriteLine(string message)
        {
            // do nothing.  the trace listener added by the test framework already writes messages to the test log
        }

        public override void Fail(string message)
        {
            throw new AssertFailureException(message);
        }

        public override void Fail(string message, string detailMessage)
        {
            throw new AssertFailureException(message + Environment.NewLine + detailMessage);
        }
    }
}
