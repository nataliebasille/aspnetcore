namespace Basille.AspNetCore.ExceptionHandling;

public interface IErrorIdGenerator
{
	string NextID();
}