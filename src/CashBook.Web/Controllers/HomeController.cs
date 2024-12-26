using System.Diagnostics;
using CashBook.Web.Models;
using CashBook.Core.Models;
using Microsoft.AspNetCore.Mvc;
using CashBook.Core.Abstractions.IServices;

namespace CashBook.Web.Controllers
{
    public class HomeController(ITransactionsService _transactionsService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Transaction>? result = await _transactionsService.GetAllTransactions();

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}