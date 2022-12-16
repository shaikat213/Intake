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
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;

namespace Intake.Services
{
    public class SensorService : IntakeAppService, ISensorService
    {
        private readonly IRepository<Sensor> _sensorRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        
        public SensorService(IRepository<Sensor> sensorRepository,
                                    IUnitOfWorkManager unitOfWorkManager)
        {
            _sensorRepository = sensorRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<SensorDto> CreateAsync(SensorInputDto input)
        {

            var newEntity = ObjectMapper.Map<SensorInputDto, Sensor>(input);

            var testEntity = await _sensorRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<Sensor, SensorDto>(testEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _sensorRepository.DeleteAsync(x => x.Id == id);
        }

        public async Task<SensorDto> GetAsync(int id)
        {
            var testEntities = await _sensorRepository.GetListAsync();
            var testEntity = testEntities.FirstOrDefault(i => i.Id == id);
            return ObjectMapper.Map<Sensor, SensorDto>(testEntity);
        }

        public async Task<List<SensorDto>> GetListAsync()
        {
            //List<SensorDto> result = null;
            //var sensors = await _sensorRepository.GetListAsync();
            //return ObjectMapper.Map<List<Sensor>, List<SensorDto>>(sensors);
            List<SensorDto> list = null;
            var items = await _sensorRepository.GetListAsync();
            if (items.Any())
            {
                list = new List<SensorDto>();
                foreach (var item in items)
                {
                    list.Add(new SensorDto()
                    {
                        Id = item.Id,
                        MachineSensor = item.MachineSensor,
                        WaterTemp = item.WaterTemp,
                        Pump10 = item.Pump10,
                        Pump10Name = item.Pump10 == 1 ? "On" : "Off",
                        Pump5 = item.Pump5,
                        Pump5Name = item.Pump5 == 1 ? "On" : "Off",
                        DraInSensor = item.DraInSensor,
                        DraInSensorName = item.DraInSensor == 1 ? "On" : "Off",
                        WaterLevel = item.WaterLevel
                    }); 
                }
            }

            return list;
        }

        public async Task<SensorDto> UpdateAsync(SensorInputDto input)
        {
            var updateEntity = ObjectMapper.Map<SensorInputDto, Sensor>(input);

            var sensor = await _sensorRepository.UpdateAsync(updateEntity);

            return ObjectMapper.Map<Sensor, SensorDto>(sensor);
        }
    }
}
