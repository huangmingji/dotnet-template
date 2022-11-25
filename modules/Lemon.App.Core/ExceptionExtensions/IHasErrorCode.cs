using System;
namespace Lemon.App.Core.ExceptionExtensions
{
	public interface IHasErrorCode
	{
		string Code { get; set; }
	}
}

