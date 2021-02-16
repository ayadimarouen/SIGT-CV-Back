

using Microsoft.AspNetCore.Http;
using System;

namespace ERP.Common.Classes
{
    public class DevErrorHandlingContext : AbstractProdErrorHandlingContext
    {
        public string exceptionType;
        public string innerException;
        public string classAndMethodName;
        public int lineOfCode;
        public int columnNumberOfCode;
        public DevErrorHandlingContext(HttpContext httpContext, Exception exception)
        {
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(exception, true);
            errorCode = interalErrorCode;
            classAndMethodName = trace.GetFrame(0).GetMethod().ReflectedType.FullName;
            lineOfCode = trace.GetFrame(0).GetFileLineNumber();
            columnNumberOfCode = trace.GetFrame(0).GetFileColumnNumber();
            innerException = exception.InnerException == null ? String.Empty : exception.InnerException.ToString();
            message = exception.Message;
            exceptionType = exception.GetType().FullName;
        }
    }
}
