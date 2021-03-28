using BankProjectSystem.Data;
using BankProjectSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BankProjectSystem.Controllers

{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {           
            return View();
        }

        public IActionResult Privacy()
        {
            var BankAccounts = _context.BankAccounts.ToList();

            ViewBag.BankAccounts = BankAccounts;

            return View();
        }

        public IActionResult BankAccountsMenu()
        {
            return View();
        }

        public IActionResult CreateBankAccount(BankAccountDataModel BankAccount)
        {
            BankAccount.Id = Guid.NewGuid().ToString();
            _context.BankAccounts.Add(BankAccount);
            _context.SaveChanges();

            return RedirectToAction("Privacy" , "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
