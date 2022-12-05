using System.Data.Common;
using System.Linq.Expressions;
using Lemon.App.Domain.Entities;
using Lemon.App.Domain.Repositories;
using Lemon.App.Core.Cache;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Lemon.App.Domain.Shared.Entities;
using Lemon.App.SqlSugar;
using SqlSugar;
using System.Data;
using System.Reflection;
using Lemon.App.Core.ExceptionExtensions;

namespace Lemon.App.EntityFrameworkCore.Repositories
{
    public sealed class Repository<TDbContext, TEntity, TKey> : IRepository<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>, new()
        where TKey : notnull
    {
        private readonly IDbContextProvider<TDbContext> _dbContextProvider;
        private readonly ISqlSugarClient _sqlSugarClient;
        public Repository(IDbContextProvider<TDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
            _sqlSugarClient = dbContextProvider.GetDbContext().SqlSugarClient;
        }

        public TDbContext GetDbContext()
        {
            return _dbContextProvider.GetDbContext();
        }

        public async Task DeleteAsync(TKey id)
        {
            await _sqlSugarClient.Deleteable<TEntity>().Where(it => it.Id.Equals(id)).ExecuteCommandAsync();
        }

        public async Task DeleteManyAsync(IEnumerable<TKey> ids)
        {
            await _sqlSugarClient.Deleteable<TEntity>().Where(it => ids.Contains(it.Id)).ExecuteCommandAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true)
        {
            var data = await _sqlSugarClient.Queryable<TEntity>().FirstAsync(predicate);
            if (data == null)
            {
                throw new EntityNotFoundException();
            }
            return data;
        }

        public async Task<List<TEntity>> FindAllAsync(bool withDetails = true)
        {
            return await _sqlSugarClient.Queryable<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true)
        {
            return await _sqlSugarClient.Queryable<TEntity>().FirstAsync(predicate);
        }

        public List<TEntity> FindList(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize, bool includeDetails = true,
                    Func<TEntity, Object> orderBy = null, Func<TEntity, Object> orderByDescending = null)
        {
            ISugarQueryable<TEntity> queryable = _sqlSugarClient.Queryable<TEntity>().Where(expression);
            if (orderBy != null)
            {
                queryable = queryable.OrderBy(x => orderBy(x));
            }
            if (orderByDescending != null)
            {
                queryable = queryable.OrderByDescending(x => orderByDescending(x));
            }
            return queryable.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
        }

        public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate, bool withDetails = true)
        {
            return await _sqlSugarClient.Queryable<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> FindListAsync(string sql)
        {
            DataTable data = await _sqlSugarClient.Ado.GetDataTableAsync(sql);
            return ConvertToList(data);
        }

        public async Task<List<TEntity>> FindListAsync(string sql, DbParameter[] dbParameter)
        {
            var sugarParameters = new List<SugarParameter>();
            foreach (var param in dbParameter)
            {
                sugarParameters.Add(new SugarParameter(param.ParameterName, param.Value));
            }
            DataTable data = await _sqlSugarClient.Ado.GetDataTableAsync(sql, sugarParameters);
            return ConvertToList(data);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var result = await _sqlSugarClient.Insertable(entity).ExecuteCommandAsync();
            if (result > 0)
            {
                return entity;
            }
            throw new Exception();
        }

        public async Task<List<TEntity>> InsertAsync(List<TEntity> entities)
        {
            var result = await _sqlSugarClient.Insertable(entities).ExecuteCommandAsync();
            if (result > 0)
            {
                return entities;
            }
            throw new Exception();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = await _sqlSugarClient.Updateable(entity).ExecuteCommandAsync();
            if (result > 0)
            {
                return entity;
            }
            throw new Exception();
        }

        public async Task<TEntity> GetAsync(TKey id, bool withDetails = true)
        {
            var data = await _sqlSugarClient.Queryable<TEntity>().SingleAsync(x=> x.Id.Equals(id));
            if (data == null)
            {
                throw new EntityNotFoundException();
            }
            return data;
        }

        public async Task<TEntity?> FindAsync(TKey id, bool withDetails = true)
        {
            return await _sqlSugarClient.Queryable<TEntity>().SingleAsync(x => x.Id.Equals(id));
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, bool withDetails = true)
        {
            return await _sqlSugarClient.Queryable<TEntity>().AnyAsync(expression);
        }

        //DataTable转成List
        public List<TEntity> ConvertToList(DataTable dt)
        {
            // 定义集合  
            List<TEntity> ts = new List<TEntity>();

            // 获得此模型的类型  
            Type type = typeof(TEntity);
            //定义一个临时变量  
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行  
            foreach (DataRow dr in dt.Rows)
            {
                TEntity t = new TEntity();
                // 获得此模型的公共属性  
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性  
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量  
                    //检查DataTable是否包含此列（列名==对象的属性名）    
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter  
                        if (!pi.CanWrite) continue;//该属性不可写，直接跳出  
                        //取值  
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性  
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                //对象添加到泛型集合中  
                ts.Add(t);
            }
            return ts;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool withDetails = true)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, bool withDetails = true)
        {
            return await _sqlSugarClient.Queryable<TEntity>().CountAsync(expression);
        }
    }
}