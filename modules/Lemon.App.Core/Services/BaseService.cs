using Lemon.Common.Snowflake;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.App.Core.Services
{
    public class BaseService
    {
        protected IServiceProvider _serviceProvider;
        public BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IdWorker SnowflakeIdGenerator
        {
            get
            {
                IConfiguration? configuration = _serviceProvider.GetService<IConfiguration>();
                long workerId = 1;
                long dataCenterId = 1;
                long sequence = 0;
                if (configuration != null)
                {
                    Int64.TryParse(configuration.GetSection("Snowflake:WorkerId").Value, out workerId);
                    Int64.TryParse(configuration.GetSection("Snowflake:DataCenterId").Value, out dataCenterId);
                    Int64.TryParse(configuration.GetSection("Snowflake:Sequence").Value, out sequence);
                }
                return new IdWorker(workerId, dataCenterId, sequence);
            }
        }

        public SequentialGuid.SequentialGuid GuidGenerator
        {
            get
            {
                return new SequentialGuid.SequentialGuid();
            }
        }
    }
}