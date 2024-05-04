using System.Net;

namespace BS.Application.Common.Errors
{
    public interface IServiceException
    {
        public HttpStatusCode StatusCode { get;  }  

        public string ErrorMessage { get;  }
    }
}
