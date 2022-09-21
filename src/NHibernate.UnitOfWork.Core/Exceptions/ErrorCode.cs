namespace NHibernate.UnitOfWork.Core.Exceptions
{
    public record ErrorCode
    {
        public static ErrorCode UnsupportedDialect => new ErrorCode(1001, "Unsupported dialect");
        public static ErrorCode UsupportedProjection => new ErrorCode(1002, "Unsupported projection");
        public static ErrorCode TransformError => new ErrorCode(1003, "Transform error");

        private ErrorCode(int code, string description)
        {
            Code = code;
            Description = description;
        }

        public int Code { get; }
        public string Description { get; }
    }
}