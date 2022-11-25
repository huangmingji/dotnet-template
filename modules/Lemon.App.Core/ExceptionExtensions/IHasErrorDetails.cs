using System;
namespace Lemon.App.Core.ExceptionExtensions
{
	public interface IHasErrorDetails
	{
		string Details { get; set; }
	}
}

