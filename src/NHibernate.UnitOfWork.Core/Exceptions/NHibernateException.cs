using System;

namespace NHibernate.UnitOfWork.Core.Exceptions
{
    public class NHibernateException : Exception
    {
        protected NHibernateException(string message, string code) : base(message)
        {
            Code = code;
        }

        protected NHibernateException(string message, Exception innerException, string code) : base(message, innerException)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
