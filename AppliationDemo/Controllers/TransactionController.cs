using AppliationDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppliationDemo.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionService _transactionService;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(TransactionService transactionService, ILogger<TransactionController> logger)
        {
            try
            {
                _transactionService = transactionService;
                _logger = logger;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error initializing TransactionController.");
                throw;
            }
        }

        [HttpGet]
        public IActionResult Search()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading search page.");
                TempData["Error"] = "Unable to load search page.";
                return RedirectToAction(nameof(Search));
            }
        }

        [HttpGet]
        public async Task<IActionResult> List(int accountId)
        {
            try
            {
                if (accountId <= 0)
                {
                    ViewBag.Error = " Please enter a valid Account ID.";
                    return View("Search");
                }

                var transactions = await _transactionService.GetTransactionsByAccountId(accountId);

                if (transactions == null || !transactions.Any())
                {
                    ViewBag.Error = "No transactions found for this account.";
                    return View("Search");
                }

                ViewBag.AccountId = accountId;
                return View(transactions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching transactions for Account ID: {AccountId}", accountId);
                ViewBag.Error = "An unexpected error occurred while retrieving transactions.";
                return View("Search");
            }
        }
    }
}
