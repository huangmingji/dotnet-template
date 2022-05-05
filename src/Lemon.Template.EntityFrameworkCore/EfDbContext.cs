using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lemon.Template.Domain;
using Lemon.Template.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Lemon.Template.EntityFrameworkCore
{
    public class EfDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lemon.Commerce.Data.CommerceContext"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public EfDbContext(DbContextOptions<EfDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// On the model creating.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
            foreach (var entityType in  new List<Type>() {typeof(Entity), typeof(EntityIdentity)})
            {
                var assembly = Assembly.GetAssembly(entityType) ?? throw new NullReferenceException();
                var types  = assembly.DefinedTypes.AsEnumerable().Where(x => x.BaseType != null && (x.BaseType == entityType)).ToList();
                foreach (var type in types)
                {
                    modelBuilder.Entity(type);
                }
            }
        }
    }
}