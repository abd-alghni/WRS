﻿namespace WRS.Dtos
{
    public class UpdateDataSourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }
        public string Driver { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
