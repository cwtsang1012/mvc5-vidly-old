﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>()
            {
                new Customer(){ Id = 1, Name = "John Smith" },
                new Customer(){ Id = 2, Name = "Mary Williams" }
            };
            var viewModel = new CustomerListViewModel() { Customers = customers };
            Session["CustomeListViewModel"] = viewModel;
            return View(viewModel);
        }

        [Route("Customers/Detail/{id}")]
        public ActionResult Detail(int id) {
            var customers = (CustomerListViewModel)Session["CustomeListViewModel"];
            var customer = customers.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            else
                return View(customer);

        }
    }
}