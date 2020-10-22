using System;
using GrupoESIDataAccess.Queries;
using GrupoESIModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESINuevo
{
    public class EditUserModel : PageModel
    {

        private readonly IQueries _queries;
        public EditUserModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public ApplicationUser _ApplicationUser { get; set; }
        public IActionResult OnGet(string userId)
        {
            if(userId == "")
            {
                return NotFound();
            }
            _ApplicationUser = _queries.GetApplicationUserIncludeServiceLst(userId);

            if(_ApplicationUser == null)
            {
                return NotFound();
            }

            return Page();
        }
        public IActionResult OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            var ApplicationUserLocal = _queries.GetApplicationUserIncludeServiceLst(_ApplicationUser.Id);            
            if(ApplicationUserLocal == null)
            {
                return NotFound();
            }
            ApplicationUserLocal.Bank = _ApplicationUser.Bank;
            ApplicationUserLocal.City = _ApplicationUser.City;
            ApplicationUserLocal.CompanyName = _ApplicationUser.CompanyName;
            ApplicationUserLocal.Email = _ApplicationUser.Email;
            ApplicationUserLocal.Name = ApplicationUserLocal.Name;
            ApplicationUserLocal.PhoneNumber = _ApplicationUser.PhoneNumber;
            ApplicationUserLocal.RFC = _ApplicationUser.RFC;
            ApplicationUserLocal.SocialReason = _ApplicationUser.SocialReason;
            ApplicationUserLocal.State = _ApplicationUser.State;
            try
            {
                _queries.SaveChanges();
            }
            catch(Exception ex)
            {
                
            }
            return RedirectToPage("Index");
        }
    }
}