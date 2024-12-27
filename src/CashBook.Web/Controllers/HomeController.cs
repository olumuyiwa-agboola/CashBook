using System.Diagnostics;
using CashBook.Web.Models;
using CashBook.Core.Models;
using Microsoft.AspNetCore.Mvc;
using CashBook.Core.Extensions;
using CashBook.Core.Abstractions.IServices;

namespace CashBook.Web.Controllers
{
    public class HomeController(ITransactionsService _transactionsService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var transactionTypes = Enum.GetValues<TransactionType>()
                                       .Cast<TransactionType>()
                                       .Select(type => type.GetDisplayName()).ToList();

            ViewBag.TransactionTypes = transactionTypes;

            var transactionSubtypes = Enum.GetValues<TransactionSubtype>()
                           .Cast<TransactionSubtype>()
                           .Select(type => type.GetDisplayName()).ToList();

            ViewBag.TransactionSubtypes = transactionSubtypes;

            var transactions = await _transactionsService.GetAllTransactions();

            return View(transactions);
        }

        public async Task<IActionResult> AddTransaction(Transaction transaction)
        {
            var result = await _transactionsService.CreateTransaction(transaction);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteTransaction(string id)
        {
            var result = await _transactionsService.DeleteTransaction(id);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}