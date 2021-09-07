namespace Basille.AspNetCore.ExceptionHandling;

using System;

public class DefaultErrorIdGenerator : IErrorIdGenerator
{
	public string NextID() => DateTime.Now.ToString("yyyy.MM.dd-hh.mm.ss.fff");
}