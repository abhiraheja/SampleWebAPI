using DbLayer.Framework.Configuration;
using DbLayer.Framework.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Framework
{
    public class DbEntity : DbContext, IDbEntity
    {

        public DbSet<SA_Login> sA_Logins { get; set; }
        public DbSet<SA_LicenseInformation> sA_LicenseInformation { get; set; }
        public DbSet<User_Information> user_Information { get; set; }

        public DbEntity(DbContextOptions<DbEntity> options) : base(options)
        {

        }

        public void dbMigrate()
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var ModelBuilderClasses = typeof(DbEntity).Assembly.ExportedTypes.Where(x => typeof(IModelCreation).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IModelCreation>().ToList();
            ModelBuilderClasses.ForEach(x => x.OnModelCreating(modelBuilder));
        }

        public Task<int> SaveAsync<T>(T model)
        {
            this.Add(model);
            return this.SaveChangesAsync();
        }
        public Task<int> SaveAsync<T>(IEnumerable<T> models)
        {
            this.AddRange(models);
            return this.SaveChangesAsync();
        }
        public Task<int> UpdateAsync<T>(T model)
        {
            this.Add(model);
            this.Entry(model).State = EntityState.Modified;
            return this.SaveChangesAsync();
        }
        public Task<int> UpdateAsync<T>(IEnumerable<T> models)
        {
            foreach (var model in models)
            {
                this.AddRange(model);
                this.Entry(model).State = EntityState.Modified;
            }
            return this.SaveChangesAsync();
        }

        public Task<int> DeleteAsync<T>(T model)
        {
            this.Remove(model);
            return this.SaveChangesAsync();
        }
        public Task<int> DeleteAsync<T>(IEnumerable<T> models)
        {
            this.RemoveRange(models);
            return this.SaveChangesAsync();
        }
    }
}
