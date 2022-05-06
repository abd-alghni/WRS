using WRS.Models;

namespace WRS.Dtos
{
    public class CreateReportDto
    {
        public string Name { get; set; }
        public int DataSourceId { get; set; }
    }
}
