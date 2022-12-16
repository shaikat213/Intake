using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Intake.InputDtos
{
    public class SensorInputDto : EntityDto<int>
    {
        public string MachineSensor { get; set; }
        public string WaterTemp { get; set; }
        public int Pump10 { get; set; }
        public int Pump5 { get; set; }
        public int DraInSensor { get; set; }
        public string WaterLevel { get; set; }
    }
}
