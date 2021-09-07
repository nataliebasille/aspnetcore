namespace Basille.AspNetCore.ProblemDetails;

using Newtonsoft.Json;
using System.Collections.Generic;

public record ProblemDetail(int Status)
{
	public string Type { get; protected set; } = $"https://httpstatuses.com/{Status}";

	public string Title { get; init; }

	public string Detail { get; init; }

	[JsonExtensionData]
	public Dictionary<string, object> Extensions { get; init; }
}