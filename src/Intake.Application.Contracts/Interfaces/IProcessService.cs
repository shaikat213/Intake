using Intake.DtoModels;
using Intake.InputDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Intake.Interfaces
{
    public interface IProcessService : IApplicationService
    {
        Task<ProcessDto> GetAsync(int id);
        Task<List<ProcessDto>> GetListAsync();
        Task<ProcessDto> CreateAsync(ProcessDto input);
        //Task<ProcessDto> UpdateAsync(ProcessDto input);
        Task DeleteAsync(int id);
    }
}
