using Intake.DtoModels;
using Intake.InputDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Intake.Interfaces
{
    public interface ISensorService : IApplicationService
    {
        Task<SensorDto> GetAsync(int id);
        Task<List<SensorDto>> GetListAsync();
        Task<SensorDto> CreateAsync(SensorInputDto input);
        Task<SensorDto> UpdateAsync(SensorInputDto input);
        Task DeleteAsync(int id);
    }
}
