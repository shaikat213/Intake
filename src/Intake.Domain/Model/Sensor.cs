using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Intake.Models
{
    public class Sensor : Entity<int>
    {
        public string MachineSensor { get; set; }
        public string WaterTemp { get; set; }
        public int Pump10 { get; set; }
        public int Pump5 { get; set; }
        public int DraInSensor { get; set; }
        public string WaterLevel { get; set; }
    }
}
