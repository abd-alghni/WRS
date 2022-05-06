using System.ComponentModel.DataAnnotations.Schema;

namespace WRS.Models
{
    public class Query
    {
        public int Id { get; set; }
        [ForeignKey("ReportId")]
        public int ReportId { get; set; }
        public Report Report { get; set; }
        public List<QueryParameter> QueryParameters { get; set; }
        public string QueryBody { get; set; }
        public bool IsDelete { get; set; }
    }
}
