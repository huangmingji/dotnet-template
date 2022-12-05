using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Lemon.App.Core.Extend;
using Lemon.App.Core.Snowflake;

namespace Lemon.App.Application.Services
{
    public class BaseService
    {
        private IAuthorizationService? _authorizationService;
        private IHttpContextAccessor? _httpContextAccessor;
        protected IServiceProvider _serviceProvider;
        public BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private static IdWorker _idWorker;
        protected IdWorker SnowflakeIdGenerator
        {
            get
            {
                if(_idWorker == null)
                {
                    IConfiguration? configuration = _serviceProvider.GetService<IConfiguration>();
                    long workerId = 1;
                    long dataCenterId = 1;
                    long sequence = 0;
                    if (configuration != null)
                    {
                        workerId = configuration.GetSection("Snowflake:WorkerId").Value.ToInt64(1);
                        dataCenterId = configuration.GetSection("Snowflake:DataCenterId").Value.ToInt64(1);
                        sequence = configuration.GetSection("Snowflake:Sequence").Value.ToInt64();
                    }
                    _idWorker = new IdWorker(workerId, dataCenterId, sequence);
                }
                return _idWorker;
            }
        }

        protected SequentialGuid.SequentialGuid GuidGenerator => new SequentialGuid.SequentialGuid();

        protected IAuthorizationService? AuthorizationService
        {
            get
            {
                if(_authorizationService == null)
                {
                    _authorizationService = _serviceProvider.GetService<IAuthorizationService>();
                }
                return _authorizationService;
            }
        }

        protected IHttpContextAccessor? HttpContextAccessor
        {
            get
            {
                if(_httpContextAccessor == null)
                {
                    _httpContextAccessor = _serviceProvider.GetService<IHttpContextAccessor>();
                }
                return  _httpContextAccessor;
            }
        }

        protected async Task ApplicationAuthorizationAsync(string policyName)
        {
            if (!policyName.IsNullOrWhiteSpace())
            {
                if (AuthorizationService == null)
                {
                    throw new InvalidOperationException("Unable to resolve service for type {IAuthorizationService}");
                }
                if (HttpContextAccessor == null)
                {
                    throw new InvalidOperationException("Unable to resolve service for type {IHttpContextAccessor}");
                }
                await AuthorizationService.AuthorizeAsync(HttpContextAccessor.HttpContext.User, policyName);
            }
        }
    }
}