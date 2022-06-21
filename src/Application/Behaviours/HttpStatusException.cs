using System.Net;

namespace Application.Behaviours
{
    public class HttpStatusException : Exception
    {
        public HttpStatusCode Status { get; }

        public HttpStatusException(HttpStatusCode status, string msg) : base(msg)
        {
            Status = status;
        }

        public HttpStatusException() : base()
        {
        }

        public HttpStatusException(string message) : base(message)
        {
        }

        public HttpStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}