using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSupport;

namespace ThrowExceptionTraceListenerTestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Trace.Fail("FAIL");
            }
            catch (AssertFailureException afe)
            {
                if (!"FAIL".Equals(afe.Message))
                {
                    Console.Error.WriteLine("Wrong message in caught AssertFailureException.  Expected 'FAIL' but got '{0}", afe.Message);
                    Environment.Exit(1);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Trace.Fail() did not throw expected exception type.  Expected AssertFailureException, but caught '{0}'", e.GetType());
                Environment.Exit(2);
            }
        }
    }
}
