namespace WRS.Dtos
{
    public class CreateQueryDto
    {
        public int ReportId { get; set; }
        public string QueryBody { get; set; }
        public string [] QueryParams { get; set; }
    }
}
