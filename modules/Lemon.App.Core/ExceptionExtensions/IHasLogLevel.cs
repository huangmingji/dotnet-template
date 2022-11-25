using System;
using Microsoft.Extensions.Logging;

namespace Lemon.App.Core.ExceptionExtensions
{
	public interface IHasLogLevel
	{
        LogLevel LogLevel { get; set; }
    }
}

