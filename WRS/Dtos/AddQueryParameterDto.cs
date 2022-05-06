namespace WRS.Dtos
{
    public class AddQueryParameterDto
    {
        public int QueryId { get; set; }
        public string Name { get; set; }
        public string? DefaultValue { get; set; }
    }
}
