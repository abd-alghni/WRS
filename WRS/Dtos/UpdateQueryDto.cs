namespace WRS.Dtos
{
    public class UpdateQueryDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string QueryBody { get; set; }
        public string[] QueryParams { get; set; }
    }
}
