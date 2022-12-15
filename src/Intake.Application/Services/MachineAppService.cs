using Intake.DtoModels;
using Intake.InputDtos;
using Intake.Interfaces;
using Intake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace Intake.Services
{
    public class MachineAppService : ApplicationService, IMachineAppService
    {
        private readonly IRepository<Machine, int> _customerRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        
        public MachineAppService(IRepository<Machine, int> customerRepository,
                                    IUnitOfWorkManager unitOfWorkManager)
        {
            _customerRepository = customerRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<MachineDto> CreateAsync(MachineInputDto input)
        {
            var newEntity = ObjectMapper.Map<MachineInputDto, Machine>(input);

            var testEntity = await _customerRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<Machine, MachineDto>(testEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<MachineDto> GetAsync(int id)
        {
            var testEntities = await _customerRepository.GetListAsync();
            var testEntity = testEntities.FirstOrDefault(i => i.Id == id);
            return ObjectMapper.Map<Machine, MachineDto>(testEntity);
        }

        public async Task<List<MachineDto>> GetListAsync()
        {
            var tests = await _customerRepository.GetListAsync();
            return ObjectMapper.Map<List<Machine>, List<MachineDto>>(tests);
        }

        public async Task<MachineDto> UpdateAsync(MachineInputDto input)
        {
            var updateEntity = ObjectMapper.Map<MachineInputDto, Machine>(input);

            var testEntity = await _customerRepository.UpdateAsync(updateEntity);

            return ObjectMapper.Map<Machine, MachineDto>(testEntity);
        }
    }
}
