using Microsoft.AspNetCore.Mvc;
using S6_DPA_MVCjQUERYDatabaseFirst.Web.Models;
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

        [HttpPost]
        public async Task<IActionResult> Grabar(int idCliente, string nombre,
            string apellido, string ciudad, string telefono, string pais)
        {
            var customer = new Customer()
            {
                FirstName = nombre,
                LastName = apellido,
                Country = pais,
                Phone = telefono,
                City = ciudad
            };
            bool exito = true;

            if (idCliente == -1)
                exito = await CustomerRepo.Insert(customer);
            else {
                customer.Id = idCliente;
                exito = await CustomerRepo.Update(customer);
            }

            return Json(exito);
        }


    }
}
