using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using PostSharp.Aspects;

namespace ConsoleApplication1
{
    [Serializable]
    public class ExceptionAspect : OnExceptionAspect
    {
        public string Message { get; set; }

        public Type ExceptionType { get; set; }

        public FlowBehavior Behavior { get; set; }

        public override void OnException(MethodExecutionArgs args)
        {
            string msg = DateTime.Now + ": " + Message + Environment.NewLine;
            msg += string.Format("{0}: Error running {1}. {2}{3}{4}", DateTime.Now, args.Method.Name, args.Exception.Message, Environment.NewLine, args.Exception.StackTrace);
            Debug.WriteLine(msg);
            args.FlowBehavior = FlowBehavior.Continue;
        }

        public override Type GetExceptionType(System.Reflection.MethodBase targetMethod)
        {
            return ExceptionType;
        }
    }
}
