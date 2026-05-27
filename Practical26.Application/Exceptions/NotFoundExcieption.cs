namespace Practical26.Application.Exceptions
{
    public sealed class NotFoundException(string message) : Exception(message)
    {
    }
}
