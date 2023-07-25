namespace Evice.Authentication.Domain.Consts
{
    public static class ErrorMessagesConst
    {
        public const string InternalServerError = "The server encountered an unexpected condition that prevented it from fulfilling the request.";

        public const string DatabaseAddInternalServerError = "An error occurred while adding user to the database.";

        public const string AlreadyExists = "{0} has already been registered.";

        public const string NotExists = "{0} does not exist.";
    }
}