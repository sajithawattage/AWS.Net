using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaymentSolution.Helper;

namespace PaymentSolution.Pages.Consumer
{
    public class InquireModel : PageModel
    {
        public InquireModel() { }

        [BindProperty]
        public Models.InquireModel Model { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                throw new System.Exception("Error in model");
            }

            var x = Model;

            //record the inquire
            var result = SaveInquire(x);
            if (result)
            {
                //send email
                SendInquireMail();
            }

            return RedirectToPage(ConstantHelper.PAGE_HOME);
        }

        #region Private Methods

        private bool SaveInquire(Models.InquireModel model)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return false;
        }

        private bool SendInquireMail()
        {
            return false;
        }

        #endregion

    }
}