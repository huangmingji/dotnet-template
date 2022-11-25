using System;
using System.Collections.Generic;

namespace Lemon.App.Core.ExceptionExtensions
{
	public interface IHasValidationErrors
    {
        List<ValidationError> ValidationErrors { get; set; }
    }
}

