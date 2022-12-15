using Intake.DtoModels;
using Intake.InputDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intake.Interfaces
{
    public interface ITestEntityAppService
    {
        Task<TestEntityDto> GetAsync(Guid id);
        Task<List<TestEntityDto>> GetListAsync();
        Task<TestEntityDto> CreateAsync(TestEntityInputDto input);
        Task<TestEntityDto> UpdateAsync(TestEntityInputDto input);
        Task DeleteAsync(Guid id);
    }
}
