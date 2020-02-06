using System;
using System.Collections.Generic;
using System.Text;
using DbLayer.Framework.Tables;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Framework.Configuration
{
    public class ForiegnKeys : IModelCreation
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User Information Joining

            modelBuilder.Entity<User_Information>().HasOne(p => p.SA_LicenseInformation).WithMany(b => b.user_Information).HasForeignKey(p => p.License_id);
        }
    }
}
