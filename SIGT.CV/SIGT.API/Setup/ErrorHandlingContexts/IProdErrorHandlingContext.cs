namespace ERP.Common.Interfaces
{
    public interface IProdErrorHandlingContext
    {
        int GetErrorCode();
        string GetMessage();
    }
}