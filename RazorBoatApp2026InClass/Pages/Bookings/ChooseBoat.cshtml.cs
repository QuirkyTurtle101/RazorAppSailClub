using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Helpers.Sorters;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using SailClubLibrary.Services;

namespace RazorBoatApp2026InClass.Pages.Bookings
{
    public class ChooseBoatModel : PageModel
    {
        private IBoatRepository _repo;
        public List<Boat> Boats;

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public ChooseBoatModel(IBoatRepository repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Boats = _repo.FilterBoats(FilterCriteria);
            }
            else
            {
                Boats = _repo.GetAllBoats();
            }
            switch (SortBy)
            {
                case "ID":
                    Boats.Sort();
                    break;
                case "YearOfConstruction":
                    Boats.Sort(new BoatComparerYear());
                    break;
                default:
                    break;
            }
        }
    }
}
