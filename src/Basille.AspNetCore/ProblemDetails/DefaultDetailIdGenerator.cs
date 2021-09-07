namespace Basille.AspNetCore.ProblemDetails;

using System;

public class DefaultDetailIdGenerator : IDetailIdGenerator
{
	public string NextID() => DateTime.Now.ToString("yyyy.MM.dd-hh.mm.ss.fff");
}