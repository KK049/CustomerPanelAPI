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
    public class EditCustomerModel : PageModel
    {
        private readonly CustomerPanelContext _context;
        public EditCustomerModel(CustomerPanelContext context)
        {
            _context = context;
        }



        [BindProperty]
        public Customers Customer { get; set; }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from customer in _context.Customers
                            where customer.CustomerID == id
                            select customer).SingleOrDefault();

                Customer = data;
            }
        }

        public ActionResult OnPost()
        {
            var customer = Customer;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Entry(customer).Property(x => x.Name).IsModified = true;
            _context.Entry(customer).Property(x => x.Phoneno).IsModified = true;
            _context.Entry(customer).Property(x => x.Address).IsModified = true;
            _context.Entry(customer).Property(x => x.City).IsModified = true;
            _context.Entry(customer).Property(x => x.Country).IsModified = true;
            _context.SaveChanges();
            return RedirectToPage("AllCustomer");
        }


    }
}
