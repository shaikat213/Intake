using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Intake.Models
{
    public class Machine : Entity<int>
    {
        public string MachineNr { get; set; }
        public string MachineTypeSerial { get; set; }
    }
}
