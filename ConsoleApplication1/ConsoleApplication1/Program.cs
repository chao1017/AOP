using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using PostSharp.Aspects;

namespace ConsoleApplication1
{

    class Program
    {
        public static void Main(string[] args)
        {

            ThrowSampleExecption();
            
            Console.ReadLine();
        }

        [ExceptionAspect(ExceptionType = typeof(ApplicationException), Message = "An example exception.", Behavior=FlowBehavior.RethrowException)]
        private static void ThrowSampleExecption()
        {
            throw new ApplicationException("Sample Exception For AOP");

            //FlowBehavior behavior = FlowBehavior.RethrowException;
        }
    }
}
