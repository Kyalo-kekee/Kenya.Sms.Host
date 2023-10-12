using Sms.Host.Api.Http.FeeManagement;

namespace Sms.Host;

public static class ApiFeeManagement
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/reporting/student/fee-statement/{PaymentId}",
            DocumentPdfRptStudentFeeStatement.HandleGetStudentPaymentDetailsByPaymentIdAsync).WithName("FeeManagement");
    }
}