using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmailWebDemo1.Pages
{
    public class WorkersModel : PageModel
    {
        public int I { get; set; }

        public void OnGet()
        {
            //H�r s�tts i till 0
            int i = 0;
            I = i  + 1;
        }
    }
}
