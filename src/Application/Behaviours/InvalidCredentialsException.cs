
using System.Net;

namespace Application.Behaviours
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Invalid Credentials. Please try again.")
        { }
        public InvalidCredentialsException(string message) : base(message)
        {
            throw new HttpStatusException(HttpStatusCode.BadRequest, message);
        }
        public InvalidCredentialsException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}