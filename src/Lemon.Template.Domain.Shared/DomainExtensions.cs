using System.Data;
using Lemon.Common.Extend;

namespace Lemon.Template.Domain.Shared
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