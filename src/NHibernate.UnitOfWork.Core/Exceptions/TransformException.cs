using System;

namespace NHibernate.UnitOfWork.Core.Exceptions
{
    public class TransformException : NHibernateException
    {
        internal TransformException(string message, ErrorCode code) : base(message, code)
        {
        }

        internal TransformException(string message, Exception innerException, ErrorCode code) : base(message, innerException, code)
        {
        }
    }
}