namespace WRS.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int QueryId { get; set; }
        public Query Query { get; set; }
        public int DataSourceId { get; set; }
        public DataSource DataSource { get; set; }
        public bool IsDelete { get; set; }

    }
}
