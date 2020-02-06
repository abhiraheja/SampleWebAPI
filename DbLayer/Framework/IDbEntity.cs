using System.Collections.Generic;
using System.Threading.Tasks;
using DbLayer.Framework.Tables;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Framework
{
    public interface IDbEntity
    {
        DbSet<SA_LicenseInformation> sA_LicenseInformation { get; set; }
        DbSet<SA_Login> sA_Logins { get; set; }
        DbSet<User_Information> user_Information { get; set; }

        void dbMigrate();
        Task<int> DeleteAsync<T>(IEnumerable<T> models);
        Task<int> DeleteAsync<T>(T model);
        Task<int> SaveAsync<T>(IEnumerable<T> models);
        Task<int> SaveAsync<T>(T model);
        Task<int> UpdateAsync<T>(IEnumerable<T> models);
        Task<int> UpdateAsync<T>(T model);
    }
}