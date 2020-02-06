using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbLayer.Framework.Tables
{
    [Table("SA_Login")]
    public class SA_Login : ITable
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
