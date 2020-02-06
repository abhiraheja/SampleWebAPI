using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbLayer.Framework.Tables
{
    [Table("SA_LicenseInformation")]
    public class SA_LicenseInformation : ITable
    {
        public string LicenseNo { get; set; }
        public string MAC_Address { get; set; }
        public string Application_Id { get; set; }
        public DateTime Updated_date { get; set; }
        public bool Is_lock { get; set; }
        public bool Is_used { get; set; }
        public ICollection<User_Information> user_Information { get; set; }
    }
}
