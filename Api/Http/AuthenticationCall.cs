using Microsoft.AspNetCore.Mvc;
using Sms.Core.Domain.Dto.Authentication;
using Sms.Core.Domain.Repository.Authentication;

namespace Sms.Host.Api.Http;

public static class AuthenticationCall
{
	[HttpPost]
	public static async Task<IResult> IsLoginValid([FromBody] Logins user, IAuthenticationRepository authenticationRepository)
	{
		try
		{
			return Results.Ok(await authenticationRepository.IsValidUser(user));
		}
		catch (Exception ex)
		{
			return Results.Problem(ex.Message);
		}
	}
}
