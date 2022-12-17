using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Intake.DtoModels
{
    public class SensorDto : EntityDto<int>
    {
        public string MachineSensor { get; set; }
        public string WaterTemp { get; set; }
        public int Pump10 { get; set; }
        public string Pump10Name { get; set; }
        public int Pump5 { get; set; }
        public string Pump5Name { get; set; }
        public int DraInSensor { get; set; }
        public string DraInSensorName { get; set; }
        public string WaterLevel { get; set; }
    }

    public class SensorSearchDto : EntityDto<int>
    {
        public string WaterTemp { get; set; }
        public int? Pump10 { get; set; }
        public int? Pump5 { get; set; }
        public int? DraInSensor { get; set; }
        public string WaterLevel { get; set; }
    }
}
