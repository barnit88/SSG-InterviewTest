namespace SSG.Application.Common.Exceptions
{
    public class ApplicationValidationException : Exception
    {

        public ApplicationValidationException()
               : base("One or more validation failures have occurred.")
        {
            Errors = new List<string>();
        }

        public ApplicationValidationException(List<string> failures)
            : this()
        {
            ErrorMessage = failures[0];
            Errors = failures;
        }

        public string ErrorMessage { get; }
        public List<string> Errors { get; }
    }
}