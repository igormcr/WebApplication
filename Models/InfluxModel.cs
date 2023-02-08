using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfluxDB.Client.Core;
using WebApplication2.Models;

namespace LocaWebAPI.Models
{
    [Measurement("Machine")]
    public class InfluxModel
    {
        public class DataHistoryEntry
        {

            public string _measurement { get; set; }
            [Column("tempBHighAlarm")]
            public string _measurement_id { get; set; }
            [Column("tempBHighAlarm")]
            public DateTime DateTime { get; set; }
            [Column("tempBHighAlarm")]
            public object _fields { get; set; }
            [Column("tempBHighAlarm")]
            public object values { get; set; }


        }

    }
}