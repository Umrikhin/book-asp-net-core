﻿namespace Dropdownlist.Models
{
    public class ViewLand
    {
        public int idLand { get; set; }
        public List<City> cities { get; set; } = new List<City>();
    }
}
