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
    public class AllCustomerModel : PageModel
    {

        private readonly CustomerPanelContext _context;

        public AllCustomerModel(CustomerPanelContext context)
        {
            _context = context;
        }

        public List<Customers> CustomerList { get; set; }

        public void OnGet()
        {
            var data = (from customerlist in _context.Customers
                        select customerlist).ToList();

            CustomerList = data;
        }


        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from customer in _context.Customers
                            where customer.CustomerID == id
                            select customer).SingleOrDefault();

                _context.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToPage("AllCustomer");
        }

    }
}
