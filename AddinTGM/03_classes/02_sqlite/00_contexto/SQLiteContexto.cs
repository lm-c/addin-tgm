﻿using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace AddinTGM {
  [DbConfigurationType(typeof(SQLiteConfiguration))]
  internal class SQLiteContexto : DbContext {
    static SQLiteContexto() {
      //// This will register the SQLite provider without requiring app.config changes
      DbConfiguration.SetConfiguration(new SQLiteConfiguration());
    }

    public SQLiteContexto() : base(ConexaoSQLite.GetConexao(), true) {
        //Database.Connection.ConnectionString = ConexaoSQLite.ConnectionString;
      }

    public DbSet<FormatoFolha> FormatoFolha { get; set; }
    public DbSet<Config> Config { get; set; } 
    public DbSet<Material> Material { get; set; }  
    public DbSet<MateriaPrima> MateriaPrima { get; set; } 

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        modelBuilder.Conventions
            .Remove<PluralizingTableNameConvention>();
        base.OnModelCreating(modelBuilder);
      }
    }
}
