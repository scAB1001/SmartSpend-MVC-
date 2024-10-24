using Microsoft.AspNetCore.Mvc;
using SmartSpend.Models;
using System.Diagnostics;

namespace SmartSpend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SmartSpendDbContext _context;

        public HomeController(ILogger<HomeController> logger, SmartSpendDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            var sortedById = allExpenses.OrderBy(e => e.Id).ToList();

            return View(sortedById);
        }

        public IActionResult CreateEditExpense(int? id)
        {
            if (id.HasValue)
            {
                var expense = _context.Expenses.FirstOrDefault(e => e.Id == id.Value);
                if (expense == null)
                {
                    return NotFound();
                }
                return View(expense);
            }
            return View(new Expense());
        }

        [HttpPost]
        public IActionResult CreateEditExpenseForm(Expense model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _context.Add(model);
                }
                else
                {
                    _context.Update(model);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Expenses));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var expense = _context.Expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
            return RedirectToAction(nameof(Expenses));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
