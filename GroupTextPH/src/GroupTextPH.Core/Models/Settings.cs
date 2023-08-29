using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GroupTextPH.Core.Models
{
    public class Settings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int SendDelay { get; set; }
        public string Signature { get; set; }
    }
}
