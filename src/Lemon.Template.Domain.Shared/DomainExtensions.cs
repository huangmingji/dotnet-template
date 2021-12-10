using System;
using Lemon.Common.Extend;

namespace Lemon.Template.Domain.Shared
{
    public class Check
    {
        public static void NotNullOrWhiteSpace(string value, string name)
        {
            if (value.IsNullOrWhiteSpace())
            {
                throw new Exception($"{name}不能为空");
            }
        }

    }
}