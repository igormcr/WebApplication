using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocaWebAPI.Models
{
    public class InfluxModel
    {
        public class DataHistoryEntry
        {
            public string _measurement { get; set; }
            public string _measurement_id { get; set; }
            public DateTime DateTime { get; set; }
            public object _fields { get; set; }
            public object values { get; set; }

        }

    }
}