using ERP.Common.Interfaces;

namespace ERP.Common.Classes
{
    public abstract class AbstractProdErrorHandlingContext : IProdErrorHandlingContext
    {
        public int errorCode;
        public string message;
        public const int interalErrorCode = 500;
        public virtual int GetErrorCode()
        {
            return errorCode;
        }
        public virtual string GetMessage()
        {
            return message;
        }
    }
}
