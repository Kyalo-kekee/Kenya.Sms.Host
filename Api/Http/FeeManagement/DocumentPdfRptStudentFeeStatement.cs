using System.Net;
using Microsoft.AspNetCore.Mvc;
using Sms.Core.Domain.Repository.FeeManagement;
using Sms.Core.Domain.Repository.InstitutionSetup;
using Sms.Reporting.Application.FeeManagement;

namespace Sms.Host.Api.Http.FeeManagement;

public static class DocumentPdfRptStudentFeeStatement
{
    public static async Task HandleGetStudentPaymentDetailsByPaymentIdAsync(HttpContext context,
        [FromServices] IRptStudentPaymentDetailsRepository rptStudentPaymentDetailsRepository,
        [FromServices]ISchoolInformationRepository schoolInformationRepository,
        [FromRoute] string paymentId)
    {
        var paymentDetails = await rptStudentPaymentDetailsRepository.GetPaymentDetails(paymentId);
        var pdfRenderer = new RptStudentFeeStatementReport(paymentDetails,schoolInformationRepository);
        var bytes = pdfRenderer.Render();
        
        context.Response.ContentType = "application/pdf";
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        await context.Response.Body.WriteAsync(bytes);
    }
}