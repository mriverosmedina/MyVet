using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVet.Common.Models;
using MyVet.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly DataContext _datacontext;

        public OwnersController(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        [HttpPost]
        [Route("GetOwnerByEmail")]
        public async Task<IActionResult> GetOwner(EmailRequest emailRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }


            var owner = await _datacontext.Owners.FirstOrDefaultAsync(o => o.User.Email == emailRequest.Email);

            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }
    }
}
