using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Intake.DtoModels
{
    public class MachineDto : EntityDto<int>
    {
        public string MachineNr { get; set; }
        public string MachineTypeSerial { get; set; }
    }
}
