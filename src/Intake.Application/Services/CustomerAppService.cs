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
    public class CustomerAppService : IntakeAppService, ICustomerAppService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        
        public CustomerAppService(IRepository<Customer> customerRepository,
                                    IUnitOfWorkManager unitOfWorkManager)
        {
            _customerRepository = customerRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<CustomerDto> CreateAsync(CustomerInputDto input)
        {

            var newEntity = ObjectMapper.Map<CustomerInputDto, Customer>(input);

            var testEntity = await _customerRepository.InsertAsync(newEntity);

            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<Customer, CustomerDto>(testEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _customerRepository.DeleteAsync(x => x.Id == id);
        }

        public async Task<CustomerDto> GetAsync(int id)
        {
            var testEntities = await _customerRepository.GetListAsync();
            var testEntity = testEntities.FirstOrDefault(i => i.Id == id);
            return ObjectMapper.Map<Customer, CustomerDto>(testEntity);
        }

        public async Task<List<CustomerDto>> GetListAsync()
        {
            var customers = await _customerRepository.GetListAsync();
            return ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> UpdateAsync(CustomerInputDto input)
        {
            var updateEntity = ObjectMapper.Map<CustomerInputDto, Customer>(input);

            var customer = await _customerRepository.UpdateAsync(updateEntity);

            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }
    }
}
