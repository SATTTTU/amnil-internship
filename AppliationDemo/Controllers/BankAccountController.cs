using AppliationDemo.Services;
using AppliationDemo.DTOs;
using AppliationDemo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppliationDemo.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly BankService _bankService;
        private readonly IBankAccountRepository _accountRepo;

        public BankAccountController(IBankAccountRepository accountRepo, ITransactionRepository transactionRepo)
        {
            _bankService = new BankService(accountRepo, transactionRepo);
            _accountRepo = accountRepo;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _accountRepo.GetAllAsync();
            return View(accounts);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(BankAccountDto dto)
        {
            await _bankService.CreateAccount(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Deposit(int id)
        {
            var account = await _accountRepo.GetByIdAsync(id);
            if (account == null)
                return NotFound();

            return View(account); 
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(TransactionDto dto)
        {
            await _bankService.Deposit(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Withdraw(int id)
        {
            var account = await _accountRepo.GetByIdAsync(id);
            if (account == null)
                return NotFound();

            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            await _bankService.Withdraw(dto);
            return RedirectToAction("Index");
        }

    }
}
