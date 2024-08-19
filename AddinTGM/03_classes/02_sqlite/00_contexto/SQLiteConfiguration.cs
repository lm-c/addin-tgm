﻿using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Data.SQLite.EF6;

namespace AddinTGM {
  internal class SQLiteConfiguration : DbConfiguration {
    public SQLiteConfiguration() {
      SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
      SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
      SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
      // SetDefaultConnectionFactory(new SQLiteConnectionFactory());
      SetDefaultConnectionFactory(new SqlCeConnectionFactory("System.Data.SQLite.EF6"));
    }
  }
}
