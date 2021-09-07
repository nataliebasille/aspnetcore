namespace Basille.AspNetCore.ProblemDetails;

public record UnauthorizedProblemDetail : ProblemDetail
{
	public UnauthorizedProblemDetail()
		: base(401)
	{
		Title = "Unauthorized";
		Detail = "Sorry, you don't have the necessary permissions to view this resource";
	}
}