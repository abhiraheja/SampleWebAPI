using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLayer.Framework.Configuration
{
    public interface IModelCreation
    {
        void OnModelCreating(ModelBuilder modelBuilder);
    }
}
