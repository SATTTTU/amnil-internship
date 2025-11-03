using AppliationDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppliationDemo.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpGet, HttpPost]
        public async Task<IActionResult> List(int accountId)
        {
            if (accountId <= 0)
            {
                ViewBag.Error = "Please enter a valid Account ID.";
                return View("Search");
            }

            try
            {
                var transactions = await _transactionService.GetTransactionsByAccountId(accountId);

                if (transactions == null || !transactions.Any())
                {
                    ViewBag.Error = "No transactions found for this account.";
                    return View("Search");
                }

                ViewBag.AccountId = accountId;
                return View(transactions);
            }
            catch (System.Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Search");
            }
        }
    }
}
