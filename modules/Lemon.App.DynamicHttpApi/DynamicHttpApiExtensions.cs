using System;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.DynamicHttpApi
{
	public static class DynamicHttpApiExtensions
	{
		public static IServiceCollection AddDynamicHttpApi(this IServiceCollection services, Action<DynamicHttpApiOptions> action)
		{
			return services;
		}
	}
}

