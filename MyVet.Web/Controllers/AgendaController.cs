using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVet.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Controllers
{
    public class AgendaController : Controller
    {
        private readonly DataContext _context;

        public AgendaController(DataContext context)
        {
            _context = context;
        }

        //GET: Agenda
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agendas.ToListAsync());
        }
    }
}
