using System;
using System.Collections.Generic;
using System.Text;

namespace BUSINESSLOGIC.Models
{
    public class AppSettings
    {
        public ConnectionDetail HospitalDatabase { get; set; }

        public TokenConfiguration TokenConfiguration { get; set; }
    }

    public class TokenConfiguration
    {
        public string Audience { get; set; }

        public string Issuer { get; set; }

        public TimeSpan Seconds { get; set; }
    }

    public class ConnectionDetail
    {
        public string ConnectionString { get; set; }

        public bool AuditEnabled { get; set; }
    }
}
