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
            CreateMap<StudentEntity, Student>()
                .ConstructUsing(e => Student.Create(e.Id, e.PersonId, e.ParentId, e.Grade));
            
            CreateMap<Student, StudentEntity>();
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentDto, Student>();
        }
    }
}