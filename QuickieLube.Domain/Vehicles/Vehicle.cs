using System;
using System.ComponentModel.DataAnnotations;

namespace QuickieLube.Domain.Vehicles
{
    public class Vehicle
    {

        public string Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "VIN is required")]
        public string VIN { get; set; }
        [Required(ErrorMessage = "Fleet is required")]
        public string Fleet { get; set; }
        [Display(Name = "Last Service")]
        [Required(ErrorMessage = "LastService is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? LastService { get; set; }
    }
}
