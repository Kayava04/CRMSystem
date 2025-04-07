using AutoMapper;
using CRMSystem.WebAPI.Interfaces;
using CRMSystem.WebAPI.Models;
using CRMSystem.WebAPI.DTOs.School.Contacts;
using CRMSystem.WebAPI.DTOs.School.Contracts;
using CRMSystem.WebAPI.DTOs.School.Groups;
using CRMSystem.WebAPI.DTOs.School.Languages;
using CRMSystem.WebAPI.DTOs.School.LessonDays;
using CRMSystem.WebAPI.DTOs.School.Persons;
using CRMSystem.WebAPI.DTOs.School.StudentGroups;
using CRMSystem.WebAPI.DTOs.School.Students;

namespace CRMSystem.WebAPI.Services
{
    public class StudentRegistrationService(
        IMapper mapper,
        IBasicRepository<Person> personRepository,
        IBasicRepository<Student> studentRepository,
        IBasicRepository<Contract> contractRepository,
        IBasicRepository<Contact> contactRepository,
        IBasicRepository<StudentGroup> studentGroupRepository,
        IBasicRepository<Group> groupRepository,
        IBasicRepository<Language> languageRepository,
        IBasicRepository<LessonDay> lessonDayRepository,
        IGroupLessonDayRepository groupLessonDayRepository)
    {
        public async Task<RegisterStudentResultDto> CreateStudentAsync(RegisterStudentDto dto)
        {
            var language = Language.Create(Guid.NewGuid(), dto.LanguageName);
            var createdLanguage = await languageRepository.AddAsync(language);
            
            var group = Group.Create(Guid.NewGuid(), dto.GroupName, createdLanguage.Id);
            var createdGroup = await groupRepository.AddAsync(group);
            
            var lessonDays = new List<LessonDayDto>();
            
            foreach (var dayOfWeek in dto.LessonDays)
            {
                var lessonDay = LessonDay.Create(Guid.NewGuid(), dayOfWeek);
                var createdLessonDay = await lessonDayRepository.AddAsync(lessonDay);

                var groupLessonDay = GroupLessonDay.Create(createdGroup.Id, createdLessonDay.Id);
                await groupLessonDayRepository.AddAsync(groupLessonDay);
                
                lessonDays.Add(mapper.Map<LessonDayDto>(createdLessonDay));
            }

            Person? createdParent;
            Person createdPerson;
            
            if (dto.IsParentRegister)
            {
                var parent = Person.Create(Guid.NewGuid(), dto.ParentFullName, DateTime.MinValue);
                createdParent = await personRepository.AddAsync(parent);

                var person = Person.Create(Guid.NewGuid(), dto.FullName, dto.BirthDate);
                createdPerson = await personRepository.AddAsync(person);
            }
            else
            {
                var person = Person.Create(Guid.NewGuid(), dto.FullName, dto.BirthDate);
                createdPerson = await personRepository.AddAsync(person);
                createdParent = null;
            }
            
            var parentId = createdParent?.Id;
            var grade = dto?.Grade.HasValue == true && dto.Grade > 0 ? dto.Grade : null;
            
            var student = Student.Create(Guid.NewGuid(), createdPerson.Id, parentId, grade);
            var createdStudent = await studentRepository.AddAsync(student);
            
            var contract = Contract.Create(Guid.NewGuid(), dto.ContractNumber, dto.SignDate, dto.PaymentAmount, createdStudent.Id);
            var createdContract = await contractRepository.AddAsync(contract);
            
            var contact = Contact.Create(Guid.NewGuid(), createdPerson.Id, dto.Phone, dto.Email);
            var createdContact = await contactRepository.AddAsync(contact);
            
            var studentGroup = StudentGroup.Create(Guid.NewGuid(), createdStudent.Id, createdGroup.Id, dto.Level, dto.PairNumber);
            var createdStudentGroup = await studentGroupRepository.AddAsync(studentGroup);

            return new RegisterStudentResultDto
            {
                Parent = mapper.Map<PersonDto>(createdParent),
                Person = mapper.Map<PersonDto>(createdPerson),
                Student = mapper.Map<StudentDto>(createdStudent),
                Contract = mapper.Map<ContractDto>(createdContract),
                Contact = mapper.Map<ContactDto>(createdContact),
                StudentGroup = mapper.Map<StudentGroupDto>(createdStudentGroup),
                Group = mapper.Map<GroupDto>(createdGroup),
                Language = mapper.Map<LanguageDto>(createdLanguage),
                LessonDays = lessonDays
            };
        }
    }
}