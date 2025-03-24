using AutoMapper;
using CRMSystem.WebAPI.DTOs.School.Students;
using CRMSystem.WebAPI.Entities.School;
using CRMSystem.WebAPI.Models;

namespace CRMSystem.WebAPI.Mappers
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            // // Entity → DTO
            // CreateMap<StudentEntity, StudentDetailsDto>()
            //     .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Person.FullName))
            //     .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Person.BirthDate))
            //     .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Person.Contacts.FirstOrDefault() != null ? src.Person.Contacts.First().Phone : string.Empty))
            //     .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Person.Contacts.FirstOrDefault() != null ? src.Person.Contacts.First().Email : string.Empty))
            //     .ForMember(dest => dest.ParentFullName, opt => opt.MapFrom(src => src.Parent != null ? src.Parent.FullName : null))
            //     .ForMember(dest => dest.Grade, opt => opt.MapFrom(src => src.Grade))
            //     .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.StudentGroups))
            //     .ForMember(dest => dest.Contracts, opt => opt.MapFrom(src => src.Contracts));
            //
            // CreateMap<StudentGroupEntity, GroupInfoDto>()
            //     .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group.GroupName))
            //     .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Group.Language.Name))
            //     .ForMember(dest => dest.LessonDays, opt => opt.MapFrom(src => src.Group.GroupLessonDays.Select(x => x.LessonDay.DayOfWeek)));
            //
            // CreateMap<ContractEntity, ContractInfoDto>();

            CreateMap<StudentEntity, Student>()
                .ConstructUsing(e => Student.Create(e.Id, e.PersonId, e.ParentId, e.Grade));
            
            CreateMap<Student, StudentEntity>();
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentDto, Student>();
        }
    }
}