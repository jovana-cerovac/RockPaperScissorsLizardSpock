namespace GameAPI.Core.Exceptions;

public class InvalidApiResponseException(string message) : Exception(message);