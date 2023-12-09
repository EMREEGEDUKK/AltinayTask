using AltınayTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;

namespace AltınayTask.Controllers
{
    public class JobController : Controller
    {
        private AppDbContext _context;



        public JobController(AppDbContext context)
        {
            _context = context;

        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add () 
        {
            
            return View(); 
        }

        [HttpPost]
        public IActionResult AddAttrA()
        {

            var getAttrA = int.Parse(HttpContext.Request.Form["attrA"].ToString());

            Utility.MethodA(_context, 0, getAttrA); 

            return RedirectToAction("Index");


        }
    }
}
