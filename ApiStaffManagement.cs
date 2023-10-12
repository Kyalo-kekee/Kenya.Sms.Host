using Sms.Host.Api.Http.StaffManagement;

namespace Sms.Host;

public static class ApiStaffManagement
{

	public static void ConfigureApi(this WebApplication app)
	{
		app.MapGet("/reporting/staff-managemnt-teachers/list/{RoleId}", DocumentPdfRptTeachersList.HandleGetEmployeeAsTeacherUsingRoleIdAsyn);
		app.MapGet("/reporting/staff-managemnt-teachers/attendance/", DocumentPdfRptTeachersList.HandleGetTeachersAttendanceReportAsync);
	}
}
