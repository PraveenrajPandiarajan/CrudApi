using EmployeeCore.Core.IRepository;
using EmployeeCore.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using static EmployeeRepository.EmployeeRepository;
using static EmployeeService.Service.EmployeeService;

namespace EmployeeUtility
{
    public class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //for accessing the http context by interface in view level
            #region Http context
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
            //for service accesssing
            #region Service

            services.AddScoped<IService, StudentServices>();
            #endregion
            //for database accessing 
            #region Repository

            services.AddScoped<IRepository, StudentRepository>();

            #endregion


        }
    }
}