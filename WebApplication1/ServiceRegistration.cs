using WebApplication1.Services;

namespace WebApplication1
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ISessionsRepository, SessionsRepositor>();
            services.AddTransient<ILecturerRepository, LectureRepository>();
            services.AddTransient<IEnrolmentRepository, EnrolmentRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IAttendanceRepository, AttendanceRepository>();
        }
    }
}
