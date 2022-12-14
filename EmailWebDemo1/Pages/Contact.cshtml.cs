using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmailWebDemo1.Pages
{
    [BindProperties]
    public class ContactModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            //Send email!!!
            if (ModelState.IsValid)
            {
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
