using System;

namespace Application.Common.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException(string entityName, object key, string message)
            : base($"Deletion of entity \"{entityName}\" ({key}) failed. {message}")
        {
        }
    }
}
