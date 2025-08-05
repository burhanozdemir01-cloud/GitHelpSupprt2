namespace ET.Application.Exceptions
{
    public class AuthenticatonErrorException : Exception
    {
        public AuthenticatonErrorException():base("Kimlik doğrulama hatası")
        {
        }

        public AuthenticatonErrorException(string? message) : base(message)
        {
        }

        public AuthenticatonErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
