using System;
using System.Reflection;

namespace Lemon.App.DynamicHttpApi
{
	public class DynamicHttpApiOptions
	{
		public static string DefaultHttpApiPrefix { get; set; } = "api";

		internal static Assembly[] Assemblies { get; set; } = new Assembly[0];

        public void CreateControllers(Assembly[] assemblies)
		{
            Assemblies = assemblies;
		}

    }
}

