using Sms.Host.Api.Http.StudentCenter;

namespace Sms.Host;

public static class ApiStudentCenter
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/reporting/student-center-StudentList/All", DocumentPdfGetStudentsList.HandleGetStudentListAsync);
        app.MapGet("/reporting/student-center/StudentList/with/{id}", DocumentPdfGetStudentsList.HandleGetStudentListByClassRoomIdAsync);
    }
}