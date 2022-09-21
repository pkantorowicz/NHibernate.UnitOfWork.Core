using System;

namespace NHibernate.UnitOfWork.Core.Exceptions
{
    public class UnsupportedDialectException : NHibernateException
    {
        internal UnsupportedDialectException(string message, string value, ErrorCode code) : base(message, code)
        {
            Value = value;
        }

        internal UnsupportedDialectException(string message, string value, Exception innerException, ErrorCode code) : base(message, innerException, code)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
