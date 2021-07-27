using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickieLube.Application.Vehicles;
using QuickieLube.Domain.Vehicles;

namespace QuickieLube.Razor.Pages.Vehicles
{
    public class EditModel : PageModel
    {
        private readonly IVehicleRepository _vehicleRepository;
        [BindProperty(SupportsGet = true)]
        public Vehicle Vehicle { get; set; }

        public EditModel(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IActionResult OnGet(string id)
        {
            Vehicle = _vehicleRepository.GetVehicleById(id);

            if (Vehicle == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _vehicleRepository.EditVehicle(Vehicle);
                    return RedirectToPage("/Vehicles/VehicleSearch");
                }
                catch (Exception)
                {

                }
            }

            return Page();

        }
    }
}
