

using Microsoft.AspNetCore.Http;
using System;

namespace ERP.Common.Classes
{

    public class ProdErrorHandlingContext : AbstractProdErrorHandlingContext
    {
        public ProdErrorHandlingContext(HttpContext httpContext, Exception exception)
        {
            errorCode = interalErrorCode;
            message = exception.Message;
        }

    }
}