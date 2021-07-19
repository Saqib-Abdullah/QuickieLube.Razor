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
    public class VehicleSearchModel : PageModel
    {
        private readonly IVehicleRepository _vehicleRepository;
        [BindProperty(SupportsGet = true)]
        public IEnumerable<Vehicle> Vehicles { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchParams { get; set; }

        public VehicleSearchModel(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IActionResult OnGet()
        {
            try
            {
                Vehicles = _vehicleRepository.SearchVehicle(SearchParams);
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

        }

        public void OnPostClearSearchField()
        {
            SearchParams = "";
            OnGet();
        }

    }
}
