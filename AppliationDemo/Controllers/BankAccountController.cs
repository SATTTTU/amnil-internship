using AppliationDemo.Services;
using AppliationDemo.DTOs;
using AppliationDemo.Repositories;
using AppliationDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AppliationDemo.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly BankService _bankService;
        private readonly IBankAccountRepository _accountRepo;
        private readonly ILogger<BankAccountController> _logger;

        public BankAccountController(
            IBankAccountRepository accountRepo,
            ITransactionRepository transactionRepo,
            ILogger<BankAccountController> logger)
        {
            try
            {
                _bankService = new BankService(accountRepo, transactionRepo);
                _accountRepo = accountRepo;
                _logger = logger;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error initializing BankAccountController.");
                throw;
            }
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var accounts = await _accountRepo.GetAllAsync();
                return View(accounts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading accounts.");
                TempData["Error"] = "Error fetching accounts.";
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading create page.");
                TempData["Error"] = "Unable to load create page.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankAccountDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                var newAccount = new BankAccountDto
                {
                    AccountHolder = dto.AccountHolder,
                    Balance = dto.Balance
                };

                await _bankService.CreateAccount(newAccount);
                TempData["Success"] = " Account created successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating account.");
                ModelState.AddModelError("", "Unexpected error while creating account.");
                return View(dto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Deposit(int id)
        {
            try
            {
                var account = await _accountRepo.GetByIdAsync(id);
                if (account == null)
                {
                    TempData["Error"] = "Account not found.";
                    return RedirectToAction(nameof(Index));
                }

                var dto = new TransactionDto { AccountId = account.Id };
                return View(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading deposit page.");
                TempData["Error"] = "Unable to load deposit page.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deposit(TransactionDto dto)
        {
            try
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
                TempData["Success"] = " Deposit successful!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing deposit.");
                ModelState.AddModelError("", "Deposit failed: " + ex.Message);
                return View(dto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Withdraw(int id)
        {
            try
            {
                var account = await _accountRepo.GetByIdAsync(id);
                if (account == null)
                {
                    TempData["Error"] = "Account not found.";
                    return RedirectToAction(nameof(Index));
                }

                var dto = new TransactionDto { AccountId = account.Id };
                return View(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading withdraw page.");
                TempData["Error"] = "Unable to load withdrawal page.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                if (dto.Amount <= 0)
                {
                    ModelState.AddModelError("Amount", "Withdrawal amount must be greater than zero.");
                    return View(dto);
                }

                await _bankService.Withdraw(dto);
                TempData["Success"] = " Withdrawal successful!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing withdrawal.");
                ModelState.AddModelError("", "Withdrawal failed: " + ex.Message);
                return View(dto);
            }
        }
    }
}
