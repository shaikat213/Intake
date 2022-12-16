using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Intake.DtoModels
{
    public class ProcessDto : EntityDto<int>
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int MachineId { get; set; }
        public string MachineNr { get; set; }
        public string MachineTypeSerial { get; set; }
        public int SensorId { get; set; }
        public string SensorData { get; set; }
        public string ProcessName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProcessTime { get; set; }
        public DateTime OnlineFrom { get; set; }
    }
}
