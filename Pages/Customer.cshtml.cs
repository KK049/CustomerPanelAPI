using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerPanel.Data;
using CustomerPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerPanel.Pages
{
    public class CustomerModel : PageModel
    {

        private readonly CustomerPanelContext _context;

        public CustomerModel(CustomerPanelContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Customers Customers { get; set; }
        public void OnGet()
        {
        }


        public ActionResult OnPost()
        {
            var customer = Customers;
            if (!ModelState.IsValid)
            {
                return Page(); // return page  
            }

            customer.CustomerID = 0;
            var result = _context.Add(customer);
            _context.SaveChanges(); // Saving Data in database  

            return RedirectToPage("AllCustomer");
        }

    }
}
