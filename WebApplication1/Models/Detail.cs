﻿namespace DJ_s_League.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string MinimumLevel { get; set; }

        
    }
}