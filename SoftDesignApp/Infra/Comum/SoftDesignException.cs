using System;
using System.Collections.Generic;
using System.Net;

namespace Infra.Comum
{
    public class SoftDesignException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public IList<string> Messages { get; set; } = new List<string>();
    }
}
