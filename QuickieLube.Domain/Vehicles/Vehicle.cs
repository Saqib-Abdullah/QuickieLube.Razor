using System;
using System.ComponentModel.DataAnnotations;

namespace QuickieLube.Domain.Vehicles
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VIN { get; set; }
        public string Fleet { get; set; }
        public DateTime LastService { get; set; }
    }
}
