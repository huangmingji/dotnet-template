using System;
namespace Lemon.App.Core.ExceptionExtensions
{
	public class ValidationError
	{
		public string Message { get; set; }

		public string[] Members { get; set; }
	}
}

