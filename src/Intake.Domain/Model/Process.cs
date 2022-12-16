using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Intake.Models
{
    public class Process : Entity<int>
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
        public string ProcessName { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public DateTime OnlineFrom { get; set; }
    }
}
