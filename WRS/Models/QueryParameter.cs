namespace WRS.Models
{
    public class QueryParameter
    {
        public int Id { get; set; }
        public int QueryId { get; set; }
        public Query Query { get; set; }
        public string Name { get; set; }
        public string? DefaultValue { get; set; }
        public bool IsDelete { get; set; } 


    }
}
