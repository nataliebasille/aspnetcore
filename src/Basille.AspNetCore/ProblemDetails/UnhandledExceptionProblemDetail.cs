namespace Basille.AspNetCore.ProblemDetails;

using System;

public record UnhandledExceptionProblemDetail : ProblemDetail
{
	public UnhandledExceptionProblemDetail()
		: base(500)
	{
		Title = "Unhandled Error";
		Detail = $"Oops, an unexpected error occurred{Environment.NewLine}Please contact the administrator";
	}

	public string ReferenceID { get; init; }

	public string Instance { get; init; }

	public string Message { get; init; }

	public string Raw { get; init; }

	public StackFrame[] StackFrames { get; init; }

	public class StackFrame
	{
		public int LineNumber { get; set; }
		public string Filename { get; set; }
		public string Method { get; set; }
	}
}