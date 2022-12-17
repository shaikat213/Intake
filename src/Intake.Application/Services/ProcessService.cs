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
    public class ProcessService : IntakeAppService, IProcessService
    {
        private readonly IRepository<Process> _processRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Machine> _machineRepository;
        private readonly IRepository<Sensor> _sensorRepository;

        public ProcessService(IRepository<Process> processRepository,
                             IRepository<Customer> customerRepository,
                             IRepository<Machine> machineRepository,
                             IRepository<Sensor> sensorRepository,
                                    IUnitOfWorkManager unitOfWorkManager)
        {

            _processRepository = processRepository;
            _customerRepository = customerRepository;
            _machineRepository = machineRepository;
            _sensorRepository = sensorRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<ProcessDto> CreateAsync(ProcessDto input)
        {

            var newEntity = ObjectMapper.Map<ProcessDto, Process>(input);

            var testEntity = await _processRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<Process, ProcessDto>(testEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _processRepository.DeleteAsync(x => x.Id == id);
        }

        public async Task<ProcessDto> GetAsync(int id)
        {
            var testEntities = await _processRepository.GetListAsync();
            var testEntity = testEntities.FirstOrDefault(i => i.Id == id);
            return ObjectMapper.Map<Process, ProcessDto>(testEntity);
        }

        //public static IQueryable<Process> IncludeDetails(this IQueryable<Process> queryable, bool include = true)
        //{
        //    if (!include)
        //    {
        //        return queryable;
        //    }

        //    return queryable.Include(x => x.Customer);
        //}
        public async Task<List<ProcessDto>> GetListAsync()
        {
            List<ProcessDto> list = null;
            var items = await _processRepository.WithDetailsAsync(p => p.Sensor);
            if (items.Any())
            {
                list = new List<ProcessDto>();
                foreach (var item in items)
                {
                    var customer = await _customerRepository.FirstOrDefaultAsync(c => c.Id == item.CustomerId);
                    var machine = await _machineRepository.FirstOrDefaultAsync(c => c.Id == item.MachineId);
                    list.Add(new ProcessDto()
                    {
                        Id = item.Id,
                        CustomerId = item.CustomerId,
                        CustomerName = customer != null ? customer.CustomerName : "",
                        MachineId = item.MachineId,
                        MachineNr = machine != null ? machine.MachineNr : "",
                        MachineTypeSerial = machine != null ? machine.MachineTypeSerial : "",
                        SensorId = item.SensorId,
                        SensorData = "Water Temp: celcius : " + item.Sensor?.WaterTemp +
                                    "; Pump10 : " + (item.Sensor?.Pump10 == 1 ? "On" : "Off") +
                                    "; Pump5 : " + (item.Sensor?.Pump5 == 1 ? "On" : "Off") +
                                    "; Dra in Sensor : " + (item.Sensor?.DraInSensor == 1 ? "On" : "Off") +
                                    "; Water Level: ml- : " + item.Sensor?.WaterLevel,
                        ProcessName = item.ProcessName,
                        ProcessTime = "Start : " + item.StartDate.ToString() +
                                      "; End : " + item.EndDate.ToString(),
                        OnlineFrom = item.OnlineFrom//.ToString()
                    }); ;
                }
            }

            return list;
        }

        public async Task<ProcessDto> UpdateAsync(ProcessDto input)
        {
            var updateEntity = ObjectMapper.Map<ProcessDto, Process>(input);

            var process = await _processRepository.UpdateAsync(updateEntity);

            return ObjectMapper.Map<Process, ProcessDto>(process);
        }
    }
}
