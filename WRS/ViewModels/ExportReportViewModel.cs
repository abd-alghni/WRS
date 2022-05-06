namespace WRS.ViewModels
{
    public class ExportReportViewModel
    {
        public string Name { get; set; }
        public int ReportId { get; set; }
        public int DataSourceId { get; set; }

        public string[] QueryParams;

    }
}
