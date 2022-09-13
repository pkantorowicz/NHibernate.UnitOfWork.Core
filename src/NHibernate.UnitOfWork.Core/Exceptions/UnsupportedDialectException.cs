using System;

namespace NHibernate.UnitOfWork.Core.Exceptions
{
    internal class UnsupportedDialectException : NHibernateException
    {
        public UnsupportedDialectException(string message, string value, string code) : base(message, code)
        {
            Value = value;
        }

        public UnsupportedDialectException(string message, string value, Exception innerException, string code) : base(message, innerException, code)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
