using Microsoft.EntityFrameworkCore;
using S6_DPA_MVCjQUERYDatabaseFirst.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S6_DPA_MVCjQUERYDatabaseFirst.Web.Repository
{
    public class CustomerRepo
    {

        public static IEnumerable<Customer> GetCustomers()
        {
            using var data = new SalesDBContext();
            var customers = data.Customer.ToList();
            return customers;
        }

        public static async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            using var data = new SalesDBContext();
            var customers = await data.Customer.ToListAsync();
            return customers;
        }

        public static IEnumerable<Customer> GetCustomersSP()
        {
            using var data = new SalesDBContext();
            var customers = data.Customer.FromSqlRaw("SP_GET_CUSTOMERS");
            return customers;
        }

        public static async Task<Customer> GetCustomer(int id) 
        {
            using var data = new SalesDBContext();
            var customer = await data.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();

            return customer;
        }

        public static async Task<bool> Insert(Customer customer)
        {
            bool exito = true;

            try
            {
                using var data = new SalesDBContext();
                await data.Customer.AddAsync(customer);
                await data.SaveChangesAsync();

            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;
        }

        public static async Task<bool> Update(Customer customer)
        {
            bool exito = true;

            try
            {
                using var data = new SalesDBContext();
                var customerNow = await data.Customer.Where(x => x.Id == customer.Id).FirstOrDefaultAsync();
                customerNow.FirstName = customer.FirstName;
                customerNow.LastName = customer.LastName;
                customerNow.City = customer.City;
                customerNow.Country = customer.Country;
                customerNow.Phone = customer.Phone;

                await data.SaveChangesAsync();

            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;
        }

        public static async Task<bool> Delete(int id)
        {
            bool exito = true;

            try
            {
                using var data = new SalesDBContext();
                var customerNow = await data.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();

                data.Customer.Remove(customerNow);
                await data.SaveChangesAsync();


            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;
        }




    }
}
