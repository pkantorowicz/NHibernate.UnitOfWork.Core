using System;

namespace NHibernate.UnitOfWork.Core.Exceptions
{
    public class NHibernateException : Exception
    {
        protected NHibernateException(string message, ErrorCode code) : base(message)
        {
            Code = code;
        }

        protected NHibernateException(string message, Exception innerException, ErrorCode code) : base(message, innerException)
        {
            Code = code;
        }

        public ErrorCode Code { get; }
    }
}
