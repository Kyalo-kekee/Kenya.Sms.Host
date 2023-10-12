using Microsoft.AspNetCore.Mvc;
using Sms.Core.Domain.Repository.StaffManagement;
using Sms.Reporting.Application.StaffManagement;
using System.Net;
using Sms.Core.Domain.Repository.InstitutionSetup;
using Sms.Host.Filters;

namespace Sms.Host.Api.Http.StaffManagement;

public static class DocumentPdfRptTeachersList
{
	public static async Task HandleGetEmployeeAsTeacherUsingRoleIdAsyn(HttpContext context, 
		[FromServices] ITeachersRepository teacherRepository, 
		[FromServices]ISchoolInformationRepository schoolInformationRepository,
		[FromRoute] string roleId)
	{
		var teachers = await teacherRepository.GetEmployeesAsTeachers(roleId);

		var document = new RptTeachersListReport(teachers,schoolInformationRepository);
		byte[] bytes = document.Render();


		context.Response.ContentType = "application/pdf";
		context.Response.StatusCode = (int)HttpStatusCode.OK;
		await context.Response.Body.WriteAsync(bytes);
	}

	public static async Task  HandleGetTeachersAttendanceReportAsync(
        HttpContext context,
        [FromServices] ITeachersAttendanceRepository teachersAttendanceRepository,
		[FromServices]ISchoolInformationRepository schoolInformation,
		[FromQuery]string? filter,
        [FromQuery] string? startDate,
        [FromQuery] string? endDate

        )
	{

        if (string.IsNullOrEmpty(startDate) | startDate == "")
		{
			startDate = null;
		}

        if (string.IsNullOrEmpty(endDate) | startDate == "")
		{
			endDate = null;
		}

		if (string.IsNullOrEmpty(filter) | startDate == "")
		{
			filter = null;
		}

		var attendanceList = await teachersAttendanceRepository.GetAttendance(startDate, endDate, filter);

		var document = new RptTeachersAttendanceReport(attendanceList, schoolInformation);
        byte[] bytes = document.Render(new AttendanceFilter() { startDate = startDate, endDate = endDate, filter = filter });

        context.Response.ContentType = "application/pdf";
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        await context.Response.Body.WriteAsync(bytes);
    }
}
