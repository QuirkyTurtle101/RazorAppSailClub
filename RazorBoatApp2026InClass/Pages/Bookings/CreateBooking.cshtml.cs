using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Models;
using SailClubLibrary.Services;
using SailClubLibrary.Interfaces;

namespace RazorBoatApp2026InClass.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        private IBoatRepository _boatRepo;
        private IBookingRepository _bookingRepo;
        private IMemberRepository _memberRepo;

        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]
        public DateTime EndDate { get; set; }
        [BindProperty]
        public string Destination { get; set; }
        
        public Boat BoatChosen { get; set; }

        public CreateBookingModel(IBoatRepository boatRepository, IBookingRepository bookingRepository, IMemberRepository memberRepository)
        {
            _boatRepo = boatRepository;
            _bookingRepo = bookingRepository;
            _memberRepo = memberRepository;

            //StartDate = DateTime.Now;
            //EndDate = DateTime.Now;
        }

        public void OnGet(string sailNumber)
        {
            BoatChosen = _boatRepo.SearchBoat(sailNumber);
        }

        public IActionResult OnPost(string sailNumber)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Booking NewBooking = new Booking(_bookingRepo.GetAllBookings().Count()+1, StartDate, EndDate, Destination, _memberRepo.SearchMember(PhoneNumber), _boatRepo.SearchBoat(sailNumber));
            try{
                _bookingRepo.AddBooking(NewBooking);
            }
            catch (Exception e)
            {
                ViewData["ErrorMessage"] = e.Message;
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}
