using System.Net;

namespace CleanArch.Application.Common.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
    public DuplicateEmailException(string email)
        : base($"User with email {email} already exists.")
    {
    }

    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "User with given email already exists.";

}