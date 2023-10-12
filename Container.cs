

using DataAccessLayer.DbAccess;
using Sms.Core.Domain.Repository.FeeManagement;
using Sms.Core.Domain.Repository.InstitutionSetup;
using Sms.Core.Domain.Repository.StaffManagement;
using Sms.Core.Domain.Repository.StudentInformation;
using Sms.Reporting;
using Sms.Reporting.Utilities;

namespace Sms.Host;
public static class Container
{

	public static void ConfigureServices(IServiceCollection services)
	{

		//REPORTING CLASS LIBRARY POPULATE SETTINGS
		/*services.Configure<ReportingAppSettings>(configuration.GetSection("AppSettings"));
		services.AddOptions();*/
		//services.AddMvc();
		//services.AddControllersWithViews();

		services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
		services.AddSingleton<IStudentRepository, StudentRepository>();
		services.AddSingleton<IRptStudentPaymentDetailsRepository, RptStudentPaymentDetailsRepository>();
		services.AddSingleton<ITeachersRepository, TeachersRepository>();
		services.AddSingleton<ISchoolInformationRepository, SchoolInformationRepository>();
		services.AddSingleton<ITeachersAttendanceRepository,TeachersAttendanceRepository>();

		//Sms.Core.Services.Configure(services);

	}

}
