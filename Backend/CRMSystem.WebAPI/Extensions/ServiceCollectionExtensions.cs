using CRMSystem.WebAPI.Auth;
using CRMSystem.WebAPI.Interfaces;
using CRMSystem.WebAPI.Mappers;
using CRMSystem.WebAPI.Models;
using CRMSystem.WebAPI.Repositories;
using CRMSystem.WebAPI.Services;

namespace CRMSystem.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registration Repositories
            services.AddScoped<IBasicRepository<Contact>, ContactRepository>();
            services.AddScoped<IBasicRepository<Contract>, ContractRepository>();
            services.AddScoped<IBasicRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IGroupLessonDayRepository, GroupLessonDayRepository>();
            services.AddScoped<IBasicRepository<Group>, GroupRepository>();
            services.AddScoped<IBasicRepository<Language>, LanguageRepository>();
            services.AddScoped<IBasicRepository<LessonDay>, LessonDayRepository>();
            services.AddScoped<IBasicRepository<Person>, PersonRepository>();
            services.AddScoped<IBasicRepository<StudentGroup>, StudentGroupRepository>();
            services.AddScoped<IBasicRepository<Student>, StudentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            // Registration Services
            services.AddScoped<ContactService>();
            services.AddScoped<ContractService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<GroupLessonDayService>();
            services.AddScoped<GroupService>();
            services.AddScoped<LanguageService>();
            services.AddScoped<LessonDayService>();
            services.AddScoped<PersonService>();
            services.AddScoped<StudentGroupService>();
            services.AddScoped<StudentService>();
            services.AddScoped<UserService>();
            
            services.AddScoped<StudentRegistrationService>();
            
            // AutoMapper Profiles
            services.AddAutoMapper(typeof(ContactProfile).Assembly);
            services.AddAutoMapper(typeof(ContractProfile).Assembly);
            services.AddAutoMapper(typeof(EmployeeProfile).Assembly);
            services.AddAutoMapper(typeof(GroupLessonDayProfile).Assembly);
            services.AddAutoMapper(typeof(GroupProfile).Assembly);
            services.AddAutoMapper(typeof(LanguageProfile).Assembly);
            services.AddAutoMapper(typeof(LessonDayProfile).Assembly);
            services.AddAutoMapper(typeof(PersonProfile).Assembly);
            services.AddAutoMapper(typeof(StudentGroupProfile).Assembly);
            services.AddAutoMapper(typeof(StudentProfile).Assembly);
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            
            return services;
        }
        
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Authentication Services
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            services.AddApiAuthentication(configuration);

            return services;
        }
    }
}