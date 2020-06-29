using System;
using System.Collections.Generic;
using System.Text;

namespace BUSINESSLOGIC.Models
{
    public class AppSettings
    {
        public ConnectionDetail HospitalDatabase { get; set; }        
    }

    public class ConnectionDetail
    {
        public string ConnectionString { get; set; }

        public bool AuditEnabled { get; set; }
    }
}
