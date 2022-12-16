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
    public class MachineAppService : IntakeAppService, IMachineAppService
    {
        private readonly IRepository<Machine> _machineRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public MachineAppService(IRepository<Machine> machineRepository,
                                    IUnitOfWorkManager unitOfWorkManager)
        {
            _machineRepository = machineRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<MachineDto> CreateAsync(MachineInputDto input)
        {

            var newEntity = ObjectMapper.Map<MachineInputDto, Machine>(input);

            var testEntity = await _machineRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<Machine, MachineDto>(testEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _machineRepository.DeleteAsync(x => x.Id == id);
        }

        public async Task<MachineDto> GetAsync(int id)
        {
            var testEntities = await _machineRepository.GetListAsync();
            var testEntity = testEntities.FirstOrDefault(i => i.Id == id);
            return ObjectMapper.Map<Machine, MachineDto>(testEntity);
        }

        public async Task<List<MachineDto>> GetListAsync()
        {
            var machines = await _machineRepository.GetListAsync();
            return ObjectMapper.Map<List<Machine>, List<MachineDto>>(machines);
        }

        public async Task<MachineDto> UpdateAsync(MachineInputDto input)
        {
            var updateEntity = ObjectMapper.Map<MachineInputDto, Machine>(input);

            var machine = await _machineRepository.UpdateAsync(updateEntity);

            return ObjectMapper.Map<Machine, MachineDto>(machine);
        }
    }
}
