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
        [Required(ErrorMessage = "Last Service is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? LastService { get; set; }
        public override bool Equals(Object obj)
        {
            if (obj is Vehicle)
            {
                var that = obj as Vehicle;

                return this.Id == that.Id && this.Name == that.Name
                        && this.Description == that.Description && this.VIN == that.VIN
                        && this.Fleet == that.Fleet && this.LastService == that.LastService;
            }

            return false;
        }
    }
}
