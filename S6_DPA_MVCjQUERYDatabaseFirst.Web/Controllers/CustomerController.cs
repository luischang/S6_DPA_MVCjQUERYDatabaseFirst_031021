using Microsoft.AspNetCore.Mvc;
using S6_DPA_MVCjQUERYDatabaseFirst.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S6_DPA_MVCjQUERYDatabaseFirst.Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var customers = await CustomerRepo.GetCustomersAsync();
            return PartialView(customers);
        }
    }
}
