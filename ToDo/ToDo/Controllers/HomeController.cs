using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDo.Areas.Identity.Data;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthDbContext context;
        public HomeController(ILogger<HomeController> logger, AuthDbContext context)
        {
            _logger = logger;
            this.context = context;
        }


        //GET
        public async Task<ActionResult> Index()
        {
            IQueryable<UserTask> list = from i in context.Tasks orderby i.Id select i;

            List<UserTask> listTasks = await list.ToListAsync();

            return View(listTasks);
        }

        //GET method create
        public IActionResult Create() => View();

        //POST method create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserTask newTask)
        {
            if(ModelState.IsValid)
            {
                context.Add(newTask);
                await context.SaveChangesAsync();

                TempData["Success"] = "Успешно добавяне на нова задача";

                return RedirectToAction("Index");

            }

            return View(newTask);
        }

        //GET method edit
        public async Task<ActionResult> Edit(int id)
        {
            UserTask item = await context.Tasks.FindAsync(id);
            if(item == null)
            {
                return NotFound(item);
            }

            return View(item);
        }

        //POST method update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserTask newTask)
        {
            if (ModelState.IsValid)
            {
                context.Update(newTask);
                await context.SaveChangesAsync();

                TempData["Success"] = "Успешна промяна на задача";

                return RedirectToAction("Index");

            }

            return View(newTask);
        }

        //GET method delete
        public async Task<ActionResult> Delete(int id)
        {
            UserTask item = await context.Tasks.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "Задачата не съществува.";
            }
            else
            {
                context.Tasks.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "Успешно изтрита задача.";
            }


            return RedirectToAction("Index");
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
