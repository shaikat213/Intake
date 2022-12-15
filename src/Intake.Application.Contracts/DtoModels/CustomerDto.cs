using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Intake.DtoModels
{
    public class CustomerDto : EntityDto<int>
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
    }
}
