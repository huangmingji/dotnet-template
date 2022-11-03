using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lemon.App.Application.Contracts.Pagination;
using Lemon.App.Application.Contracts.Services;
using Lemon.App.Core.AutoMapper;
using Lemon.App.Core.Extend;
using Lemon.App.Domain.Repositories;
using Lemon.App.Domain.Shared.Entities;

namespace Lemon.App.Application.Services
{
    public class DefaultApplicationService<TEntity, TEntityDto, TKey, TCreateOrUpdateParamsDto, TGetPageListParamsDto, TGetListParamsDto>
        : BaseService, IDefaultApplicationService<TEntity, TEntityDto, TKey, TCreateOrUpdateParamsDto, TGetPageListParamsDto, TGetListParamsDto>
        where TEntity : class, IEntity<TKey>, new()
        where TEntityDto : class, new()
        where TKey : notnull
        where TCreateOrUpdateParamsDto : class, new()
        where TGetPageListParamsDto : class, IPagedRequestDto, new()
        where TGetListParamsDto : class, new()
    {

        private readonly IEfCoreRepository<TEntity, TKey> _repository;

        public DefaultApplicationService(
            IServiceProvider serviceProvider,
            IEfCoreRepository<TEntity, TKey> repository)
            : base(serviceProvider)
        {
            _repository = repository;
        }

        protected virtual TEntity FillCreateEntity(TCreateOrUpdateParamsDto input)
        {
            return default(TEntity);
        }

        public async Task<TEntityDto> CreateAsync(TCreateOrUpdateParamsDto input)
        {
            var data = FillCreateEntity(input);
            var result = await _repository.InsertAsync(data);
            return ObjectMapper.Map<TEntity, TEntityDto>(result);
        }

        public async Task DeleteAsync(TKey id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task DeleteManyAsync(IEnumerable<TKey> ids)
        {
            await _repository.DeleteManyAsync(ids);
        }

        public async Task<TEntityDto> GetAsync(TKey id)
        {
            var data = await _repository.GetAsync(id);
            return ObjectMapper.Map<TEntity, TEntityDto>(data);
        }

        protected virtual Expression<Func<TEntity, bool>> GetPageListExpression(TGetPageListParamsDto input)
        {
            return ExtLinq.True<TEntity>();
        }

        public async Task<PagedResultDto<TEntityDto>> GetPageListAsync(TGetPageListParamsDto input)
        {
            var expression = GetPageListExpression(input);
            var total = await _repository.CountAsync(expression);
            var data = await _repository.FindListAsync(expression, input.PageIndex, input.PageSize);
            return new PagedResultDto<TEntityDto>() {
                Total = total,
                Data = ObjectMapper.Map<List<TEntity>, List<TEntityDto>>(data)
            };
        }

        protected virtual void FillUpdateEntity(TCreateOrUpdateParamsDto input, ref TEntity entity)
        {
        }

        public async Task<TEntityDto> UpdateAsync(TKey id, TCreateOrUpdateParamsDto input)
        {
            var data = await _repository.GetAsync(id);
            FillUpdateEntity(input, ref data);
            var result = await _repository.UpdateAsync(data);
            return ObjectMapper.Map<TEntity, TEntityDto>(data);
        }


        protected virtual Expression<Func<TEntity, bool>> GetListExpression(TGetListParamsDto input)
        {
            return ExtLinq.True<TEntity>();
        }
        public async Task<List<TEntityDto>> GetListAsync(TGetListParamsDto input)
        {
            var expression = GetListExpression(input);
            var data = await _repository.FindListAsync(expression);
            return ObjectMapper.Map<List<TEntity>, List<TEntityDto>>(data);
        }
    }
}

