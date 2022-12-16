using AutoMapper;
using Intake.DtoModels;
using Intake.InputDtos;
using Intake.Models;

namespace Intake;

public class IntakeApplicationAutoMapperProfile : Profile
{
    public IntakeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
        CreateMap<CustomerInputDto, Customer>();

        CreateMap<Machine, MachineDto>();
        CreateMap<MachineDto, Machine>();
        CreateMap<MachineInputDto, Machine>();

        CreateMap<Sensor, SensorDto>();
        CreateMap<SensorDto, Sensor>();
        CreateMap<SensorInputDto, Sensor>();

        CreateMap<Process, ProcessDto>();
        CreateMap<ProcessDto, Process>();
    }
}
