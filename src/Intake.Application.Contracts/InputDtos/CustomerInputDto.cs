using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Intake.InputDtos
{
    public class CustomerInputDto : EntityDto<int>
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
    }
}
