using System;
using SqlSugar;

namespace Lemon.App.SqlSugar
{
	public class DbContext
	{
		public DbContext(ISqlSugarClient sqlSugarClient)
		{
			SqlSugarClient = sqlSugarClient;
        }

        public ISqlSugarClient SqlSugarClient { get; set; }

    }
}

