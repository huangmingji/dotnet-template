using System;

namespace Lemon.App.Application.Services
{
    public class TransientService : BaseService
    {
        public TransientService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}

