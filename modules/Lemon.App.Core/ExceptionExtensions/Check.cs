using System;
using Lemon.Common.Extend;
using System.Data;

namespace Lemon.App.Core.ExceptionExtensions
{
    public class Check
    {
        public static void NotNullOrWhiteSpace(string value, string name)
        {
            if (value.IsNullOrWhiteSpace())
            {
                throw new NoNullAllowedException($"{name}不能为空");
            }
        }
    }
}

