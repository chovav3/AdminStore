using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using storeAdmin.Models;

namespace storeAdmin.Controllers
{
    [Authorize]
    public class AllBuysController : Controller
    {
        private readonly AllBuyContext _context;

        public AllBuysController(AllBuyContext context)
        {
            _context = context;
        }

        // GET: AllBuys
        public async Task<IActionResult> Index()
        {
            return View(await _context.All.ToListAsync());
        }
    }
}