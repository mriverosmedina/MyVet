using Microsoft.AspNetCore.Mvc;
using MyVet.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Controllers
{
    public class ServiceTypesController: Controller
    {
        private readonly DataContext _context;

        public ServiceTypesController(DataContext context)
        {
            _context = context;
        }
    }
}
