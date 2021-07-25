using System;

namespace LabsProject.BackEnd.Domain.Exceptions
{
    public class LabsProjectDomainException : Exception
    {
        public LabsProjectDomainException()
        { }

        public LabsProjectDomainException(string message)
            : base(message)
        { }

        public LabsProjectDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
