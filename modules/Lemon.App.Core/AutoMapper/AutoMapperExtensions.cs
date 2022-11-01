using AutoMapper;

namespace Lemon.App.Core.AutoMapper
{
    public class AutoMapperExtensions
    {
        public static void AddAutoMapperProfile<TProfile>(bool validata = false)  where TProfile : Profile, new()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TProfile>();
            });
            if(validata)
            {
                mapperConfiguration.AssertConfigurationIsValid();
            }
            ObjectMapper.Mapper = mapperConfiguration.CreateMapper();
        }

    }
}