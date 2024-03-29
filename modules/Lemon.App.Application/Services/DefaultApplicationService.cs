﻿using System;
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
    public class DefaultApplicationService<TEntity, TEntityDto, TKey, TCreateOrUpdateParamsDto, TGetPageListParamsDto>
        : BaseService, IDefaultApplicationService<TEntityDto, TKey, TCreateOrUpdateParamsDto, TGetPageListParamsDto>
        where TEntity : class, IEntity<TKey>, new()
        where TEntityDto : class, new()
        where TKey : notnull
        where TCreateOrUpdateParamsDto : class, new()
        where TGetPageListParamsDto : class, IPagedRequestDto, new()
    {
        private readonly IAppRepository<TEntity, TKey> _repository;

        public DefaultApplicationService(
            IServiceProvider serviceProvider,
            IAppRepository<TEntity, TKey> repository)
            : base(serviceProvider)
        {
            _repository = repository;
        }

        protected string CreatePolicyName { get; set; } = "";
        protected string UpdatePolicyName { get; set; } = "";
        protected string SearchPolicyName { get; set; } = "";
        protected string DeletePolicyName { get; set; } = "";
        protected string GetEntityPolicyName { get; set; } = "";

        protected virtual TEntity FillCreateEntity(TCreateOrUpdateParamsDto input)
        {
            return default(TEntity);
        }

        public virtual async Task<TEntityDto> CreateAsync(TCreateOrUpdateParamsDto input)
        {
            await base.ApplicationAuthorizationAsync(CreatePolicyName);
            var data = FillCreateEntity(input);
            var result = await _repository.InsertAsync(data);
            return ObjectMapper.Map<TEntity, TEntityDto>(result);
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            await base.ApplicationAuthorizationAsync(DeletePolicyName);
            await _repository.DeleteAsync(id);
        }

        public virtual async Task DeleteManyAsync(IEnumerable<TKey> ids)
        {
            await base.ApplicationAuthorizationAsync(DeletePolicyName);
            await _repository.DeleteManyAsync(ids);
        }

        public virtual async Task<TEntityDto> GetAsync(TKey id)
        {
            await base.ApplicationAuthorizationAsync(GetEntityPolicyName);
            var data = await _repository.GetAsync(id);
            return ObjectMapper.Map<TEntity, TEntityDto>(data);
        }

        protected virtual Expression<Func<TEntity, bool>> GetPageListExpression(TGetPageListParamsDto input)
        {
            return Expressionable.Create<TEntity>();
        }

        protected virtual Func<TEntity, Object> GetPageListOrderBy()
        {
            return null;
        }

        protected virtual Func<TEntity, Object> GetPageListOrderByDescending()
        {
            return null;
        }

        public virtual async Task<PagedResultDto<TEntityDto>> GetPageListAsync(TGetPageListParamsDto input)
        {
            await base.ApplicationAuthorizationAsync(SearchPolicyName);
            var expression = GetPageListExpression(input);
            var total = await _repository.CountAsync(expression);
            var data = _repository.FindList(expression, input.PageIndex, input.PageSize, true, GetPageListOrderBy(), GetPageListOrderByDescending());
            return new PagedResultDto<TEntityDto>()
            {
                Total = total,
                Data = ObjectMapper.Map<List<TEntity>, List<TEntityDto>>(data)
            };
        }

        protected virtual void FillUpdateEntity(TCreateOrUpdateParamsDto input, ref TEntity entity)
        {
        }

        public virtual async Task<TEntityDto> UpdateAsync(TKey id, TCreateOrUpdateParamsDto input)
        {
            await base.ApplicationAuthorizationAsync(UpdatePolicyName);
            var data = await _repository.GetAsync(id);
            FillUpdateEntity(input, ref data);
            var result = await _repository.UpdateAsync(data);
            return ObjectMapper.Map<TEntity, TEntityDto>(data);
        }
    }
}

