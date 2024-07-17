using AutoMapper;
using PrimeEngineeringApi.Data;
using PrimeEngineeringApi.Data.Dtos;
using PrimeEngineeringApi.Handlers.Employees.CreateTask;

namespace PrimeEngineeringApi.Utilities
{
    public class MappingProlife : Profile
    {
        public MappingProlife()
        {
            CreateMap<CreateTaskQuery, EmployeeTask>();
            CreateMap<EmployeeTask, EmployeeTaskDto>()
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.ToString()));
        }
    }
}
