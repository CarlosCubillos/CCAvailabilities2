using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Availabilities2.Data;
using Microsoft.EntityFrameworkCore;
using Availabilities2.Models;
using Availabilities2;

namespace Availability2.Controllers
{
    public class AvailabilitiesController : Controller
    {
        private readonly AvailabilityUIContext _context;

        public AvailabilitiesController(AvailabilityUIContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string symbolSearchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SymbolSortParam"] = String.IsNullOrEmpty(sortOrder) ? "symbolDesc" : "";
            ViewData["CurrentFilter"] = symbolSearchString == null ? currentFilter : symbolSearchString;

            if (symbolSearchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                symbolSearchString = currentFilter;
            }

            var availabilities = from a in _context.Availabilities select a;

            if (!String.IsNullOrEmpty(symbolSearchString))
            {
                availabilities = availabilities.Where(a => a.Symbol.Contains(symbolSearchString));
            }

            switch (sortOrder)
            {
                case "symbolDesc":
                    availabilities = availabilities.OrderByDescending(a => a.Symbol);
                    break;
                default:
                    availabilities = availabilities.OrderBy(a => a.Symbol);
                    break;
            }

            int pageSize = 20;
            return View(await PaginatedList<Availability>.CreateAsync(availabilities.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

    }
}
