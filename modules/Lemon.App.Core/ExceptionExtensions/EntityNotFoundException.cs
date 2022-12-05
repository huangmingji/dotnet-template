using System;
using System.Net;
using Lemon.App.Core.Extend;
using Microsoft.Extensions.Logging;

namespace Lemon.App.Core.ExceptionExtensions
{
	public class EntityNotFoundException : BusinessException
    {
		public EntityNotFoundException()
		{
		}

        public EntityNotFoundException(string message = null, string details = null, Exception innerException = null)
            : base(code: HttpStatusCode.NotFound.ToString(), message: message, details: details, innerException: innerException)
        {
        }

    }
}

