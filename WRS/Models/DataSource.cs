namespace WRS.Models
{
    public class DataSource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }
        public string Driver { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Report> Report { get; set; }
        public bool IsDelete { get; set; }

    }
}
