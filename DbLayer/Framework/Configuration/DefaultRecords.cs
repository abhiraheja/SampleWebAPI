using System;
using System.Collections.Generic;
using System.Text;
using DbLayer.Framework.Tables;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Framework.Configuration
{
    public class DefaultRecords : IModelCreation
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SA_Login>().HasData(

             new SA_Login { Id = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Is_deleted = false, Username = "admin", Password = "admin" }
             );
        }
    }
}
