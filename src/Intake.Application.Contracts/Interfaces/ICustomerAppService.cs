using Intake.DtoModels;
using Intake.InputDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Intake.Interfaces
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<CustomerDto> GetAsync(int id);
        Task<List<CustomerDto>> GetListAsync();
        Task<CustomerDto> CreateAsync(CustomerInputDto input);
        Task<CustomerDto> UpdateAsync(CustomerInputDto input);
        Task DeleteAsync(int id);
    }
}
