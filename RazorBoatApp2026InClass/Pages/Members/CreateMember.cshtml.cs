using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using SailClubLibrary.Exceptions;

namespace RazorBoatApp2026InClass.Pages.Members
{
    public class CreateMemberModel : PageModel
    {
        private IMemberRepository _repo;
        [BindProperty]
        public Member NewMember { get; set; }
        public CreateMemberModel(IMemberRepository repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _repo.AddMember(NewMember);
            }
            catch (MemberPhoneNumberExistsException e)
            {
                ViewData["ErrorMessage"] = e.Message;
                return Page();
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
