using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Models;
using SailClubLibrary.Services;
using SailClubLibrary.Interfaces;

namespace RazorBoatApp2026InClass.Pages.Bookings
{
    public class ChooseBoatModel : PageModel
    {
        private IBoatRepository _repo;
        public List<Boat> Boats;

        public ChooseBoatModel(IBoatRepository repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {
            Boats = _repo.GetAllBoats();
        }
    }
}
