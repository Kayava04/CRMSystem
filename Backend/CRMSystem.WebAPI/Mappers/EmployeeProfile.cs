using AutoMapper;
using CRMSystem.WebAPI.DTOs.School.Employees;
using CRMSystem.WebAPI.Entities.School;
using CRMSystem.WebAPI.Models;

namespace CRMSystem.WebAPI.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // CreateMap<EmployeeEntity, EmployeeDetailsDto>()
            //     .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Person.FullName))
            //     .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Person.BirthDate))
            //     .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Person.Contacts.FirstOrDefault()!.Phone))
            //     .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Person.Contacts.FirstOrDefault()!.Email));
            
            CreateMap<EmployeeEntity, Employee>().ConstructUsing(e =>
                Employee.Create(e.Id, e.PersonId, e.Position));
            CreateMap<Employee, EmployeeEntity>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
        }
    }
}