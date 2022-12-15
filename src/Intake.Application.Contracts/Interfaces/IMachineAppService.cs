using Intake.DtoModels;
using Intake.InputDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intake.Interfaces
{
    public interface IMachineAppService
    {
        Task<MachineDto> GetAsync(int id);
        Task<List<MachineDto>> GetListAsync();
        Task<MachineDto> CreateAsync(MachineInputDto input);
        Task<MachineDto> UpdateAsync(MachineInputDto input);
        Task DeleteAsync(int id);
    }
}
