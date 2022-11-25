using System;
using Microsoft.Extensions.Logging;
using System.Runtime.Serialization;
using System.Collections;

namespace Lemon.App.Core.ExceptionExtensions
{
    public class BusinessException : Exception, IBusinessException, IHasErrorCode, IHasErrorDetails, IHasLogLevel
    {
        public BusinessException(SerializationInfo serializationInfo, StreamingContext context)
        {
        }

        public BusinessException(string code = null, string message = null, string details = null, Exception innerException = null, LogLevel logLevel = LogLevel.Warning)
            :base(message, innerException)
        {
            this.Code = code;
            this.Details = details;
            this.LogLevel = LogLevel;
        }

        public string Code { get; set; }
        public string Details { get; set; }
        public LogLevel LogLevel { get; set; }

        public BusinessException WithData(string name, object value)
        {
            this.Data.Add(name, value);
            return this;
        }
    }
}

