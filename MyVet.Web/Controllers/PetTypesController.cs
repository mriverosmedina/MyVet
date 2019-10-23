using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVet.Web.Data;
using MyVet.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Controllers
{
    public class PetTypesController: Controller
    {
        private readonly DataContext _context;

        public PetTypesController(DataContext context)
        {
            _context = context;
        }
        //GET: PetTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PetTypes.ToListAsync());
        }

        //GET: PetTypes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id== null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Owner);
        //}




    }
}
