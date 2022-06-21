using System.Net;

namespace Application.Behaviours
{
    public class HandleDbException : Exception
    {
        public HandleDbException() : base("Database error detected. Please try again.")
        {
        }

        public HandleDbException(string message) : base(message)
        {
        }

        public HandleDbException(string message, Exception ex) : base(message, ex)
        {
            if(ex.Message != null)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    throw new HttpStatusException(HttpStatusCode.Conflict, "Record already exist.");
                }else{
                    throw new HttpStatusException(HttpStatusCode.BadGateway, ex.Message);
                }
            }else{
                throw new HttpStatusException(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}