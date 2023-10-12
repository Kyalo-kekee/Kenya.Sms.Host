using Microsoft.AspNetCore.Mvc;
using Sms.Core.Domain.Repository.StudentInformation;
using Sms.Reporting.Application.StudentCenter;
using System.Net;
using Sms.Core.Domain.Repository.InstitutionSetup;

namespace Sms.Host.Api.Http.StudentCenter;

public static class DocumentPdfGetStudentsList
{

	public static async Task HandleGetStudentListAsync(HttpContext context,
		[FromServices] IStudentRepository studentRepository,
		[FromServices]ISchoolInformationRepository schoolInformationRepository)
	{
		var students = await studentRepository.GetStudents();


		var pdfRenderer =  new AppGetAllStudentsReport(students,schoolInformationRepository);
		byte[] bytes = pdfRenderer.Render(); 

		context.Response.ContentType = "application/pdf";
		context.Response.StatusCode = (int)HttpStatusCode.OK;
		await context.Response.Body.WriteAsync(bytes);
	}

	public static async Task HandleGetStudentListByClassRoomIdAsync(HttpContext context,
		[FromServices]IStudentRepository studentRepository,
		[FromServices]ISchoolInformationRepository schoolInformationRepository,
		[FromRoute] string id)
	{
		var students = await studentRepository.GetStudentsByClassRoomId(id);

		var pdfRenderer = new AppGetAllStudentsReport(students,schoolInformationRepository);
		byte[] bytes = pdfRenderer.Render();

		context.Response.ContentType = "application/pdf";
		context.Response.StatusCode = (int)HttpStatusCode.OK;
		await context.Response.Body.WriteAsync(bytes);
	}
}
