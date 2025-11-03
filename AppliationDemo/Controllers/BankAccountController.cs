using AppliationDemo.Services;
using AppliationDemo.DTOs;
using AppliationDemo.Repositories;
using AppliationDemo.Models;
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

        // ----------------- LIST ALL ACCOUNTS -----------------
        public async Task<IActionResult> Index()
        {
            var accounts = await _accountRepo.GetAllAsync();
            return View(accounts);
        }

        // ----------------- CREATE ACCOUNT -----------------
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(BankAccount dto)
        {
            if (!ModelState.IsValid)
            {
                // If validation fails, redisplay the form
                return View(dto);
            }

            var newAccount = new BankAccountDto
            {
                AccountNumber = dto.AccountNumber,
                AccountHolder = dto.AccountHolder,
                Balance = dto.Balance
            };

            await _bankService.CreateAccount(newAccount);
            TempData["Success"] = "Account created successfully!";
            return RedirectToAction("Index");
        }

        // ----------------- DEPOSIT -----------------
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
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            if (dto.Amount <= 0)
            {
                ModelState.AddModelError("Amount", "Deposit amount must be greater than zero.");
                return View(dto);
            }

            await _bankService.Deposit(dto);
            TempData["Success"] = "Deposit successful!";
            return RedirectToAction("Index");
        }

        // ----------------- WITHDRAW -----------------
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
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            if (dto.Amount <= 0)
            {
                ModelState.AddModelError("Amount", "Withdraw amount must be greater than zero.");
                return View(dto);
            }

            try
            {
                await _bankService.Withdraw(dto);
                TempData["Success"] = "Withdrawal successful!";
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(dto);
            }
        }
    }
}
