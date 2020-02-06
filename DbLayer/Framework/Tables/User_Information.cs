using System;
using System.Collections.Generic;
using System.Text;

namespace DbLayer.Framework.Tables
{
    public class User_Information : ITable
    {
        public string Name { get; set; }
        public string Email_id { get; set; }
        public string Mobile_no { get; set; }
        public bool Is_used { get; set; }
        public bool Is_lock { get; set; }
        public int License_id { get; set; }
        public virtual SA_LicenseInformation SA_LicenseInformation { get; set; }
    }
}
