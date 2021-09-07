namespace Basille.AspNetCore.ProblemDetails;

using Microsoft.AspNetCore.WebUtilities;

public record StatusCodeProblemDetail : ProblemDetail
{
	public StatusCodeProblemDetail(int status, string reason)
		: base(status)
	{
		Title = ReasonPhrases.GetReasonPhrase(status);
		Detail = reason ?? Title;
	}
}