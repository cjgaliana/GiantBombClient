using System;
using System.Net;

namespace GiantBombClient.Exceptions
{
    public class GiantBoomClientQueryException : Exception
    {
        public GiantBoomClientQueryException()
            : this(string.Empty)
        {
        }

        public GiantBoomClientQueryException(string message)
            : base(message)
        {
        }

        public HttpStatusCode StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public int ErrorCode { get; set; }
    }
}