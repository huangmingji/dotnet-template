using System;
using System.Net;

namespace Lemon.App.Core.ExceptionExtensions
{
	public class NoNullAllowedException : BusinessException
    {
        public NoNullAllowedException()
        {
        }

        public NoNullAllowedException(string message = null, string details = null, Exception innerException = null)
            : base(code: HttpStatusCode.Forbidden.ToString(), message: message, details: details, innerException: innerException)
        {
        }

    }
}

