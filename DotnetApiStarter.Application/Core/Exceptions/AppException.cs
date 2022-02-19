namespace DotnetApiStarter.Application.Core.Exceptions;

public class AppException : Exception
{
    public AppExceptionCode ExceptionCode { get; set; }
    
    public AppException(string message, AppExceptionCode appExceptionCode)
        : base(message)
    {
        this.ExceptionCode = appExceptionCode;
    }
    
    public AppException(AppExceptionCode appExceptionCode)
        : base($"Application exception for code : {appExceptionCode}")
    {
        this.ExceptionCode = appExceptionCode;
    }
    
    public AppException(AppExceptionCode appExceptionCode, Exception ex)
        : base($"Application exception for code : {appExceptionCode}", ex)
    {
        this.ExceptionCode = appExceptionCode;
    }
    
    public AppException(string message, AppExceptionCode appExceptionCode, Exception ex)
        : base(message)
    {
        this.ExceptionCode = appExceptionCode;
    }
}