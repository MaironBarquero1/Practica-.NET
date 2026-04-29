using System;

namespace StoreBackend.Exceptions;

public class BadRequestResponseException : Exception
{
    public BadRequestResponseException() : base("Invalid request") { }
    public BadRequestResponseException(String message) : base(message){}
}
