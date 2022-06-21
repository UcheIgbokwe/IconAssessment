using System.Net;

namespace Application.Behaviours
{
    public class InvalidResponseException : Exception
    {
        public InvalidResponseException() : base("Kindly review your request")
        {
            throw new HttpStatusException(HttpStatusCode.NotFound, "Kindly review your request.");
        }

        public InvalidResponseException(string message) : base(message)
        {
            throw new HttpStatusException(HttpStatusCode.BadRequest, message);
        }

        public InvalidResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}