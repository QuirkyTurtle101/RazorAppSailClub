using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Boats
{
    public class EditBoatModel : PageModel
    {

        private IBoatRepository _repo;

        public Boat BoatToUpdate { get; set; }

        public EditBoatModel(IBoatRepository boatRepository)
        {
            _repo = boatRepository;
        }
        public void OnGet(string sailNumber)
        {
            BoatToUpdate =_repo.SearchBoat(sailNumber);
        }
    }
}
