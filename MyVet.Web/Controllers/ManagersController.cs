﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVet.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManagersController: Controller
    {
        private readonly DataContext _context;

        public ManagersController(DataContext context)
        {
            _context = context;
        }
    }
}
