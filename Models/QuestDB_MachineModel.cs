using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class QuestDB_MachineModel
    {
        public string Datetime { get; set; }
        public DateTime PeriodStart { get; set; }
        public string Name { get; set; }
        public double Flow { get; set; }
        public double FlowSetpoint { get; set; }
        public double Pressure { get; set; }
        public double PressureSetPoint { get; set; }
        public double OverloadValue { get; set; }
        public double OperationStatus { get; set; }
        public double OperationType { get; set; }
        public double OperationMode { get; set; }
    }
}