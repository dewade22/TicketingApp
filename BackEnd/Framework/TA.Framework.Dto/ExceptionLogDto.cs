namespace TA.Framework.Dto
{
#nullable disable
    public class ExceptionLogDto : AuditableDto<int>
    {
        public string Type { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string Host { get; set; }

        public string Query { get; set; }

        public string User { get; set; }
    }
}
