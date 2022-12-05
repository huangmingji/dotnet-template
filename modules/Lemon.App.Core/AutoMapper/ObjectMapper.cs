using System.Collections.Generic;
using AutoMapper;

namespace Lemon.App.Core.AutoMapper
{
    public class ObjectMapper
    {
        internal static IMapper Mapper { get; set; }

        public static TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class, new()
            where TDestination : class, new()
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
        
        public static List<TDestination> Map<TSource, TDestination>(List<TSource> source)
            where TSource : class, new()
            where TDestination : class, new()
        {
            return Mapper.Map<List<TSource>, List<TDestination>>(source);
        }
        
        public static List<TDestination> Map<TSource, TDestination>(TSource[] source)
            where TSource : class, new()
            where TDestination : class, new()
        {
            return Mapper.Map<TSource[], List<TDestination>>(source);
        }

    }
}