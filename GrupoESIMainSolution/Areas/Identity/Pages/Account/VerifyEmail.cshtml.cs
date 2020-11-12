using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using GrupoESIDataAccess;
using GrupoESI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace GrupoESI.Areas.Identity.Pages.Account
{
    public class VerifyEmailModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;
        public VerifyEmailModel(UserManager<IdentityUser> userManager,
                                            IEmailSender emailSender,
                                            ApplicationDbContext db)
        {
            _emailSender = emailSender;
            _userManager = userManager;
            _context = db;
        }
        [BindProperty]
        public string Email { get; set; }
        public IActionResult OnGet(string id)
        {
            Email = id;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Email != null)
                {
                    //Main logic here...
                    var user = _context.Users.FirstOrDefault(u => u.Email == Email);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    return Page();
                }
                //Email is Null (Else) logic here...
                return Page();
            }

            // If we got this far, something failed, redisplay form
            //Model State isn't Valid (Else) logic here...
            return Page();
        }
    }
}
