namespace Restaurant_mgmt.Core.Errors;

public class ApiException : Exception
{
    private int StatusCode { get; set; }
    private string Message { get; set; }
    private string Details { get; set; }

    public ApiException(int statusCode, string message = null, string details = null)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }
}