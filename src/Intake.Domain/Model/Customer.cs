using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Intake.Models
{
    public class Customer : Entity<int>
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
    }
}
