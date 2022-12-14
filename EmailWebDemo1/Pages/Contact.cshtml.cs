using System.ComponentModel.DataAnnotations;
using EmailWebDemo1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmailWebDemo1.Pages
{
    [BindProperties]
    public class ContactModel : PageModel
    {
        private readonly IEmailSenderService _emailSenderService;

        public ContactModel(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            
            if (ModelState.IsValid)
            {
                _emailSenderService.SendEmail(Namn,Header,Message);
                //Anropa Namn, header, Message
                Sent = true;
            }
            
        }
        public bool Sent { get; set; }

        [Required]
        public string Namn { get; set; }
        [Required]
        public string Header { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
